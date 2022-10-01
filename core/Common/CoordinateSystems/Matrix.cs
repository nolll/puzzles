using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Common.CoordinateSystems;

public class Matrix<T> : BaseMatrix, IMatrix<T>
{
    private readonly T _defaultValue;
    private readonly IList<IList<T>> _matrix;
    public MatrixDirection Direction { get; private set; }
    public MatrixAddress Address { get; private set; }
    public MatrixAddress StartAddress { get; private set; }

    public IEnumerable<T> Values => _matrix.SelectMany(x => x).ToList();
    public int Height => _matrix.Count;
    public int Width => _matrix.Any() ? _matrix[0].Count : 0;
    public bool IsAtTop => Address.Y == 0;
    public bool IsAtRightEdge => Address.X == Width - 1;
    public bool IsAtBottom => Address.Y == Height - 1;
    public bool IsAtLeftEdge => Address.X == 0;
    public MatrixAddress Center => new(Width / 2, Height / 2);

    public Matrix(int width = 1, int height = 1, T defaultValue = default)
    {
        _defaultValue = defaultValue;
        _matrix = BuildMatrix(width, height, defaultValue);
        Address = new MatrixAddress(0, 0);
        StartAddress = new MatrixAddress(0, 0);
        Direction = MatrixDirection.Up;
    }

    public IEnumerable<MatrixAddress> Coords
    {
        get
        {
            var coords = new List<MatrixAddress>();
            for (var y = 0; y < Height; y++)
            {
                for (var x = 0; x < Width; x++)
                {
                    coords.Add(new MatrixAddress(x, y));
                }
            }
            return coords;
        }
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
                ExtendMatrix(address);
            else
                return false;
        }

        var x = address.X > 0 ? address.X : 0;
        var y = address.Y > 0 ? address.Y : 0;
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
        var y = 0;
        foreach (var row in _matrix)
        {
            var x = 0;
            foreach (var o in row)
            {
                if (markCurrentAddress && x == Address.X && y == Address.Y)
                    sb.Append('D');
                else if (markStartAddress && x == StartAddress.X && y == StartAddress.Y)
                    sb.Append('S');
                else
                    sb.Append(o);

                if (spacing)
                    sb.Append(' ');

                x += 1;
            }

            sb.AppendLine();
            y += 1;
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

    public T ReadValueAt(int x, int y)
    {
        return _matrix[y][x];
    }

    public void WriteValue(T value)
    {
        _matrix[Address.Y][Address.X] = value;
    }

    public IList<MatrixAddress> FindAddresses(T value)
    {
        var addresses = new List<MatrixAddress>();
        for (var y = 0; y < _matrix.Count; y++)
        {
            for (var x = 0; x < _matrix.Count; x++)
            {
                var address = new MatrixAddress(x, y);
                MoveTo(address);
                var val = ReadValue();
                if (val.Equals(value))
                    addresses.Add(address);
            }
        }

        return addresses;
    }

    public bool IsOutOfRange(MatrixAddress address)
    {
        return address.Y >= Height ||
               address.Y < 0 ||
               address.X >= Width ||
               address.X < 0;
    }

    public IList<T> PerpendicularAdjacentValues => PerpendicularAdjacentCoords.Select(ReadValueAt).ToList();
    public IList<MatrixAddress> PerpendicularAdjacentCoords => PossiblePerpendicularAdjacentCoords.Where(o => !IsOutOfRange(o)).ToList();

    private IEnumerable<MatrixAddress> PossiblePerpendicularAdjacentCoords =>
        new List<MatrixAddress>
        {
            new MatrixAddress(Address.X, Address.Y - 1),
            new MatrixAddress(Address.X + 1, Address.Y),
            new MatrixAddress(Address.X, Address.Y + 1),
            new MatrixAddress(Address.X - 1, Address.Y)
        };

    public IList<T> AllAdjacentValues => AllAdjacentCoords.Select(ReadValueAt).ToList();
    public IList<MatrixAddress> AllAdjacentCoords => AllPossibleAdjacentCoords.Where(o => !IsOutOfRange(o)).ToList();

    private IEnumerable<MatrixAddress> AllPossibleAdjacentCoords
    {
        get
        {
            foreach (var dy in AdjacentDeltas)
            {
                foreach (var dx in AdjacentDeltas)
                {
                    var coord = new MatrixAddress(Address.X + dx, Address.Y - dy);
                    if (!coord.Equals(Address))
                        yield return coord;
                }
            }
        }
    }

    public IMatrix<T> Copy()
    {
        var matrix = new Matrix<T>();
        for (var y = 0; y < Height; y++)
        {
            for (var x = 0; x < Width; x++)
            {
                matrix.MoveTo(x, y);
                matrix.WriteValue(ReadValueAt(x, y));
            }
        }

        matrix.MoveTo(Address);
        return matrix;
    }

    public IMatrix<T> RotateLeft()
    {
        var newMatrix = new Matrix<T>(Height, Width, _defaultValue);
        var oy = 0;
        for (var ox = Width - 1; ox >= 0; ox--)
        {
            var nx = 0;
            for (var ny = 0; ny < Height; ny++)
            {
                MoveTo(ox, ny);
                newMatrix.MoveTo(nx, oy);
                newMatrix.WriteValue(ReadValue());
                nx++;
            }
            oy++;
        }
        return newMatrix;
    }

    public IMatrix<T> RotateRight()
    {
        return RotateLeft().RotateLeft().RotateLeft();
    }

    public IMatrix<T> Slice(MatrixAddress from = null, MatrixAddress to = null)
    {
        from ??= new MatrixAddress(0, 0);
        to ??= new MatrixAddress(Width - 1, Height - 1);
        var xNew = 0;
        var yNew = 0;
        var newMatrix = new Matrix<T>(defaultValue: _defaultValue);
        for (var y = from.Y; y <= to.Y; y++)
        {
            for (var x = from.X; x <= to.X; x++)
            {
                newMatrix.MoveTo(xNew, yNew);
                newMatrix.WriteValue(ReadValueAt(x, y));

                xNew++;
            }

            xNew = 0;
            yNew++;
        }
        return newMatrix;
    }

    public IMatrix<T> Slice(MatrixAddress from, int width, int height)
    {
        var to = new MatrixAddress(from.X + width, from.Y + height);
        return Slice(from, to);
    }

    public IMatrix<T> FlipVertical()
    {
        var width = Width;
        var height = Height;
        var newMatrix = new Matrix<T>(width, height, _defaultValue);
        for (var y = 0; y < height; y++)
        {
            for (var x = 0; x < width; x++)
            {
                var ny = height - y - 1;
                newMatrix.MoveTo(x, ny);
                newMatrix.WriteValue(ReadValueAt(x, y));
            }
        }
        return newMatrix;
    }

    public IMatrix<T> FlipHorizontal()
    {
        var width = Width;
        var height = Height;
        var newMatrix = new Matrix<T>(width, height, _defaultValue);
        for (var y = 0; y < height; y++)
        {
            for (var x = 0; x < width; x++)
            {
                var nx = width - x - 1;
                newMatrix.MoveTo(nx, y);
                newMatrix.WriteValue(ReadValueAt(x, y));
            }
        }
        return newMatrix;
    }

    private IList<IList<T>> BuildMatrix(int width, int height, T defaultValue)
    {
        var matrix = new List<IList<T>>();
        for (var y = 0; y < height; y++)
        {
            var row = new List<T>();
            for (var x = 0; x < width; x++)
            {
                row.Add(defaultValue);
            }
            matrix.Add(row);
        }
        return matrix;
    }

    private void ExtendMatrix(MatrixAddress address)
    {
        ExtendX(address);
        ExtendY(address);
    }

    private void ExtendX(MatrixAddress address)
    {
        if (address.X < 0)
            ExtendLeft(address);
        ExtendRight(address);
    }

    private void ExtendLeft(MatrixAddress address)
    {
        AddCols(-address.X, MatrixAddMode.Prepend);
        StartAddress = new MatrixAddress(StartAddress.X - address.X, StartAddress.Y);
    }

    private void ExtendRight(MatrixAddress address)
    {
        var extendBy = address.X - (Width - 1);
        if (extendBy > 0)
            AddCols(extendBy, MatrixAddMode.Append);
    }

    private void ExtendY(MatrixAddress address)
    {
        if (address.Y < 0)
            ExtendTop(address);
        ExtendBottom(address);
    }

    private void ExtendTop(MatrixAddress address)
    {
        AddRows(-address.Y, MatrixAddMode.Prepend);
        StartAddress = new MatrixAddress(StartAddress.X, StartAddress.Y - address.Y);
    }

    private void ExtendBottom(MatrixAddress address)
    {
        var extendBy = address.Y - (Height - 1);
        if (extendBy > 0)
            AddRows(extendBy, MatrixAddMode.Append);
    }

    private void AddRows(int numberOfRows, MatrixAddMode addMode)
    {
        var width = Width;
        for (var y = 0; y < numberOfRows; y++)
        {
            var row = new List<T>();
            for (var x = 0; x < width; x++)
            {
                row.Add(_defaultValue);
            }

            if (addMode == MatrixAddMode.Prepend)
                _matrix.Insert(0, row);
            else
                _matrix.Add(row);
        }
    }

    private void AddCols(int numberOfRows, MatrixAddMode addMode)
    {
        var height = Height;
        for (var y = 0; y < height; y++)
        {
            var row = _matrix[y];
            for (var x = 0; x < numberOfRows; x++)
            {
                if (addMode == MatrixAddMode.Prepend)
                    row.Insert(0, _defaultValue);
                else
                    row.Add(_defaultValue);
            }
        }
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
}