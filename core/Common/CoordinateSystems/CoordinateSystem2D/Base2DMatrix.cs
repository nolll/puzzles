using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Common.CoordinateSystems.CoordinateSystem2D;

public abstract class Base2DMatrix<T> : BaseMatrix, IMatrix<T>
{
    protected readonly T DefaultValue;

    public abstract int Width { get; }
    public abstract int Height { get; }
    public abstract int XMin { get; }
    public abstract int XMax { get; }
    public abstract int YMin { get; }
    public abstract int YMax { get; }
    public MatrixDirection Direction { get; private set; }
    public MatrixAddress Address { get; private set; }
    public MatrixAddress StartAddress { get; protected set; }
    public bool IsAtTop => Address.Y == 0;
    public bool IsAtRightEdge => Address.X == Width - 1;
    public bool IsAtBottom => Address.Y == Height - 1;
    public bool IsAtLeftEdge => Address.X == 0;
    public MatrixAddress Center => new(Width / 2, Height / 2);

    protected Base2DMatrix(T defaultValue)
    {
        DefaultValue = defaultValue;
        Address = new MatrixAddress(0, 0);
        StartAddress = new MatrixAddress(0, 0);
        Direction = MatrixDirection.Up;
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

    public abstract IEnumerable<T> Values { get; }

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

    protected abstract void HandleExtend(MatrixAddress address);

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

    public abstract IMatrix<T> Slice(MatrixAddress from, int width, int height);

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

    public abstract IMatrix<T> RotateLeft();
    public abstract IMatrix<T> RotateRight();
    public abstract IMatrix<T> Slice(MatrixAddress from = null, MatrixAddress to = null);

    public abstract T ReadValueAt(int x, int y);

    public void WriteValue(T value)
    {
        WriteValueAt(Address.X, Address.Y, value);
    }

    public void WriteValueAt(MatrixAddress address, T value)
    {
        WriteValueAt(address.X, address.Y, value);
    }

    public abstract void WriteValueAt(int x, int y, T value);

    protected abstract IMatrix<T> Create(int width, int height, T defaultValue = default);

    public abstract IMatrix<T> Copy();

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

    public abstract IMatrix<T> FlipHorizontal();
    public abstract IMatrix<T> FlipVertical();

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