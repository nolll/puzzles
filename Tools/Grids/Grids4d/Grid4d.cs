using System.Text;

namespace Pzl.Tools.Grids.Grids4d;

public class Grid4d<T> where T : struct
{
    private readonly T _defaultValue;
    private readonly IList<IList<IList<IList<T>>>> _grid;
    public Coord4d Address { get; private set; }
    public Coord4d StartAddress { get; set; }

    public IList<T> Values => _grid.SelectMany(x => x).SelectMany(x => x).SelectMany(x => x).ToList();
    public int Duration => _grid.Count;
    public int Depth => _grid.Any() ? _grid[0].Count : 0;
    public int Height => _grid.Any() && _grid[0].Any() ? _grid[0][0].Count : 0;
    public int Width => _grid.Any() && _grid[0].Any() && _grid[0][0].Any() ? _grid[0][0][0].Count : 0;
    public bool IsAtTop => Address.Y == 0;
    public bool IsAtRightEdge => Address.X == Width - 1;
    public bool IsAtBottom => Address.Y == Height - 1;
    public bool IsAtLeftEdge => Address.X == 0;
    public Coord4d Center => new(Width / 2, Height / 2, Depth / 2, Duration / 2);

    public Grid4d(int width = 1, int height = 1, int depth = 1, int duration = 1, T defaultValue = default)
    {
        _defaultValue = defaultValue;
        _grid = BuildGrid(width, height, depth, duration, defaultValue);
        Address = new Coord4d(0, 0, 0, 0);
        StartAddress = new Coord4d(0, 0, 0, 0);
    }

    public bool TryMoveTo(Coord4d address) => MoveTo(address, false);
    public bool MoveTo(Coord4d address) => MoveTo(address, true);

    private bool MoveTo(Coord4d address, bool extend)
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
        Address = new Coord4d(x, y, z, w);
        return true;
    }

    public bool TryMoveTo(int x, int y, int z, int w) => MoveTo(new Coord4d(x, y, z, w), false);
    public bool MoveTo(int x, int y, int z, int w) => MoveTo(new Coord4d(x, y, z, w), true);
    public bool TryMoveUp(int steps = 1) => MoveUp(steps, false);
    public bool MoveUp(int steps = 1) => MoveUp(steps, true);
    private bool MoveUp(int steps, bool extend) => MoveTo(new Coord4d(Address.X, Address.Y - steps, Address.Z, Address.W), extend);
    public bool TryMoveRight(int steps = 1) => MoveRight(steps, false);
    public bool MoveRight(int steps = 1) => MoveRight(steps, true);
    private bool MoveRight(int steps, bool extend) => MoveTo(new Coord4d(Address.X + steps, Address.Y, Address.Z, Address.W), extend);
    public bool TryMoveDown(int steps = 1) => MoveDown(steps, false);
    public bool MoveDown(int steps = 1) => MoveDown(steps, true);
    private bool MoveDown(int steps, bool extend) => MoveTo(new Coord4d(Address.X, Address.Y + steps, Address.Z, Address.W), extend);
    public bool TryMoveLeft(int steps = 1) => MoveLeft(steps, false);
    public bool MoveLeft(int steps = 1) => MoveLeft(steps, true);
    private bool MoveLeft(int steps, bool extend) => MoveTo(new Coord4d(Address.X - steps, Address.Y, Address.Z, Address.W), extend);
    public T ReadValue() => ReadValueAt(Address.X, Address.Y, Address.Z, Address.W);
    public T ReadValueAt(Coord4d address) => ReadValueAt(address.X, address.Y, address.Z, address.W);
    public T ReadValueAt(int x, int y, int z, int w) => _grid[w][z][y][x];
    public void WriteValue(T value) => _grid[Address.W][Address.Z][Address.Y][Address.X] = value;

    public bool IsOutOfRange(Coord4d address) =>
        address.W >= Duration ||
        address.W < 0 ||
        address.Z >= Depth ||
        address.Z < 0 ||
        address.Y >= Height ||
        address.Y < 0 ||
        address.X >= Width ||
        address.X < 0;

    public IList<T> OrthogonalAdjacentValues => OrthogonalAdjacentCoords.Select(ReadValueAt).ToList();
    public IList<Coord4d> OrthogonalAdjacentCoords => PossibleOrthogonalAdjacentCoords.Where(o => !IsOutOfRange(o)).ToList();

    private IList<Coord4d> PossibleOrthogonalAdjacentCoords =>
    [
        new(Address.X + 1, Address.Y, Address.Z, Address.W),
        new(Address.X - 1, Address.Y, Address.Z, Address.W),
        new(Address.X, Address.Y + 1, Address.Z, Address.W),
        new(Address.X, Address.Y - 1, Address.Z, Address.W),
        new(Address.X, Address.Y, Address.Z + 1, Address.W),
        new(Address.X, Address.Y, Address.Z - 1, Address.W),
        new(Address.X, Address.Y, Address.Z, Address.W + 1),
        new(Address.X, Address.Y, Address.Z, Address.W - 1)
    ];

    public IList<T> AllAdjacentValues => AllAdjacentCoords.Select(ReadValueAt).ToList();
    public IList<Coord4d> AllAdjacentCoords => AllPossibleAdjacentCoords.Where(o => !IsOutOfRange(o)).ToList();

    private IEnumerable<Coord4d> AllPossibleAdjacentCoords
    {
        get
        {
            foreach (var dw in GridConstants.AdjacentDeltas)
            {
                foreach (var dz in GridConstants.AdjacentDeltas)
                {
                    foreach (var dy in GridConstants.AdjacentDeltas)
                    {
                        foreach (var dx in GridConstants.AdjacentDeltas)
                        {
                            var coord = new Coord4d(Address.X + dx, Address.Y + dy, Address.Z + dz, Address.W + dw);
                            if(!coord.Equals(Address))
                                yield return coord;
                        }
                    }
                }
            }
        }
    }

    public Grid4d<T> Copy()
    {
        var grid = new Grid4d<T>();
        for (var w = 0; w < Duration; w++)
        {
            for (var z = 0; z < Depth; z++)
            {
                for (var y = 0; y < Height; y++)
                {
                    for (var x = 0; x < Width; x++)
                    {
                        grid.MoveTo(x, y, z, w);
                        grid.WriteValue(ReadValueAt(x, y, z, w));
                    }
                }
            }
        }

        grid.MoveTo(Address);
        return grid;
    }

    private IList<IList<IList<IList<T>>>> BuildGrid(int width, int height, int depth, int duration, T defaultValue)
    {
        var grid = new List<IList<IList<IList<T>>>>();
        for (var w = 0; w < duration; w++)
        {
            var time = new List<IList<IList<T>>>();
            for (var z = 0; z < depth; z++)
            {
                var level = new List<IList<T>>();
                for (var y = 0; y < height; y++)
                {
                    var row = new List<T>();
                    for (var x = 0; x < width; x++)
                    {
                        row.Add(defaultValue);
                    }

                    level.Add(row);
                }

                time.Add(level);
            }

            grid.Add(time);
        }

        return grid;
    }

    private void ExtendGrid(Coord4d address)
    {
        ExtendX(address);
        ExtendY(address);
        ExtendZ(address);
        ExtendW(address);
    }

    private void ExtendX(Coord4d address)
    {
        if (address.X < 0)
            ExtendLeft(address);
        ExtendRight(address);
    }

    private void ExtendLeft(Coord4d address)
    {
        AddCols(-address.X, GridAddMode.Prepend);
        StartAddress = new Coord4d(StartAddress.X - address.X, StartAddress.Y, StartAddress.Z, StartAddress.W);
    }

    private void ExtendRight(Coord4d address)
    {
        var extendBy = address.X - (Width - 1);
        if (extendBy > 0)
            AddCols(extendBy, GridAddMode.Append);
    }

    private void ExtendY(Coord4d address)
    {
        if (address.Y < 0)
            ExtendTop(address);
        ExtendBottom(address);
    }

    private void ExtendTop(Coord4d address)
    {
        AddRows(-address.Y, GridAddMode.Prepend);
        StartAddress = new Coord4d(StartAddress.X, StartAddress.Y - address.Y, StartAddress.Z, StartAddress.W);
    }

    private void ExtendBottom(Coord4d address)
    {
        var extendBy = address.Y - (Height - 1);
        if (extendBy > 0)
            AddRows(extendBy, GridAddMode.Append);
    }

    private void ExtendZ(Coord4d address)
    {
        if (address.Z < 0)
            ExtendClose(address);
        ExtendFar(address);
    }

    private void ExtendClose(Coord4d address)
    {
        AddLevels(-address.Z, GridAddMode.Prepend);
        StartAddress = new Coord4d(StartAddress.X, StartAddress.Y, StartAddress.Z - address.Z, StartAddress.W);
    }

    private void ExtendFar(Coord4d address)
    {
        var extendBy = address.Z - (Depth - 1);
        if (extendBy > 0)
            AddLevels(extendBy, GridAddMode.Append);
    }

    private void ExtendW(Coord4d address)
    {
        if (address.W < 0)
            ExtendNow(address);
        ExtendThen(address);
    }

    private void ExtendNow(Coord4d address)
    {
        AddTime(-address.W, GridAddMode.Prepend);
        StartAddress = new Coord4d(StartAddress.X, StartAddress.Y, StartAddress.Z, StartAddress.W - address.W);
    }

    private void ExtendThen(Coord4d address)
    {
        var extendBy = address.W - (Duration - 1);
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
        var width = Width;
        var depth = Depth;
        var duration = Duration;
        for (var w = 0; w < duration; w++)
        {
            var time = _grid[w];
            for (var z = 0; z < depth; z++)
            {
                var level = time[z];
                for (var y = 0; y < count; y++)
                {
                    var row = new List<T>();
                    for (var x = 0; x < width; x++)
                    {
                        row.Add(_defaultValue);
                    }

                    if (addMode == GridAddMode.Prepend)
                        level.Insert(0, row);
                    else
                        level.Add(row);

                }
            }
        }
    }

    private void AddCols(int count, GridAddMode addMode)
    {
        var height = Height;
        var depth = Depth;
        var duration = Duration;
        for (var w = 0; w < duration; w++)
        {
            var time = _grid[w];
            for (var z = 0; z < depth; z++)
            {
                var level = time[z];
                for (var y = 0; y < height; y++)
                {
                    var row = level[y];
                    for (var x = 0; x < count; x++)
                    {
                        if (addMode == GridAddMode.Prepend)
                            row.Insert(0, _defaultValue);
                        else
                            row.Add(_defaultValue);
                    }
                }
            }
        }
    }

    private void AddLevels(int count, GridAddMode addMode)
    {
        var height = Height;
        var width = Width;
        var duration = Duration;
        for (var w = 0; w < duration; w++)
        {
            var time = _grid[w];
            for (var z = 0; z < count; z++)
            {
                var level = new List<IList<T>>();
                for (var y = 0; y < height; y++)
                {
                    var row = new List<T>();
                    for (var x = 0; x < width; x++)
                    {
                        row.Add(_defaultValue);
                    }

                    level.Add(row);
                }

                if (addMode == GridAddMode.Prepend)
                    time.Insert(0, level);
                else
                    time.Add(level);
                    
            }
        }
    }

    private void AddTime(int count, GridAddMode addMode)
    {
        var height = Height;
        var width = Width;
        var depth = Depth;
        for (var w = 0; w < count; w++)
        {
            var time = new List<IList<IList<T>>>();
            for (var z = 0; z < depth; z++)
            {
                var level = new List<IList<T>>();
                for (var y = 0; y < height; y++)
                {
                    var row = new List<T>();
                    for (var x = 0; x < width; x++)
                    {
                        row.Add(_defaultValue);
                    }
                    level.Add(row);
                }
                time.Add(level);
            }

            if(addMode == GridAddMode.Prepend)
                _grid.Insert(0, time);
            else
                _grid.Add(time);
        }
    }

    public string PrintLevel(int time, int level)
    {
        var sb = new StringBuilder();
        foreach (var row in _grid[time][level])
        {
            foreach (var o in row)
            {
                sb.Append(o);
            }

            sb.AppendLine();
        }

        return sb.ToString().Trim();
    }
}