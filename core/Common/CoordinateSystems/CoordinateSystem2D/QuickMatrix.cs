using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace Core.Common.CoordinateSystems.CoordinateSystem2D;

public class QuickMatrix<T> : BaseMatrix, IMatrix<T>
{
    private readonly T _defaultValue;
    private readonly IDictionary<(int x, int y), T> _matrix;
    private int _minx;
    private int _maxx;
    private int _miny;
    private int _maxy;

    public int Width => _maxx - _minx + 1;
    public int Height => _maxy - _miny + 1;
    public int XMin => _minx;
    public int XMax => _maxx;
    public int YMin => _miny;
    public int YMax => _maxy;
    public MatrixDirection Direction { get; private set; }
    public MatrixAddress Address { get; private set; }
    public MatrixAddress StartAddress { get; }
    public bool IsAtTop => Address.Y == 0;
    public bool IsAtRightEdge => Address.X == Width - 1;
    public bool IsAtBottom => Address.Y == Height - 1;
    public bool IsAtLeftEdge => Address.X == 0;
    public MatrixAddress Center => new(Width / 2, Height / 2);

    private QuickMatrix(T defaultValue)
    {
        _defaultValue = defaultValue;
        Address = new MatrixAddress(0, 0);
        StartAddress = new MatrixAddress(0, 0);
        Direction = MatrixDirection.Up;
    }

    public QuickMatrix(int width = 1, int height = 1, T defaultValue = default)
        : this(defaultValue)
    {
        _minx = 0;
        _maxx = width - 1;
        _miny = 0;
        _maxy = height - 1;
        _matrix = new Dictionary<(int x, int y), T>();
    }

    private QuickMatrix(MatrixAddress min, MatrixAddress max, IDictionary<(int x, int y), T> values, T defaultValue = default)
        : this(defaultValue)
    {
        _matrix = values;
        _minx = min.X;
        _maxx = max.X;
        _miny = min.Y;
        _maxy = max.Y;
    }

    public IEnumerable<T> Values
    {
        get
        {
            foreach (var coord in Coords)
            {
                if (_matrix.TryGetValue((coord.X, coord.Y), out var v))
                    yield return v;
                else
                    yield return _defaultValue;
            }
        }
    }

    public IEnumerable<MatrixAddress> Coords
    {
        get
        {
            for (var y = YMin; y <= YMax; y++)
            {
                for (var x = XMin; x <= XMax; x++)
                {
                    yield return new MatrixAddress(x, y);
                }
            }
        }
    }

    public T ReadValueAt(int x, int y)
    {
        return _matrix.TryGetValue((x, y), out var v)
            ? v
            : _defaultValue;
    }

    public void WriteValueAt(int x, int y, T value)
    {
        if (x < _minx)
            _minx = x;
        else if (x > _maxx)
            _maxx = x;
        
        if (y < _miny)
            _miny = y;
        else if (y > _maxy)
            _maxy = y;

        _matrix[(x, y)] = value;
    }
    
    private void HandleExtend(MatrixAddress address)
    {
        ExtendMatrix(address);
    }

    private void ExtendMatrix(MatrixAddress address)
    {
        ExtendX(address);
        ExtendY(address);
    }

    private void ExtendX(MatrixAddress address)
    {
        if (address.X < XMin)
            ExtendLeft(address);
        ExtendRight(address);
    }

    private void ExtendLeft(MatrixAddress address)
    {
        AddCols(-address.X, MatrixAddMode.Prepend);
    }

    private void ExtendRight(MatrixAddress address)
    {
        var extendBy = address.X - XMax;
        if (extendBy > 0)
            AddCols(extendBy, MatrixAddMode.Append);
    }

    private void ExtendY(MatrixAddress address)
    {
        if (address.Y < YMin)
            ExtendTop(address);
        ExtendBottom(address);
    }

    private void ExtendTop(MatrixAddress address)
    {
        AddRows(-address.Y, MatrixAddMode.Prepend);
    }

    private void ExtendBottom(MatrixAddress address)
    {
        var extendBy = address.Y - YMax;
        if (extendBy > 0)
            AddRows(extendBy, MatrixAddMode.Append);
    }

    private void AddRows(int numberOfRows, MatrixAddMode addMode)
    {
        if (addMode == MatrixAddMode.Prepend)
            _miny -= numberOfRows;
        else
            _maxy += numberOfRows;
    }

    private void AddCols(int numberOfCols, MatrixAddMode addMode)
    {
        if (addMode == MatrixAddMode.Prepend)
            _minx -= numberOfCols;
        else
            _maxx += numberOfCols;
    }

    public void ExtendAllDirections(int steps = 1)
    {
        ExtendUp(steps);
        ExtendRight(steps);
        ExtendDown(steps);
        ExtendLeft(steps);
    }

    public void ExtendUp(int steps = 1)
    {
        AddRows(steps, MatrixAddMode.Prepend);
    }

    public void ExtendRight(int steps = 1)
    {
        AddCols(steps, MatrixAddMode.Append);
    }

    public void ExtendDown(int steps = 1)
    {
        AddRows(steps, MatrixAddMode.Append);
    }

    public void ExtendLeft(int steps = 1)
    {
        AddCols(steps, MatrixAddMode.Prepend);
    }

    public IMatrix<T> Copy()
    {
        var values = _matrix.ToDictionary(item => (item.Key.x, item.Key.y), item => item.Value);
        var min = new MatrixAddress(XMin, YMin);
        var max = new MatrixAddress(XMax, YMax);
        return new QuickMatrix<T>(min, max, values, _defaultValue);
    }

    public IMatrix<T> RotateLeft()
    {
        var values = _matrix.ToDictionary(item => (item.Key.y, YMax - item.Key.x), item => item.Value);
        var min = new MatrixAddress(YMin, YMin);
        var max = new MatrixAddress(XMax, YMax);
        var newMatrix = new QuickMatrix<T>(min, max, values, _defaultValue);
        return newMatrix;
    }

    public IMatrix<T> RotateRight()
    {
        var values = _matrix.ToDictionary(item => (XMax - item.Key.y, item.Key.x), item => item.Value);
        var min = new MatrixAddress(YMin, YMin);
        var max = new MatrixAddress(XMax, YMax);
        var newMatrix = new QuickMatrix<T>(min, max, values, _defaultValue);
        return newMatrix;
    }

    public IMatrix<T> Slice(MatrixAddress from = null, MatrixAddress to = null)
    {
        from ??= new MatrixAddress(XMin, YMin);
        to ??= new MatrixAddress(XMax, YMax);
        var dx = from.X;
        var dy = from.Y;
        var values = _matrix
            .Where(item => item.Key.x >= from.X && item.Key.y >= from.Y && item.Key.x <= to.X && item.Key.y <= to.Y)
            .ToDictionary(item => (item.Key.x - dx, item.Key.y - dy), item => item.Value);
        var slicedFrom = new MatrixAddress(from.X - dx, from.Y - dy);
        var slicedTo = new MatrixAddress(to.X - dx, to.Y - dy);
        var newMatrix = new QuickMatrix<T>(slicedFrom, slicedTo, values, _defaultValue);
        return newMatrix;
    }

    public IMatrix<T> Slice(MatrixAddress from, int width, int height)
    {
        var to = new MatrixAddress(from.X + width, from.Y + height);
        return Slice(from, to);
    }
    
    public IMatrix<T> FlipVertical()
    {
        var values = _matrix.ToDictionary(item => (item.Key.x, YMax - item.Key.y), item => item.Value);
        var min = new MatrixAddress(YMin, YMin);
        var max = new MatrixAddress(XMax, YMax);
        return new QuickMatrix<T>(min, max, values, _defaultValue);
    }

    public IMatrix<T> FlipHorizontal()
    {
        var values = _matrix.ToDictionary(item => (XMax - item.Key.x, item.Key.y), item => item.Value);
        var min = new MatrixAddress(YMin, YMin);
        var max = new MatrixAddress(XMax, YMax);
        return new QuickMatrix<T>(min, max, values, _defaultValue);
    }

    public bool TryMoveTo(MatrixAddress address)
    {
        return MoveTo(address, false);
    }

    public bool MoveTo(MatrixAddress address)
    {
        return MoveTo(address, true);
    }

    private bool MoveTo(MatrixAddress address, bool extend)
    {
        if (IsOutOfRange(address))
        {
            if (extend)
                HandleExtend(address);
            else
                return false;
        }

        var x = address.X > XMin ? address.X : XMin;
        var y = address.Y > YMin ? address.Y : YMin;
        Address = new MatrixAddress(x, y);
        return true;
    }

    public bool TryMoveTo(int x, int y)
    {
        return MoveTo(new MatrixAddress(x, y), false);
    }

    public bool MoveTo(int x, int y)
    {
        return MoveTo(new MatrixAddress(x, y), true);
    }

    public bool TryMoveForward()
    {
        return MoveForward(false);
    }

    public bool MoveForward()
    {
        return MoveForward(true);
    }

    private bool MoveForward(bool extend)
    {
        return MoveTo(new MatrixAddress(Address.X + Direction.X, Address.Y + Direction.Y), extend);
    }

    public bool TryMoveBackward()
    {
        return MoveBackward(false);
    }

    public bool MoveBackward()
    {
        return MoveBackward(true);
    }

    private bool MoveBackward(bool extend)
    {
        return MoveTo(new MatrixAddress(Address.X - Direction.X, Address.Y - Direction.Y), extend);
    }

    public bool TryMoveUp(int steps = 1)
    {
        return MoveUp(steps, false);
    }

    public bool MoveUp(int steps = 1)
    {
        return MoveUp(steps, true);
    }

    private bool MoveUp(int steps, bool extend)
    {
        return MoveTo(new MatrixAddress(Address.X, Address.Y - steps), extend);
    }

    public bool TryMoveRight(int steps = 1)
    {
        return MoveRight(steps, false);
    }

    public bool MoveRight(int steps = 1)
    {
        return MoveRight(steps, true);
    }

    private bool MoveRight(int steps, bool extend)
    {
        return MoveTo(new MatrixAddress(Address.X + steps, Address.Y), extend);
    }

    public bool TryMoveDown(int steps = 1)
    {
        return MoveDown(steps, false);
    }

    public bool MoveDown(int steps = 1)
    {
        return MoveDown(steps, true);
    }

    private bool MoveDown(int steps, bool extend)
    {
        return MoveTo(new MatrixAddress(Address.X, Address.Y + steps), extend);
    }

    public bool TryMoveLeft(int steps = 1)
    {
        return MoveLeft(steps, false);
    }

    public bool MoveLeft(int steps = 1)
    {
        return MoveLeft(steps, true);
    }

    private bool MoveLeft(int steps, bool extend)
    {
        return MoveTo(new MatrixAddress(Address.X - steps, Address.Y), extend);
    }

    public MatrixDirection TurnLeft()
    {
        if (Direction.Equals(MatrixDirection.Up))
            return TurnTo(MatrixDirection.Left);
        if (Direction.Equals(MatrixDirection.Right))
            return TurnTo(MatrixDirection.Up);
        if (Direction.Equals(MatrixDirection.Down))
            return TurnTo(MatrixDirection.Right);
        return TurnTo(MatrixDirection.Down);
    }

    public MatrixDirection TurnRight()
    {
        if (Direction.Equals(MatrixDirection.Up))
            return TurnTo(MatrixDirection.Right);
        if (Direction.Equals(MatrixDirection.Right))
            return TurnTo(MatrixDirection.Down);
        if (Direction.Equals(MatrixDirection.Down))
            return TurnTo(MatrixDirection.Left);
        return TurnTo(MatrixDirection.Up);
    }

    public MatrixDirection TurnTo(MatrixDirection direction)
    {
        Direction = direction;
        return direction;
    }

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

            sb.AppendLine();
        }

        return sb.ToString().Trim();
    }

    public T ReadValue()
    {
        return ReadValueAt(Address.X, Address.Y);
    }

    public T ReadValueAt(MatrixAddress address)
    {
        return ReadValueAt(address.X, address.Y);
    }

    public void WriteValue(T value)
    {
        WriteValueAt(Address.X, Address.Y, value);
    }

    public void WriteValueAt(MatrixAddress address, T value)
    {
        WriteValueAt(address.X, address.Y, value);
    }

    public IList<MatrixAddress> FindAddresses(T value)
    {
        var addresses = new List<MatrixAddress>();
        for (var y = YMin; y <= YMax; y++)
        {
            for (var x = XMin; x <= XMax; x++)
            {
                var address = new MatrixAddress(x, y);
                var val = ReadValueAt(address);
                if (val.Equals(value))
                    addresses.Add(address);
            }
        }

        return addresses;
    }

    public bool IsOutOfRange(MatrixAddress address)
    {
        return address.Y > YMax ||
               address.Y < YMin ||
               address.X > XMax ||
               address.X < XMin;
    }

    public IList<T> PerpendicularAdjacentValues => PerpendicularAdjacentCoords.Select(ReadValueAt).ToList();
    public IList<T> PerpendicularAdjacentValuesTo(MatrixAddress address) => PerpendicularAdjacentCoordsTo(address).Select(ReadValueAt).ToList();
    public IList<MatrixAddress> PerpendicularAdjacentCoords => PerpendicularAdjacentCoordsTo(Address);
    public IList<MatrixAddress> PerpendicularAdjacentCoordsTo(MatrixAddress address) => PossiblePerpendicularAdjacentCoordsTo(address).Where(o => !IsOutOfRange(o)).ToList();

    private IEnumerable<MatrixAddress> PossiblePerpendicularAdjacentCoordsTo(MatrixAddress address) => new List<MatrixAddress>
    {
        new(address.X, address.Y - 1),
        new(address.X + 1, address.Y),
        new(address.X, address.Y + 1),
        new(address.X - 1, address.Y)
    };

    public IList<T> AllAdjacentValues => AllAdjacentCoordsTo(Address).Select(ReadValueAt).ToList();
    public IList<T> AllAdjacentValuesTo(MatrixAddress address) => AllAdjacentCoordsTo(address).Select(ReadValueAt).ToList();
    public IList<MatrixAddress> AllAdjacentCoords => AllAdjacentCoordsTo(Address);
    public IList<MatrixAddress> AllAdjacentCoordsTo(MatrixAddress address) => AllPossibleAdjacentCoordsTo(address).Where(o => !IsOutOfRange(o)).ToList();

    private IEnumerable<MatrixAddress> AllPossibleAdjacentCoordsTo(MatrixAddress address)
    {
        foreach (var dy in AdjacentDeltas)
        {
            foreach (var dx in AdjacentDeltas)
            {
                var coord = new MatrixAddress(address.X + dx, address.Y + dy);
                if (!coord.Equals(address))
                    yield return coord;
            }
        }
    }
}