using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Tools
{
    public class Matrix<T>
    {
        private readonly IList<IList<T>> _matrix;
        public MatrixDirection Direction { get; private set; }
        public MatrixAddress Address { get; private set; }
        public MatrixAddress StartAddress { get; private set; }

        public IList<T> Values => _matrix.SelectMany(x => x).ToList();
        public int Height => _matrix.Count;
        public int Width => _matrix.Any() ? _matrix[0].Count : 0;

        public Matrix(int width = 1, int height = 1)
        {
            _matrix = BuildMatrix(width, height);
            Address = new MatrixAddress(0, 0);
            StartAddress = new MatrixAddress(0, 0);
            Direction = MatrixDirection.Up;
        }

        public MatrixAddress TryMoveTo(MatrixAddress address)
        {
            return MoveTo(address, false);
        }

        public MatrixAddress MoveTo(MatrixAddress address)
        {
            return MoveTo(address, true);
        }

        private MatrixAddress MoveTo(MatrixAddress address, bool extend)
        {
            if (IsOutOfRange(address))
            {
                if(extend)
                    ExtendMatrix(address);
                else
                    return Address;
            }

            var x = address.X > 0 ? address.X : 0;
            var y = address.Y > 0 ? address.Y : 0;
            Address = new MatrixAddress(x, y);
            return Address;
        }

        public MatrixAddress TryMoveTo(int x, int y)
        {
            return MoveTo(new MatrixAddress(x, y), false);
        }

        public MatrixAddress MoveTo(int x, int y)
        {
            return MoveTo(new MatrixAddress(x, y), true);
        }

        public MatrixAddress TryMoveForward()
        {
            return MoveForward(false);
        }

        public MatrixAddress MoveForward()
        {
            return MoveForward(true);
        }

        private MatrixAddress MoveForward(bool extend)
        {
            return MoveTo(new MatrixAddress(Address.X + Direction.X, Address.Y + Direction.Y), extend);
        }

        public MatrixAddress TryMoveBackward()
        {
            return MoveBackward(false);
        }

        public MatrixAddress MoveBackward()
        {
            return MoveBackward(true);
        }

        private MatrixAddress MoveBackward(bool extend)
        {
            return MoveTo(new MatrixAddress(Address.X - Direction.X, Address.Y - Direction.Y), extend);
        }

        public MatrixAddress TryMoveUp()
        {
            return MoveUp(false);
        }

        public MatrixAddress MoveUp()
        {
            return MoveUp(true);
        }

        private MatrixAddress MoveUp(bool extend)
        {
            return MoveTo(new MatrixAddress(Address.X, Address.Y - 1), extend);
        }

        public MatrixAddress TryMoveRight()
        {
            return MoveRight(false);
        }

        public MatrixAddress MoveRight()
        {
            return MoveRight(true);
        }

        private MatrixAddress MoveRight(bool extend)
        {
            return MoveTo(new MatrixAddress(Address.X + 1, Address.Y), extend);
        }

        public MatrixAddress TryMoveDown()
        {
            return MoveDown(false);
        }

        public MatrixAddress MoveDown()
        {
            return MoveDown(true);
        }

        private MatrixAddress MoveDown(bool extend)
        {
            return MoveTo(new MatrixAddress(Address.X, Address.Y + 1), extend);
        }

        public MatrixAddress TryMoveLeft()
        {
            return MoveLeft(false);
        }

        public MatrixAddress MoveLeft()
        {
            return MoveLeft(true);
        }

        private MatrixAddress MoveLeft(bool extend)
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

        public string Print(bool markCurrentAddress, bool markStartAddress, T currentAddressMarker = default, T startAddressMarker = default)
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

            return sb.ToString();
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

        private IList<IList<T>> BuildMatrix(int width, int height)
        {
            var matrix = new List<IList<T>>();
            for (var y = 0; y < height; y++)
            {
                var row = new List<T>();
                for (var x = 0; x < width; x++)
                {
                    row.Add(default);
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
                    row.Add(default);
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
                    row.Add(default);
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
                    row.Add(default);
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
                    row.Insert(0, default);
                }
            }
        }
    }
}