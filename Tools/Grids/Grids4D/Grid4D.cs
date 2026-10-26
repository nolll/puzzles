namespace Pzl.Tools.Grids.Grids4d;

public class Grid4D<T> where T : struct
{
    public T DefaultValue { get; }
    private readonly IDictionary<Coord4D, T> _grid = new Dictionary<Coord4D, T>();
    public Coord4D Coord { get; private set; }
    public Coord4D StartCoord { get; set; }

    public int Width => XMax - XMin + 1;
    public int Height => YMax - YMin + 1;
    public int Depth => ZMax - ZMin + 1;
    public int Duration => WMax - WMin + 1;
    public int XMin { get; private set; }
    public int XMax { get; private set; }
    public int YMin { get; private set; }
    public int YMax { get; private set; }
    public int ZMin { get; private set; }
    public int ZMax { get; private set; }
    public int WMin { get; private set; }
    public int WMax { get; private set; }
    public bool IsAtTop => Coord.Y == 0;
    public bool IsAtRightEdge => Coord.X == Width - 1;
    public bool IsAtBottom => Coord.Y == Height - 1;
    public bool IsAtLeftEdge => Coord.X == 0;
    public Coord4D Center => new(Width / 2, Height / 2, Depth / 2, Duration / 2);

    public Grid4D(int width = 1, int height = 1, int depth = 1, int duration = 1, T defaultValue = default)
        : this(
            new Coord4D(),
            new Coord4D(width - 1, height - 1, depth - 1, duration - 1),
            new Dictionary<Coord4D, T>(),
            defaultValue)
    {
        XMax = width - 1;
        YMax = height - 1;
        ZMax = depth - 1;
        WMax = duration - 1;
    }

    private Grid4D(T defaultValue)
    {
        DefaultValue = defaultValue;
        Coord = new Coord4D();
        StartCoord = new Coord4D();
    }

    private Grid4D(
        Coord4D min,
        Coord4D max,
        IDictionary<Coord4D, T> values,
        T defaultValue = default)
        : this(defaultValue)
    {
        _grid = values;
        XMin = min.X;
        XMax = max.X;
        YMin = min.Y;
        YMax = max.Y;
        ZMin = min.Z;
        ZMax = max.Z;
        WMin = min.W;
        WMax = max.W;
    }

    public IEnumerable<T> Values =>
        Coords.Select(coord => _grid.TryGetValue(coord, out var v)
            ? v
            : DefaultValue);

    public IEnumerable<Coord4D> Coords
    {
        get
        {
            for (var w = WMin; w <= WMax; w++)
            {
                for (var z = ZMin; z <= ZMax; z++)
                {
                    for (var y = YMin; y <= YMax; y++)
                    {
                        for (var x = XMin; x <= XMax; x++)
                        {
                            yield return new Coord4D(x, y, z, w);
                        }
                    }
                }
            }
        }
    }

    public bool TryMoveTo(Coord4D address) => MoveTo(address, false);
    public bool MoveTo(Coord4D address) => MoveTo(address, true);

    private bool MoveTo(Coord4D address, bool extend)
    {
        if (IsOutOfRange(address))
        {
            if (extend)
                ExtendGrid(address);
            else
                return false;
        }

        var x = address.X > 0 ? address.X : 0;
        var y = address.Y > 0 ? address.Y : 0;
        var z = address.Z > 0 ? address.Z : 0;
        var w = address.W > 0 ? address.W : 0;
        Coord = new Coord4D(x, y, z, w);
        return true;
    }

    public bool TryMoveTo(int x, int y, int z, int w) => MoveTo(new Coord4D(x, y, z, w), false);
    public bool MoveTo(int x, int y, int z, int w) => MoveTo(new Coord4D(x, y, z, w), true);
    public bool TryMoveUp(int steps = 1) => MoveUp(steps, false);
    public bool MoveUp(int steps = 1) => MoveUp(steps, true);
    private bool MoveUp(int steps, bool extend) => MoveTo(new Coord4D(Coord.X, Coord.Y - steps, Coord.Z, Coord.W), extend);
    public bool TryMoveRight(int steps = 1) => MoveRight(steps, false);
    public bool MoveRight(int steps = 1) => MoveRight(steps, true);
    private bool MoveRight(int steps, bool extend) => MoveTo(new Coord4D(Coord.X + steps, Coord.Y, Coord.Z, Coord.W), extend);
    public bool TryMoveDown(int steps = 1) => MoveDown(steps, false);
    public bool MoveDown(int steps = 1) => MoveDown(steps, true);
    private bool MoveDown(int steps, bool extend) => MoveTo(new Coord4D(Coord.X, Coord.Y + steps, Coord.Z, Coord.W), extend);
    public bool TryMoveLeft(int steps = 1) => MoveLeft(steps, false);
    public bool MoveLeft(int steps = 1) => MoveLeft(steps, true);
    private bool MoveLeft(int steps, bool extend) => MoveTo(new Coord4D(Coord.X - steps, Coord.Y, Coord.Z, Coord.W), extend);
    public T ReadValue() => ReadValueAt(Coord.X, Coord.Y, Coord.Z, Coord.W);
    public T ReadValueAt(int x, int y, int z, int w) => ReadValueAt(new Coord4D(x, y, z, w));

    public T ReadValueAt(Coord4D coord) => _grid.TryGetValue(coord, out var v)
        ? v
        : DefaultValue;

    public void WriteValue(T value) => WriteValueAt(Coord, value);

    public void WriteValueAt(Coord4D coord, T value)
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

        if (coord.W < WMin)
            WMin = coord.W;
        else if (coord.W > WMax)
            WMax = coord.W;

        if (value.Equals(DefaultValue))
            _grid.Remove(coord);
        else
            _grid[coord] = value;
    }

    public bool IsOutOfRange(Coord4D coord) =>
        coord.W > WMax ||
        coord.W < WMin ||
        coord.Z > ZMax ||
        coord.Z < ZMin ||
        coord.Y > YMax ||
        coord.Y < YMin ||
        coord.X > XMax ||
        coord.X < XMin;

    public IList<T> OrthogonalAdjacentValues => OrthogonalAdjacentCoords.Select(ReadValueAt).ToList();
    public IList<Coord4D> OrthogonalAdjacentCoords => PossibleOrthogonalAdjacentCoords.Where(o => !IsOutOfRange(o)).ToList();

    private IList<Coord4D> PossibleOrthogonalAdjacentCoords =>
    [
        new(Coord.X + 1, Coord.Y, Coord.Z, Coord.W),
        new(Coord.X - 1, Coord.Y, Coord.Z, Coord.W),
        new(Coord.X, Coord.Y + 1, Coord.Z, Coord.W),
        new(Coord.X, Coord.Y - 1, Coord.Z, Coord.W),
        new(Coord.X, Coord.Y, Coord.Z + 1, Coord.W),
        new(Coord.X, Coord.Y, Coord.Z - 1, Coord.W),
        new(Coord.X, Coord.Y, Coord.Z, Coord.W + 1),
        new(Coord.X, Coord.Y, Coord.Z, Coord.W - 1)
    ];

    public IList<T> AllAdjacentValues => AllAdjacentCoords.Select(ReadValueAt).ToList();
    public IList<T> AllAdjacentValuesTo(Coord4D coord) => AllAdjacentCoordsTo(coord).Select(ReadValueAt).ToList();
    public IList<Coord4D> AllAdjacentCoordsTo(Coord4D coord) => AllPossibleAdjacentCoordsTo(coord).Where(o => !IsOutOfRange(o)).ToList();
    public IList<Coord4D> AllAdjacentCoords => AllPossibleAdjacentCoords.Where(o => !IsOutOfRange(o)).ToList();

    private IEnumerable<Coord4D> AllPossibleAdjacentCoords => AllPossibleAdjacentCoordsTo(Coord);

    public IEnumerable<Coord4D> AllPossibleAdjacentCoordsTo(Coord4D coord)
    {
        foreach (var dw in GridConstants.AdjacentDeltas)
        {
            foreach (var dz in GridConstants.AdjacentDeltas)
            {
                foreach (var dy in GridConstants.AdjacentDeltas)
                {
                    foreach (var dx in GridConstants.AdjacentDeltas)
                    {
                        var newCoord = new Coord4D(coord.X + dx, coord.Y + dy, coord.Z + dz, coord.W + dw);
                        if (!newCoord.Equals(coord))
                            yield return newCoord;
                    }
                }
            }
        }
    }

    private void ExtendGrid(Coord4D coord)
    {
        ExtendX(coord);
        ExtendY(coord);
        ExtendZ(coord);
        ExtendW(coord);
    }

    private void ExtendX(Coord4D coord)
    {
        if (coord.X < 0)
            ExtendLeft(coord);
        ExtendRight(coord);
    }

    private void ExtendLeft(Coord4D coord)
    {
        AddCols(-coord.X, GridAddMode.Prepend);
        StartCoord = new Coord4D(StartCoord.X - coord.X, StartCoord.Y, StartCoord.Z, StartCoord.W);
    }

    private void ExtendRight(Coord4D coord)
    {
        var extendBy = coord.X - (Width - 1);
        if (extendBy > 0)
            AddCols(extendBy, GridAddMode.Append);
    }

    private void ExtendY(Coord4D coord)
    {
        if (coord.Y < 0)
            ExtendTop(coord);
        ExtendBottom(coord);
    }

    private void ExtendTop(Coord4D coord)
    {
        AddRows(-coord.Y, GridAddMode.Prepend);
        StartCoord = new Coord4D(StartCoord.X, StartCoord.Y - coord.Y, StartCoord.Z, StartCoord.W);
    }

    private void ExtendBottom(Coord4D coord)
    {
        var extendBy = coord.Y - (Height - 1);
        if (extendBy > 0)
            AddRows(extendBy, GridAddMode.Append);
    }

    private void ExtendZ(Coord4D coord)
    {
        if (coord.Z < 0)
            ExtendClose(coord);
        ExtendFar(coord);
    }

    private void ExtendClose(Coord4D coord)
    {
        AddLevels(-coord.Z, GridAddMode.Prepend);
        StartCoord = new Coord4D(StartCoord.X, StartCoord.Y, StartCoord.Z - coord.Z, StartCoord.W);
    }

    private void ExtendFar(Coord4D coord)
    {
        var extendBy = coord.Z - (Depth - 1);
        if (extendBy > 0)
            AddLevels(extendBy, GridAddMode.Append);
    }

    private void ExtendW(Coord4D coord)
    {
        if (coord.W < 0)
            ExtendNow(coord);
        ExtendThen(coord);
    }

    private void ExtendNow(Coord4D coord)
    {
        AddTime(-coord.W, GridAddMode.Prepend);
        StartCoord = new Coord4D(StartCoord.X, StartCoord.Y, StartCoord.Z, StartCoord.W - coord.W);
    }

    private void ExtendThen(Coord4D coord)
    {
        var extendBy = coord.W - (Duration - 1);
        if (extendBy > 0)
            AddTime(extendBy, GridAddMode.Append);
    }

    public void ExtendAllDirections(int steps = 1)
    {
        AddCols(steps, GridAddMode.Prepend);
        AddCols(steps, GridAddMode.Append);
        AddRows(steps, GridAddMode.Prepend);
        AddRows(steps, GridAddMode.Append);
        AddLevels(steps, GridAddMode.Prepend);
        AddLevels(steps, GridAddMode.Append);
        AddTime(steps, GridAddMode.Prepend);
        AddTime(steps, GridAddMode.Append);
    }

    private void AddRows(int count, GridAddMode addMode)
    {
        if (addMode == GridAddMode.Prepend)
            YMin -= count;
        else
            YMax += count;
    }

    private void AddCols(int count, GridAddMode addMode)
    {
        if (addMode == GridAddMode.Prepend)
            XMin -= count;
        else
            XMax += count;
    }

    private void AddLevels(int count, GridAddMode addMode)
    {
        if (addMode == GridAddMode.Prepend)
            ZMin -= count;
        else
            ZMax += count;
    }

    private void AddTime(int count, GridAddMode addMode)
    {
        if (addMode == GridAddMode.Prepend)
            WMin -= count;
        else
            WMax += count;
    }
}