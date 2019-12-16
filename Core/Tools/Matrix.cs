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

        public Matrix(int width, int height)
        {
            _matrix = BuildMatrix(width, height);
            Address = new MatrixAddress(0, 0);
            Direction = MatrixDirection.Up;
        }

        public MatrixAddress MoveTo(MatrixAddress address)
        {
            if (IsOutOfRange(address))
            {
                ExtendMatrix(address);
            }

            Address = address;
            return address;
        }

        private void ExtendMatrix(MatrixAddress address)
        {
            ExtendX(address);
            ExtendY(address);
        }

        private void ExtendX(MatrixAddress address)
        {
            var extendBy = address.X - (Width - 1);
            if (extendBy > 0)
                AddCols(extendBy);
        }

        private void ExtendY(MatrixAddress address)
        {
            var extendBy = address.Y - (Height - 1);
            if (extendBy > 0)
                AddRows(extendBy);
        }

        private bool IsOutOfRange(MatrixAddress address)
        {
            return address.Y >= Height || address.X >= Width;
        }

        public MatrixAddress MoveTo(int x, int y)
        {
            return MoveTo(new MatrixAddress(x, y));
        }

        public MatrixAddress MoveForward(int distance = 1)
        {
            return MoveTo(Address.X + Direction.X, Address.Y + Direction.Y);
        }

        public MatrixAddress MoveBackward(int distance = 1)
        {
            if (Direction == MatrixDirection.Up)
                return MoveTo(Address.X, Address.Y + distance);
            if (Direction == MatrixDirection.Right)
                return MoveTo(Address.X - distance, Address.Y);
            if (Direction == MatrixDirection.Down)
                return MoveTo(Address.X, Address.Y - distance);
            return MoveTo(Address.X + distance, Address.Y);
        }

        public MatrixDirection TurnLeft()
        {
            if (Direction == MatrixDirection.Up)
                return TurnTo(MatrixDirection.Left);
            if (Direction == MatrixDirection.Right)
                return TurnTo(MatrixDirection.Up);
            if (Direction == MatrixDirection.Down)
                return TurnTo(MatrixDirection.Right);
            return TurnTo(MatrixDirection.Down);
        }

        public MatrixDirection TurnRight()
        {
            if (Direction == MatrixDirection.Up)
                return TurnTo(MatrixDirection.Right);
            if (Direction == MatrixDirection.Right)
                return TurnTo(MatrixDirection.Down);
            if (Direction == MatrixDirection.Down)
                return TurnTo(MatrixDirection.Left);
            return TurnTo(MatrixDirection.Up);
        }

        public MatrixDirection TurnTo(MatrixDirection direction)
        {
            Direction = direction;
            return direction;
        }

        public IList<T> Values => _matrix.SelectMany(x => x).ToList();

        public string Print()
        {
            var sb = new StringBuilder();
            foreach (var row in _matrix)
            {
                foreach (var o in row)
                {
                    sb.Append(o);
                }

                sb.AppendLine();
            }

            return sb.ToString();
        }

        public T ReadValue()
        {
            return _matrix[Address.Y][Address.X];
        }

        public void WriteValue(T value)
        {
            _matrix[Address.Y][Address.X] = value;
        }

        private int Height => _matrix.Count;
        private int Width => _matrix.Any() ? _matrix[0].Count : 0;

        private void AddRows(int numberOfRows)
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

        private void AddCols(int numberOfRows)
        {
            var height = Height;
            for (var y = 0; y < height; y++)
            {
                var row = _matrix[0];
                for (var x = 0; x < numberOfRows; x++)
                {
                    row.Add(default);
                }
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
    }
}