using System.Text;

namespace Pzl.Tools.Grids.Grids2d;

public class Grid<T> where T : struct
{
    private readonly IDictionary<Coord, T> _grid = new Dictionary<Coord, T>();

    public T DefaultValue { get; }
    
    public int Width => XMax - XMin + 1;
    public int Height => YMax - YMin + 1;
    public int XMin { get; private set; }
    public int XMax { get; private set; }
    public int YMin { get; private set; }
    public int YMax { get; private set; }

    public GridDirection Direction { get; private set; }
    public Coord Coord { get; private set; }
    public Coord StartCoord { get; }
    public bool IsAtTopEdge() => IsAtTopEdge(Coord);
    public bool IsAtTopEdge(Coord coord) => coord.Y == YMin;
    public bool IsAtRightEdge() => IsAtRightEdge(Coord);
    public bool IsAtRightEdge(Coord coord) => coord.X == XMax;
    public bool IsAtBottomEdge() => IsAtBottomEdge(Coord);
    public bool IsAtBottomEdge(Coord coord) => coord.Y == YMax;
    public bool IsAtLeftEdge() => IsAtLeftEdge(Coord);
    public bool IsAtLeftEdge(Coord coord) => coord.X == XMin;
    public bool IsAtEdge() => IsAtEdge(Coord);
    public bool IsAtEdge(Coord coord) => IsAtTopEdge(coord) || IsAtRightEdge(coord) || IsAtBottomEdge(coord) || IsAtLeftEdge(coord);
    
    public Coord Center
    {
        get
        {
            var xDiff = Math.Abs(XMax - XMin);
            var yDiff = Math.Abs(YMax - YMin);
            return new(XMax - xDiff / 2, YMax - yDiff / 2);
        }
    }

    public Grid(int width = 1, int height = 1, T defaultValue = default)
        : this(
            new Coord(0, 0), 
            new Coord(width - 1, height - 1),
            new Dictionary<Coord, T>(), 
            defaultValue)
    {
        XMax = width - 1;
        YMax = height - 1;
    }

    private Grid(T defaultValue)
    {
        DefaultValue = defaultValue;
        Coord = new Coord();
        StartCoord = new Coord();
        Direction = GridDirection.Up;
    }

    private Grid(
        Coord min, 
        Coord max, 
        IDictionary<Coord, T> values, 
        T defaultValue = default)
        : this(defaultValue)
    {
        _grid = values;
        XMin = min.X;
        XMax = max.X;
        YMin = min.Y;
        YMax = max.Y;
    }

    public IEnumerable<T> Values => Coords.Select(coord => _grid.TryGetValue(coord, out var v)
        ? v
        : DefaultValue);

    public IEnumerable<Coord> Coords
    {
        get
        {
            for (var y = YMin; y <= YMax; y++)
            {
                for (var x = XMin; x <= XMax; x++)
                {
                    yield return new Coord(x, y);
                }
            }
        }
    }
    
    public Coord? CoordOf(T value)
    {
        foreach (var key in _grid.Keys)
        {
            if (_grid[key].Equals(value))
                return Coord;
        }

        return null;
    }
    
    public IEnumerable<Coord> CoordsOf(T value)
    {
        foreach (var key in _grid.Keys)
        {
            if (_grid[key].Equals(value))
                yield return key;
        }
    }

    public IEnumerable<Coord> CoordsWithSavedValue => _grid.Keys;

    public T ReadValue() => ReadValueAt(Coord);
    public T ReadValueAt(int x, int y) => ReadValueAt(new Coord(x, y));

    public T ReadValueAt(Coord coord) => _grid.TryGetValue(coord, out var v)
        ? v
        : DefaultValue;

    public void WriteValue(T value) => WriteValueAt(Coord, value);
    public void WriteValueAt(int x, int y, T value) => WriteValueAt(new Coord(x, y), value);

    public void WriteValueAt(Coord coord, T value)
    {
        if (coord.X < XMin)
            XMin = coord.X;
        else if (coord.X > XMax)
            XMax = coord.X;

        if (coord.Y < YMin)
            YMin = coord.Y;
        else if (coord.Y > YMax)
            YMax = coord.Y;

        if (value.Equals(DefaultValue))
            _grid.Remove(coord);
        else
            _grid[coord] = value;
    }

    public void WriteValueAt(IEnumerable<Coord> coords, T value)
    {
        foreach (var coord in coords)
            WriteValueAt(coord, value);
    }
    
    public void ClearValueAt(Coord coord) => _grid.Remove(coord);

    public IEnumerable<T> ReadRowValues(int y)
    {
        for (var x = XMin; x <= XMax; x++)
        {
            yield return ReadValueAt(x, y);
        }
    }
    
    public IEnumerable<T> ReadColValues(int x)
    {
        for (var y = YMin; y <= YMax; y++)    
        {
            yield return ReadValueAt(x, y);
        }
    }

    public IList<T> OrthogonalAdjacentValues => OrthogonalAdjacentCoords.Select(ReadValueAt).ToList();
    public IList<T> OrthogonalAdjacentValuesTo(Coord coord) => OrthogonalAdjacentCoordsTo(coord).Select(ReadValueAt).ToList();
    public IList<Coord> OrthogonalAdjacentCoords => OrthogonalAdjacentCoordsTo(Coord);
    public IList<Coord> OrthogonalAdjacentCoordsTo(Coord coord) => PossibleOrthogonalAdjacentCoordsTo(coord).Where(o => !IsOutOfRange(o)).ToList();

    public IEnumerable<Coord> PossibleOrthogonalAdjacentCoords => PossibleOrthogonalAdjacentCoordsTo(Coord);
    public static IEnumerable<Coord> PossibleOrthogonalAdjacentCoordsTo(Coord coord) => coord.OrthogonalAdjacent();
    public IList<T> DiagonalAdjacentValues => DiagonalAdjacentCoords.Select(ReadValueAt).ToList();
    public IList<T> DiagonalAdjacentValuesTo(Coord coord) => DiagonalAdjacentCoordsTo(coord).Select(ReadValueAt).ToList();
    public IList<Coord> DiagonalAdjacentCoords => DiagonalAdjacentCoordsTo(Coord);
    public IList<Coord> DiagonalAdjacentCoordsTo(Coord coord) => PossibleDiagonalAdjacentCoordsTo(coord).Where(o => !IsOutOfRange(o)).ToList();
    public IEnumerable<Coord> PossibleDiagonalAdjacentCoords => PossibleDiagonalAdjacentCoordsTo(Coord);
    public IEnumerable<Coord> PossibleDiagonalAdjacentCoordsTo(Coord coord) => coord.DiagonalAdjacent();
    public IList<T> AllAdjacentValues => AllAdjacentCoordsTo(Coord).Select(ReadValueAt).ToList();
    public IList<T> AllAdjacentValuesTo(Coord coord) => AllAdjacentCoordsTo(coord).Select(ReadValueAt).ToList();
    public IList<Coord> AllAdjacentCoords => AllAdjacentCoordsTo(Coord);
    public IList<Coord> AllAdjacentCoordsTo(Coord coord) => AllPossibleAdjacentCoordsTo(coord).Where(o => !IsOutOfRange(o)).ToList();
    private IEnumerable<Coord> AllPossibleAdjacentCoordsTo(Coord coord) => coord.AllAdjacent();

    public bool MoveTo(Coord coord) => MoveTo(coord, true);
    public bool MoveTo(int x, int y) => MoveTo(new Coord(x, y), true);
    public bool TryMoveTo(Coord coord) => MoveTo(coord, false);
    public bool TryMoveTo(int x, int y) => MoveTo(new Coord(x, y), false);
    public bool MoveForward(int steps = 1) => MoveForward(steps, true);
    private bool MoveForward(int steps, bool extend) => MoveTo(Coord.Forward(Direction, steps), extend);
    public bool TryMoveForward() => MoveForward(1, false);
    public bool MoveBackward() => MoveBackward(true);
    private bool MoveBackward(bool extend) => MoveTo(Coord.Backward(Direction), extend);
    public bool TryMoveBackward() => MoveBackward(false);
    public bool MoveUp(int steps = 1) => MoveUp(steps, true);
    private bool MoveUp(int steps, bool extend) => MoveTo(Coord.Up(steps), extend);
    public bool TryMoveUp(int steps = 1) => MoveUp(steps, false);
    public bool MoveRight(int steps = 1) => MoveRight(steps, true);
    private bool MoveRight(int steps, bool extend) => MoveTo(Coord.Right(steps), extend);
    public bool TryMoveRight(int steps = 1) => MoveRight(steps, false);
    public bool MoveDown(int steps = 1) => MoveDown(steps, true);
    private bool MoveDown(int steps, bool extend) => MoveTo(Coord.Down(steps), extend);
    public bool TryMoveDown(int steps = 1) => MoveDown(steps, false);
    public bool MoveLeft(int steps = 1) => MoveLeft(steps, true);
    private bool MoveLeft(int steps, bool extend) => MoveTo(Coord.Left(steps), extend);
    public bool TryMoveLeft(int steps = 1) => MoveLeft(steps, false);
    public bool Move(GridDirection dir, int steps = 1) => Move(dir, steps, true);
    private bool Move(GridDirection dir, int steps, bool extend) => MoveTo(Coord.Direction(dir, steps), extend);
    public bool TryMove(GridDirection dir, int steps = 1) => Move(dir, steps, false);

    public bool MoveTo(Coord coord, bool extend)
    {
        if (IsOutOfRange(coord))
        {
            if (extend)
                ExtendGrid(coord);
            else
                return false;
        }

        var x = coord.X > XMin ? coord.X : XMin;
        var y = coord.Y > YMin ? coord.Y : YMin;
        Coord = new Coord(x, y);
        return true;
    }

    public GridDirection TurnLeft() => TurnTo(Direction.TurnLeft());
    public GridDirection TurnLeft(int degrees) => Turn(TurnLeft, degrees);
    public GridDirection TurnRight() => TurnTo(Direction.TurnRight());
    public GridDirection TurnRight(int degrees) => Turn(TurnRight, degrees);

    private GridDirection Turn(Func<GridDirection> turnFunc, int degrees)
    {
        for (var i = 0; i < degrees / 90; i++) 
            turnFunc();

        return Direction;
    }

    public GridDirection TurnTo(GridDirection direction)
    {
        Direction = direction;
        return direction;
    }

    public GridDirection FaceUp() => TurnTo(GridDirection.Up);
    public GridDirection FaceRight() => TurnTo(GridDirection.Right);
    public GridDirection FaceDown() => TurnTo(GridDirection.Down);
    public GridDirection FaceLeft() => TurnTo(GridDirection.Left);

    private void ExtendGrid(Coord coord)
    {
        ExtendX(coord);
        ExtendY(coord);
    }

    private void ExtendX(Coord coord)
    {
        if (coord.X < XMin)
            ExtendLeft(coord);
        else
            ExtendRight(coord);
    }

    private void ExtendLeft(Coord coord) => AddCols(XMin - coord.X, GridAddMode.Prepend);

    private void ExtendRight(Coord coord)
    {
        var extendBy = coord.X - XMax;
        if (extendBy > 0)
            AddCols(extendBy, GridAddMode.Append);
    }

    private void ExtendY(Coord coord)
    {
        if (coord.Y < YMin)
            ExtendTop(coord);
        else
            ExtendBottom(coord);
    }

    private void ExtendTop(Coord coord) => AddRows(YMin - coord.Y, GridAddMode.Prepend);

    private void ExtendBottom(Coord coord)
    {
        var extendBy = coord.Y - YMax;
        if (extendBy > 0)
            AddRows(extendBy, GridAddMode.Append);
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

    public void ExtendAllDirections(int steps = 1)
    {
        ExtendUp(steps);
        ExtendRight(steps);
        ExtendDown(steps);
        ExtendLeft(steps);
    }

    public void ExtendUp(int steps = 1) => AddRows(steps, GridAddMode.Prepend);
    public void ExtendRight(int steps = 1) => AddCols(steps, GridAddMode.Append);
    public void ExtendDown(int steps = 1) => AddRows(steps, GridAddMode.Append);
    public void ExtendLeft(int steps = 1) => AddCols(steps, GridAddMode.Prepend);

    public string Print(bool markCurrentCoord = false, bool markStartCoord = false, T currentCoordMarker = default, T startCoordMarker = default, bool spacing = false)
    {
        var sb = new StringBuilder();

        for (var y = YMin; y <= YMax; y++)
        {
            for (var x = XMin; x <= XMax; x++)
            {
                if (markCurrentCoord && x == Coord.X && y == Coord.Y)
                    sb.Append('D');
                else if (markStartCoord && x == StartCoord.X && y == StartCoord.Y)
                    sb.Append('S');
                else
                    sb.Append(ReadValueAt(x, y));

                if (spacing)
                    sb.Append('.');
            }

            if(y < YMax)
                sb.AppendLine();
        }

        return sb.ToString();
    }

    public IList<Coord> FindCoords(T value)
    {
        var coords = new List<Coord>();
        for (var y = YMin; y <= YMax; y++)
        {
            for (var x = XMin; x <= XMax; x++)
            {
                var coord = new Coord(x, y);
                var val = ReadValueAt(coord);
                if (val.Equals(value))
                    coords.Add(coord);
            }
        }

        return coords;
    }

    public bool IsOutOfRange(Coord coord) =>
        coord.Y > YMax ||
        coord.Y < YMin ||
        coord.X > XMax ||
        coord.X < XMin;

    public Grid<T> Clone(int multiplier = 1)
    {
        multiplier = multiplier < 1 ? 1 : multiplier;

        var values = GetValuesForClone(multiplier);
        var min = new Coord(XMin, YMin);
        var max = GetMaxCoordForClone(multiplier);
        return new Grid<T>(min, max, values, DefaultValue);
    }

    private Dictionary<Coord, T> GetValuesForClone(int multiplier)
    {
        var values = _grid.ToDictionary(item => item.Key, item => item.Value);

        if (multiplier == 1)
            return values;

        var extendedValues = new Dictionary<Coord, T>();

        for (var xm = 0; xm < multiplier; xm++)
        {
            for (var ym = 0; ym < multiplier; ym++)
            {
                foreach (var (coord, value) in values)
                {
                    extendedValues.Add(new Coord(coord.X + xm * Width, coord.Y + ym * Height), value);
                }
            }
        }

        return extendedValues;
    }

    private Coord GetMaxCoordForClone(int multiplier) => 
        new(XMax + Width * (multiplier - 1), YMax + Height * (multiplier - 1));

    public Grid<T> RotateLeft()
    {
        var values = _grid.ToDictionary(item => new Coord(item.Key.Y, YMax - item.Key.X), item => item.Value);
        var min = new Coord(YMin, YMin);
        var max = new Coord(XMax, YMax);
        return new Grid<T>(min, max, values, DefaultValue);
    }

    public Grid<T> RotateRight()
    {
        var values = _grid.ToDictionary(item => new Coord(XMax - item.Key.Y, item.Key.X), item => item.Value);
        var min = new Coord(YMin, YMin);
        var max = new Coord(XMax, YMax);
        return new Grid<T>(min, max, values, DefaultValue);
    }

    public Grid<T> Slice(Coord? from = null, Coord? to = null)
    {
        from ??= new Coord(XMin, YMin);
        to ??= new Coord(XMax, YMax);
        var dx = from.X;
        var dy = from.Y;
        var values = _grid
            .Where(item => item.Key.X >= from.X && item.Key.Y >= from.Y && item.Key.X <= to.X && item.Key.Y <= to.Y)
            .ToDictionary(item => new Coord(item.Key.X - dx, item.Key.Y - dy), item => item.Value);
        var slicedFrom = new Coord(from.X - dx, from.Y - dy);
        var slicedTo = new Coord(to.X - dx, to.Y - dy);
        return new Grid<T>(slicedFrom, slicedTo, values, DefaultValue);
    }

    public Grid<T> Slice(Coord from, int size) => Slice(from, size, size);

    public Grid<T> Slice(Coord from, int width, int height) => 
        Slice(from, new Coord(from.X + width - 1, from.Y + height - 1));

    public Grid<T> FlipVertical()
    {
        var values = _grid.ToDictionary(item => new Coord(item.Key.X, YMax - item.Key.Y), item => item.Value);
        var min = new Coord(XMin, YMin);
        var max = new Coord(XMax, YMax);
        return new Grid<T>(min, max, values, DefaultValue);
    }

    public Grid<T> FlipHorizontal()
    {
        var values = _grid.ToDictionary(item => new Coord(XMax - item.Key.X, item.Key.Y), item => item.Value);
        var min = new Coord(XMin, YMin);
        var max = new Coord(XMax, YMax);
        return new Grid<T>(min, max, values, DefaultValue);
    }

    public Grid<T> Transpose()
    {
        var values = _grid.ToDictionary(item => new Coord(item.Key.Y, item.Key.X), item => item.Value);
        var min = new Coord(YMin, XMin);
        var max = new Coord(YMax, XMax);
        return new Grid<T>(min, max, values, DefaultValue);
    }
}
