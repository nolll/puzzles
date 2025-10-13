using System.Text;

namespace Pzl.Tools.Grids.Grids2d;

public class Grid<T> where T : struct
{
    private readonly IDictionary<Coord, T> _matrix = new Dictionary<Coord, T>();

    public T DefaultValue { get; }
    
    public int Width => XMax - XMin + 1;
    public int Height => YMax - YMin + 1;
    public int XMin { get; private set; }
    public int XMax { get; private set; }
    public int YMin { get; private set; }
    public int YMax { get; private set; }

    public GridDirection Direction { get; private set; }
    public Coord Address { get; private set; }
    public Coord StartAddress { get; }
    public bool IsAtTopEdge => Address.Y == YMin;
    public bool IsAtRightEdge => Address.X == XMax;
    public bool IsAtBottomEdge => Address.Y == YMax;
    public bool IsAtLeftEdge => Address.X == XMin;
    public bool IsAtEdge => IsAtTopEdge || IsAtRightEdge || IsAtBottomEdge || IsAtLeftEdge;
    
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
        Address = new Coord(0, 0);
        StartAddress = new Coord(0, 0);
        Direction = GridDirection.Up;
    }

    private Grid(
        Coord min, 
        Coord max, 
        IDictionary<Coord, T> values, 
        T defaultValue = default)
        : this(defaultValue)
    {
        _matrix = values;
        XMin = min.X;
        XMax = max.X;
        YMin = min.Y;
        YMax = max.Y;
    }

    public IEnumerable<T> Values =>
        Coords.Select(coord => _matrix.TryGetValue(coord, out var v) 
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

    public T ReadValue() => ReadValueAt(Address);
    public T ReadValueAt(int x, int y) => ReadValueAt(new Coord(x, y));

    public T ReadValueAt(Coord coord) => _matrix.TryGetValue(coord, out var v)
        ? v
        : DefaultValue;

    public void WriteValue(T value) => WriteValueAt(Address, value);
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
        
        _matrix[coord] = value;
    }
    
    public void ClearValueAt(Coord coord) => _matrix.Remove(coord);

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
    public IList<T> OrthogonalAdjacentValuesTo(Coord address) => OrthogonalAdjacentCoordsTo(address).Select(ReadValueAt).ToList();
    public IList<Coord> OrthogonalAdjacentCoords => OrthogonalAdjacentCoordsTo(Address);
    public IList<Coord> OrthogonalAdjacentCoordsTo(Coord address) => PossibleOrthogonalAdjacentCoordsTo(address).Where(o => !IsOutOfRange(o)).ToList();

    public IEnumerable<Coord> PossibleOrthogonalAdjacentCoords => PossibleOrthogonalAdjacentCoordsTo(Address);
    public IEnumerable<Coord> PossibleOrthogonalAdjacentCoordsTo(Coord address) => 
        MatrixConstants.OrthogonalDirections.Select(dir => new Coord(address.X + dir.x, address.Y + dir.y));

    public IList<T> AllAdjacentValues => AllAdjacentCoordsTo(Address).Select(ReadValueAt).ToList();
    public IList<T> AllAdjacentValuesTo(Coord address) => AllAdjacentCoordsTo(address).Select(ReadValueAt).ToList();
    public IList<Coord> AllAdjacentCoords => AllAdjacentCoordsTo(Address);
    public IList<Coord> AllAdjacentCoordsTo(Coord address) => AllPossibleAdjacentCoordsTo(address).Where(o => !IsOutOfRange(o)).ToList();

    private IEnumerable<Coord> AllPossibleAdjacentCoordsTo(Coord address)
    {
        foreach (var dy in MatrixConstants.AdjacentDeltas)
        {
            foreach (var dx in MatrixConstants.AdjacentDeltas)
            {
                var coord = new Coord(address.X + dx, address.Y + dy);
                if (!coord.Equals(address))
                    yield return coord;
            }
        }
    }

    public bool MoveTo(Coord address) => MoveTo(address, true);
    public bool MoveTo(int x, int y) => MoveTo(new Coord(x, y), true);
    public bool TryMoveTo(Coord address) => MoveTo(address, false);
    public bool TryMoveTo(int x, int y) => MoveTo(new Coord(x, y), false);
    public bool MoveForward() => MoveForward(true);
    private bool MoveForward(bool extend) => MoveTo(new Coord(Address.X + Direction.X, Address.Y + Direction.Y), extend);
    public bool TryMoveForward() => MoveForward(false);
    public bool MoveBackward() => MoveBackward(true);
    private bool MoveBackward(bool extend) => MoveTo(new Coord(Address.X - Direction.X, Address.Y - Direction.Y), extend);
    public bool TryMoveBackward() => MoveBackward(false);
    public bool MoveUp(int steps = 1) => MoveUp(steps, true);
    private bool MoveUp(int steps, bool extend) => MoveTo(new Coord(Address.X, Address.Y - steps), extend);
    public bool TryMoveUp(int steps = 1) => MoveUp(steps, false);
    public bool MoveRight(int steps = 1) => MoveRight(steps, true);
    private bool MoveRight(int steps, bool extend) => MoveTo(new Coord(Address.X + steps, Address.Y), extend);
    public bool TryMoveRight(int steps = 1) => MoveRight(steps, false);
    public bool MoveDown(int steps = 1) => MoveDown(steps, true);
    private bool MoveDown(int steps, bool extend) => MoveTo(new Coord(Address.X, Address.Y + steps), extend);
    public bool TryMoveDown(int steps = 1) => MoveDown(steps, false);
    public bool MoveLeft(int steps = 1) => MoveLeft(steps, true);
    private bool MoveLeft(int steps, bool extend) => MoveTo(new Coord(Address.X - steps, Address.Y), extend);
    public bool TryMoveLeft(int steps = 1) => MoveLeft(steps, false);
    public bool Move(GridDirection dir, int steps = 1) => Move(dir, steps, true);
    private bool Move(GridDirection dir, int steps, bool extend) => MoveTo(new Coord(Address.X + dir.X, Address.Y + dir.Y), extend);
    public bool TryMove(GridDirection dir, int steps = 1) => Move(dir, steps, false);

    public bool MoveTo(Coord address, bool extend)
    {
        if (IsOutOfRange(address))
        {
            if (extend)
                ExtendMatrix(address);
            else
                return false;
        }

        var x = address.X > XMin ? address.X : XMin;
        var y = address.Y > YMin ? address.Y : YMin;
        Address = new Coord(x, y);
        return true;
    }

    public GridDirection TurnLeft()
    {
        if (Direction.Equals(GridDirection.Up))
            return TurnTo(GridDirection.Left);
        if (Direction.Equals(GridDirection.Right))
            return TurnTo(GridDirection.Up);
        if (Direction.Equals(GridDirection.Down))
            return TurnTo(GridDirection.Right);
        return TurnTo(GridDirection.Down);
    }

    public GridDirection TurnRight()
    {
        if (Direction.Equals(GridDirection.Up))
            return TurnTo(GridDirection.Right);
        if (Direction.Equals(GridDirection.Right))
            return TurnTo(GridDirection.Down);
        if (Direction.Equals(GridDirection.Down))
            return TurnTo(GridDirection.Left);
        return TurnTo(GridDirection.Up);
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

    private void ExtendMatrix(Coord address)
    {
        ExtendX(address);
        ExtendY(address);
    }

    private void ExtendX(Coord address)
    {
        if (address.X < XMin)
            ExtendLeft(address);
        ExtendRight(address);
    }

    private void ExtendLeft(Coord address) => AddCols(-address.X, MatrixAddMode.Prepend);

    private void ExtendRight(Coord address)
    {
        var extendBy = address.X - XMax;
        if (extendBy > 0)
            AddCols(extendBy, MatrixAddMode.Append);
    }

    private void ExtendY(Coord address)
    {
        if (address.Y < YMin)
            ExtendTop(address);
        ExtendBottom(address);
    }

    private void ExtendTop(Coord address) => AddRows(-address.Y, MatrixAddMode.Prepend);

    private void ExtendBottom(Coord address)
    {
        var extendBy = address.Y - YMax;
        if (extendBy > 0)
            AddRows(extendBy, MatrixAddMode.Append);
    }

    private void AddRows(int numberOfRows, MatrixAddMode addMode)
    {
        if (addMode == MatrixAddMode.Prepend)
            YMin -= numberOfRows;
        else
            YMax += numberOfRows;
    }

    private void AddCols(int numberOfCols, MatrixAddMode addMode)
    {
        if (addMode == MatrixAddMode.Prepend)
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

    public void ExtendUp(int steps = 1) => AddRows(steps, MatrixAddMode.Prepend);
    public void ExtendRight(int steps = 1) => AddCols(steps, MatrixAddMode.Append);
    public void ExtendDown(int steps = 1) => AddRows(steps, MatrixAddMode.Append);
    public void ExtendLeft(int steps = 1) => AddCols(steps, MatrixAddMode.Prepend);

    public string Print(bool markCurrentAddress = false, bool markStartAddress = false, T currentAddressMarker = default, T startAddressMarker = default, bool spacing = false)
    {
        var sb = new StringBuilder();

        for (var y = YMin; y <= YMax; y++)
        {
            for (var x = XMin; x <= XMax; x++)
            {
                if (markCurrentAddress && x == Address.X && y == Address.Y)
                    sb.Append('D');
                else if (markStartAddress && x == StartAddress.X && y == StartAddress.Y)
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

    public IList<Coord> FindAddresses(T value)
    {
        var addresses = new List<Coord>();
        for (var y = YMin; y <= YMax; y++)
        {
            for (var x = XMin; x <= XMax; x++)
            {
                var address = new Coord(x, y);
                var val = ReadValueAt(address);
                if (val.Equals(value))
                    addresses.Add(address);
            }
        }

        return addresses;
    }

    public bool IsOutOfRange(Coord address) =>
        address.Y > YMax ||
        address.Y < YMin ||
        address.X > XMax ||
        address.X < XMin;

    public Grid<T> Clone(int multiplier = 1)
    {
        multiplier = multiplier < 1 ? 1 : multiplier;

        var values = GetValuesForClone(multiplier);
        var min = new Coord(XMin, YMin);
        var max = GetMaxAddressForClone(multiplier);
        return new Grid<T>(min, max, values, DefaultValue);
    }

    private Dictionary<Coord, T> GetValuesForClone(int multiplier)
    {
        var values = _matrix.ToDictionary(item => item.Key, item => item.Value);

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

    private Coord GetMaxAddressForClone(int multiplier) => 
        new(XMax + Width * (multiplier - 1), YMax + Height * (multiplier - 1));

    public Grid<T> RotateLeft()
    {
        var values = _matrix.ToDictionary(item => new Coord(item.Key.Y, YMax - item.Key.X), item => item.Value);
        var min = new Coord(YMin, YMin);
        var max = new Coord(XMax, YMax);
        return new Grid<T>(min, max, values, DefaultValue);
    }

    public Grid<T> RotateRight()
    {
        var values = _matrix.ToDictionary(item => new Coord(XMax - item.Key.Y, item.Key.X), item => item.Value);
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
        var values = _matrix
            .Where(item => item.Key.X >= from.X && item.Key.Y >= from.Y && item.Key.X <= to.X && item.Key.Y <= to.Y)
            .ToDictionary(item => new Coord(item.Key.X - dx, item.Key.Y - dy), item => item.Value);
        var slicedFrom = new Coord(from.X - dx, from.Y - dy);
        var slicedTo = new Coord(to.X - dx, to.Y - dy);
        return new Grid<T>(slicedFrom, slicedTo, values, DefaultValue);
    }

    public Grid<T> Slice(Coord from, int size) => 
        Slice(from, size, size);

    public Grid<T> Slice(Coord from, int width, int height) => 
        Slice(from, new Coord(from.X + width - 1, from.Y + height - 1));

    public Grid<T> FlipVertical()
    {
        var values = _matrix.ToDictionary(item => new Coord(item.Key.X, YMax - item.Key.Y), item => item.Value);
        var min = new Coord(XMin, YMin);
        var max = new Coord(XMax, YMax);
        return new Grid<T>(min, max, values, DefaultValue);
    }

    public Grid<T> FlipHorizontal()
    {
        var values = _matrix.ToDictionary(item => new Coord(XMax - item.Key.X, item.Key.Y), item => item.Value);
        var min = new Coord(XMin, YMin);
        var max = new Coord(XMax, YMax);
        return new Grid<T>(min, max, values, DefaultValue);
    }

    public Grid<T> Transpose()
    {
        var values = _matrix.ToDictionary(item => new Coord(item.Key.Y, item.Key.X), item => item.Value);
        var min = new Coord(YMin, XMin);
        var max = new Coord(YMax, XMax);
        return new Grid<T>(min, max, values, DefaultValue);
    }
}
