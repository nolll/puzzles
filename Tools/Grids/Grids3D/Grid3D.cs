using System.Text;

namespace Pzl.Tools.Grids.Grids3D;

public class Grid3D<T> where T : struct
{
    private readonly T _defaultValue;
    private readonly IDictionary<Coord3D, T> _grid;
    public Coord3D Coord { get; private set; }
    public Coord3D StartCoord { get; set; }

    public int Width => XMax - XMin + 1;
    public int Height => YMax - YMin + 1;
    public int Depth => ZMax - ZMin + 1;
    public int XMin { get; private set; }
    public int XMax { get; private set; }
    public int YMin { get; private set; }
    public int YMax { get; private set; }
    public int ZMin { get; private set; }
    public int ZMax { get; private set; }
    public bool IsAtTop => Coord.Y == 0;
    public bool IsAtRightEdge => Coord.X == Width - 1;
    public bool IsAtBottom => Coord.Y == Height - 1;
    public bool IsAtLeftEdge => Coord.X == 0;

    public Coord3D Center
    {
        get
        {
            var xDiff = Math.Abs(XMax - XMin);
            var yDiff = Math.Abs(YMax - YMin);
            var zDiff = Math.Abs(ZMax - ZMin);
            return new(XMax - xDiff / 2, YMax - yDiff / 2, ZMax - zDiff / 2);
        }
    }

    public Grid3D(int width = 1, int height = 1, int depth = 1, T defaultValue = default)
    {
        _defaultValue = defaultValue;
        _grid = BuildGrid(width, height, depth, defaultValue);
        XMax = width - 1;
        YMax = height - 1;
        ZMax = depth - 1;
        Coord = new Coord3D(0, 0, 0);
        StartCoord = new Coord3D(0, 0, 0);
    }

    public IEnumerable<T> Values =>
        Coords.Select(coord => _grid.TryGetValue(coord, out var v)
            ? v
            : _defaultValue);

    public IEnumerable<Coord3D> Coords
    {
        get
        {
            for (int z = ZMin; z <= ZMax; z++)
            {
                for (var y = YMin; y <= YMax; y++)
                {
                    for (var x = XMin; x <= XMax; x++)
                    {
                        yield return new Coord3D(x, y, z);
                    }
                }
            }
        }
    }

    public bool TryMoveTo(Coord3D address) => MoveTo(address, false);
    public bool MoveTo(Coord3D address) => MoveTo(address, true);

    private bool MoveTo(Coord3D address, bool extend)
    {
        if (IsOutOfRange(address))
        {
            if (extend)
                ExtendGrid(address);
            else
                return false;
        }

        var x = address.X > XMin ? address.X : XMin;
        var y = address.Y > YMin ? address.Y : YMin;
        var z = address.Z > ZMin ? address.Z : ZMin;
        Coord = new Coord3D(x, y, z);
        return true;
    }

    public bool TryMoveTo(int x, int y, int z) => MoveTo(new Coord3D(x, y, z), false);
    public bool MoveTo(int x, int y, int z) => MoveTo(new Coord3D(x, y, z), true);
    public bool TryMoveUp(int steps = 1) => MoveUp(steps, false);
    public bool MoveUp(int steps = 1) => MoveUp(steps, true);
    private bool MoveUp(int steps, bool extend) => MoveTo(new Coord3D(Coord.X, Coord.Y - steps, Coord.Z), extend);
    public bool TryMoveRight(int steps = 1) => MoveRight(steps, false);
    public bool MoveRight(int steps = 1) => MoveRight(steps, true);
    private bool MoveRight(int steps, bool extend) => MoveTo(new Coord3D(Coord.X + steps, Coord.Y, Coord.Z), extend);
    public bool TryMoveDown(int steps = 1) => MoveDown(steps, false);
    public bool MoveDown(int steps = 1) => MoveDown(steps, true);
    private bool MoveDown(int steps, bool extend) => MoveTo(new Coord3D(Coord.X, Coord.Y + steps, Coord.Z), extend);
    public bool TryMoveLeft(int steps = 1) => MoveLeft(steps, false);
    public bool MoveLeft(int steps = 1) => MoveLeft(steps, true);
    private bool MoveLeft(int steps, bool extend) => MoveTo(new Coord3D(Coord.X - steps, Coord.Y, Coord.Z), extend);
    public T ReadValue() => ReadValueAt(Coord.X, Coord.Y, Coord.Z);

    public T ReadValueAt(Coord3D coord) => _grid.TryGetValue(coord, out var v)
        ? v
        : _defaultValue;

    public T ReadValueAt(int x, int y, int z) => ReadValueAt(new Coord3D(x, y, z));
    public void WriteValue(T value) => WriteValueAt(Coord, value);

    public void WriteValueAt(Coord3D coord, T value)
    {
        if (coord.X < XMin)
            XMin = coord.X;
        else if (coord.X > XMax)
            XMax = coord.X;

        if (coord.Y < YMin)
            YMin = coord.Y;
        else if (coord.Y > YMax)
            YMax = coord.Y;

        if (coord.Z < ZMin)
            ZMin = coord.Z;
        else if (coord.Z > ZMax)
            ZMax = coord.Z;

        _grid[coord] = value;
    }

    public bool IsOutOfRange(Coord3D address) =>
        address.Z > ZMax ||
        address.Z < ZMin ||
        address.Y > YMax ||
        address.Y < YMin ||
        address.X > XMax ||
        address.X < XMin;

    public IList<T> OrthogonalAdjacentValues => OrthogonalAdjacentCoords.Select(ReadValueAt).ToList();
    public IList<Coord3D> OrthogonalAdjacentCoords => PossibleOrthogonalAdjacentCoords.Where(o => !IsOutOfRange(o)).ToList();

    private IList<Coord3D> PossibleOrthogonalAdjacentCoords =>
    [
        new(Coord.X + 1, Coord.Y, Coord.Z),
        new(Coord.X - 1, Coord.Y, Coord.Z),
        new(Coord.X, Coord.Y + 1, Coord.Z),
        new(Coord.X, Coord.Y - 1, Coord.Z),
        new(Coord.X, Coord.Y, Coord.Z + 1),
        new(Coord.X, Coord.Y, Coord.Z - 1)
    ];

    public IList<T> AllAdjacentValues => AllAdjacentCoords.Select(ReadValueAt).ToList();
    public IList<T> AllAdjacentValuesTo(Coord3D coord) => AllAdjacentCoordsTo(coord).Select(ReadValueAt).ToList();
    public IList<Coord3D> AllAdjacentCoords => AllPossibleAdjacentCoords.Where(o => !IsOutOfRange(o)).ToList();
    public IList<Coord3D> AllAdjacentCoordsTo(Coord3D coord) => AllPossibleAdjacentCoordsTo(coord).Where(o => !IsOutOfRange(o)).ToList();
    
    private IEnumerable<Coord3D> AllPossibleAdjacentCoords => AllPossibleAdjacentCoordsTo(Coord);

    private IEnumerable<Coord3D> AllPossibleAdjacentCoordsTo(Coord3D coord)
    {
        foreach (var dz in GridConstants.AdjacentDeltas)
        {
            foreach (var dy in GridConstants.AdjacentDeltas)
            {
                foreach (var dx in GridConstants.AdjacentDeltas)
                {
                    var adj = new Coord3D(coord.X + dx, coord.Y - dy, coord.Z - dz);
                    if (!adj.Equals(coord))
                        yield return adj;
                }
            }
        }
    }

    public Grid3D<T> Copy()
    {
        var grid = new Grid3D<T>();
        for (var z = 0; z < Depth; z++)
        {
            for (var y = 0; y < Height; y++)
            {
                for (var x = 0; x < Width; x++)
                {
                    grid.MoveTo(x, y, z);
                    grid.WriteValue(ReadValueAt(x, y, z));
                }
            }
        }

        grid.MoveTo(Coord);
        return grid;
    }

    private Dictionary<Coord3D, T> BuildGrid(int width, int height, int depth, T defaultValue)
    {
        var grid = new Dictionary<Coord3D, T>();
        for (var z = 0; z < depth; z++)
        {
            for (var y = 0; y < height; y++)
            {
                for (var x = 0; x < width; x++)
                {
                    grid.Add(new Coord3D(x, y, z), defaultValue);
                }
            }
        }

        return grid;
    }

    private void ExtendGrid(Coord3D address)
    {
        ExtendX(address);
        ExtendY(address);
        ExtendZ(address);
    }

    private void ExtendX(Coord3D address)
    {
        if (address.X < 0)
            ExtendLeft(address);
        ExtendRight(address);
    }

    private void ExtendLeft(Coord3D address)
    {
        AddCols(-address.X, GridAddMode.Prepend);
        StartCoord = new Coord3D(StartCoord.X - address.X, StartCoord.Y, StartCoord.Z);
    }

    private void ExtendRight(Coord3D address)
    {
        var extendBy = address.X - (Width - 1);
        if (extendBy > 0)
            AddCols(extendBy, GridAddMode.Append);
    }

    private void ExtendY(Coord3D address)
    {
        if (address.Y < 0)
            ExtendTop(address);
        ExtendBottom(address);
    }

    private void ExtendTop(Coord3D address)
    {
        AddRows(-address.Y, GridAddMode.Prepend);
        StartCoord = new Coord3D(StartCoord.X, StartCoord.Y - address.Y, StartCoord.Z);
    }

    private void ExtendBottom(Coord3D address)
    {
        var extendBy = address.Y - (Height - 1);
        if (extendBy > 0)
            AddRows(extendBy, GridAddMode.Append);
    }

    private void ExtendZ(Coord3D address)
    {
        if (address.Z < 0)
            ExtendClose(address);
        ExtendFar(address);
    }

    private void ExtendClose(Coord3D address)
    {
        AddLevels(-address.Z, GridAddMode.Prepend);
        StartCoord = new Coord3D(StartCoord.X, StartCoord.Y, StartCoord.Z - address.Z);
    }

    private void ExtendFar(Coord3D address)
    {
        var extendBy = address.Z - (Depth - 1);
        if (extendBy > 0)
            AddLevels(extendBy, GridAddMode.Append);
    }

    public void ExtendAllDirections(int steps = 1)
    {
        AddCols(steps, GridAddMode.Prepend);
        AddCols(steps, GridAddMode.Append);
        AddRows(steps, GridAddMode.Prepend);
        AddRows(steps, GridAddMode.Append);
        AddLevels(steps, GridAddMode.Prepend);
        AddLevels(steps, GridAddMode.Append);
    }

    private void AddRows(int numberOfRows, GridAddMode addMode)
    {
        if (addMode == GridAddMode.Prepend)
            YMin -= numberOfRows;
        else
            YMax += numberOfRows;
    }

    private void AddCols(int numberOfCols, GridAddMode addMode)
    {
        if (addMode == GridAddMode.Prepend)
            XMin -= numberOfCols;
        else
            XMax += numberOfCols;
    }

    private void AddLevels(int numberOfLevels, GridAddMode addMode)
    {
        if (addMode == GridAddMode.Prepend)
            ZMin -= numberOfLevels;
        else
            ZMax += numberOfLevels;
    }

    public string Print(int z)
    {
        var sb = new StringBuilder();

        for (var y = YMin; y <= YMax; y++)
        {
            for (var x = XMin; x <= XMax; x++)
            {
                sb.Append(ReadValueAt(x, y, z));
            }

            if (y < YMax)
                sb.AppendLine();
        }

        return sb.ToString();
    }

    public void Clear() => _grid.Clear();
}