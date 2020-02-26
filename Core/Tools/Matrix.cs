using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Tools
{
    public class Matrix<T>
    {
        private readonly T _defaultValue;
        private readonly IList<IList<T>> _matrix;
        public MatrixDirection Direction { get; private set; }
        public MatrixAddress Address { get; private set; }
        public MatrixAddress StartAddress { get; private set; }

        public IList<T> Values => _matrix.SelectMany(x => x).ToList();
        public int Height => _matrix.Count;
        public int Width => _matrix.Any() ? _matrix[0].Count : 0;
        public bool IsAtTop => Address.Y == 0;
        public bool IsAtRightEdge => Address.X == Width - 1;
        public bool IsAtBottom => Address.Y == Height - 1;
        public bool IsAtLeftEdge => Address.X == 0;

        public Matrix(int width = 1, int height = 1, T defaultValue = default)
        {
            _defaultValue = defaultValue;
            _matrix = BuildMatrix(width, height, defaultValue);
            Address = new MatrixAddress(0, 0);
            StartAddress = new MatrixAddress(0, 0);
            Direction = MatrixDirection.Up;
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
                if(extend)
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

        public bool TryMoveUp()
        {
            return MoveUp(false);
        }

        public bool MoveUp()
        {
            return MoveUp(true);
        }

        private bool MoveUp(bool extend)
        {
            return MoveTo(new MatrixAddress(Address.X, Address.Y - 1), extend);
        }

        public bool TryMoveRight()
        {
            return MoveRight(false);
        }

        public bool MoveRight()
        {
            return MoveRight(true);
        }

        private bool MoveRight(bool extend)
        {
            return MoveTo(new MatrixAddress(Address.X + 1, Address.Y), extend);
        }

        public bool TryMoveDown()
        {
            return MoveDown(false);
        }

        public bool MoveDown()
        {
            return MoveDown(true);
        }

        private bool MoveDown(bool extend)
        {
            return MoveTo(new MatrixAddress(Address.X, Address.Y + 1), extend);
        }

        public bool TryMoveLeft()
        {
            return MoveLeft(false);
        }

        public bool MoveLeft()
        {
            return MoveLeft(true);
        }

        private bool MoveLeft(bool extend)
        {
            return MoveTo(new MatrixAddress(Address.X - 1, Address.Y), extend);
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

        public string Print(bool markCurrentAddress = false, bool markStartAddress = false, T currentAddressMarker = default, T startAddressMarker = default)
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
                    if(val.Equals(value))
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

        public IList<T> Adjacent4
        {
            get
            {
                var values = new List<T>();
                var address = new MatrixAddress(Address.X, Address.Y - 1);
                if (!IsOutOfRange(address))
                    values.Add(ReadValueAt(address));
                
                address = new MatrixAddress(Address.X + 1, Address.Y);
                if (!IsOutOfRange(address))
                    values.Add(ReadValueAt(address));
                
                address = new MatrixAddress(Address.X, Address.Y + 1);
                if (!IsOutOfRange(address))
                    values.Add(ReadValueAt(address));
                
                address = new MatrixAddress(Address.X - 1, Address.Y);
                if (!IsOutOfRange(address))
                    values.Add(ReadValueAt(address));

                return values;
            }
        }

        public IList<MatrixAddress> Adjacent4Coords
        {
            get
            {
                var values = new List<MatrixAddress>();
                var address = new MatrixAddress(Address.X, Address.Y - 1);
                if (!IsOutOfRange(address))
                    values.Add(address);

                address = new MatrixAddress(Address.X + 1, Address.Y);
                if (!IsOutOfRange(address))
                    values.Add(address);

                address = new MatrixAddress(Address.X, Address.Y + 1);
                if (!IsOutOfRange(address))
                    values.Add(address);

                address = new MatrixAddress(Address.X - 1, Address.Y);
                if (!IsOutOfRange(address))
                    values.Add(address);

                return values;
            }
        }

        public IList<T> Adjacent8
        {
            get
            {
                var values = new List<T>();
                var address = new MatrixAddress(Address.X, Address.Y - 1);
                if (!IsOutOfRange(address))
                    values.Add(ReadValueAt(address));

                address = new MatrixAddress(Address.X + 1, Address.Y - 1);
                if (!IsOutOfRange(address))
                    values.Add(ReadValueAt(address));

                address = new MatrixAddress(Address.X + 1, Address.Y);
                if (!IsOutOfRange(address))
                    values.Add(ReadValueAt(address));

                address = new MatrixAddress(Address.X + 1, Address.Y + 1);
                if (!IsOutOfRange(address))
                    values.Add(ReadValueAt(address));

                address = new MatrixAddress(Address.X, Address.Y + 1);
                if (!IsOutOfRange(address))
                    values.Add(ReadValueAt(address));

                address = new MatrixAddress(Address.X - 1, Address.Y + 1);
                if (!IsOutOfRange(address))
                    values.Add(ReadValueAt(address));

                address = new MatrixAddress(Address.X - 1, Address.Y);
                if (!IsOutOfRange(address))
                    values.Add(ReadValueAt(address));

                address = new MatrixAddress(Address.X - 1, Address.Y - 1);
                if (!IsOutOfRange(address))
                    values.Add(ReadValueAt(address));

                return values;
            }
        }

        public Matrix<T> Copy()
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
            AddColsLeft(-address.X);
            StartAddress = new MatrixAddress(StartAddress.X - address.X, StartAddress.Y);
        }

        private void ExtendRight(MatrixAddress address)
        {
            var extendBy = address.X - (Width - 1);
            if (extendBy > 0)
                AddColsRight(extendBy);
        }

        private void ExtendY(MatrixAddress address)
        {
            if (address.Y < 0)
                ExtendTop(address);
            ExtendBottom(address);
        }

        private void ExtendTop(MatrixAddress address)
        {
            AddRowsTop(-address.Y);
            StartAddress = new MatrixAddress(StartAddress.X, StartAddress.Y - address.Y);
        }

        private void ExtendBottom(MatrixAddress address)
        {
            var extendBy = address.Y - (Height - 1);
            if (extendBy > 0)
                AddRowsBottom(extendBy);
        }

        private void AddRowsTop(int numberOfRows)
        {
            var width = Width;
            for (var y = 0; y < numberOfRows; y++)
            {
                var row = new List<T>();
                for (var x = 0; x < width; x++)
                {
                    row.Add(_defaultValue);
                }
                _matrix.Insert(0, row);
            }
        }

        private void AddRowsBottom(int numberOfRows)
        {
            var width = Width;
            for (var y = 0; y < numberOfRows; y++)
            {
                var row = new List<T>();
                for (var x = 0; x < width; x++)
                {
                    row.Add(_defaultValue);
                }
                _matrix.Add(row);
            }
        }

        private void AddColsRight(int numberOfRows)
        {
            var height = Height;
            for (var y = 0; y < height; y++)
            {
                var row = _matrix[y];
                for (var x = 0; x < numberOfRows; x++)
                {
                    row.Add(_defaultValue);
                }
            }
        }

        private void AddColsLeft(int numberOfRows)
        {
            var height = Height;
            for (var y = 0; y < height; y++)
            {
                var row = _matrix[y];
                for (var x = 0; x < numberOfRows; x++)
                {
                    row.Insert(0, _defaultValue);
                }
            }
        }
    }
}