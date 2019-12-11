using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Tools
{
    public class Matrix<T>
    {
        private IList<IList<T>> _matrix;
        private MatrixDirection _direction;
        
        public MatrixAddress Address { get; private set; }

        public Matrix(int width, int height)
        {
            _matrix = BuildMatrix(width, height);
            Address = new MatrixAddress(0, 0);
            _direction = MatrixDirection.Up;
        }

        public MatrixAddress MoveTo(MatrixAddress address)
        {
            Address = address;
            return address;
        }

        public MatrixAddress MoveTo(int x, int y)
        {
            return MoveTo(new MatrixAddress(x, y));
        }

        public MatrixAddress MoveForward(int distance = 1)
        {
            return MoveTo(Address.X + _direction.X, Address.Y + _direction.Y);
        }

        public MatrixAddress MoveBackward(int distance = 1)
        {
            if (_direction == MatrixDirection.Up)
                return MoveTo(Address.X, Address.Y + distance);
            if (_direction == MatrixDirection.Right)
                return MoveTo(Address.X - distance, Address.Y);
            if (_direction == MatrixDirection.Down)
                return MoveTo(Address.X, Address.Y - distance);
            return MoveTo(Address.X + distance, Address.Y);
        }

        public MatrixDirection TurnLeft()
        {
            if (_direction == MatrixDirection.Up)
                return TurnTo(MatrixDirection.Left);
            if (_direction == MatrixDirection.Right)
                return TurnTo(MatrixDirection.Up);
            if (_direction == MatrixDirection.Down)
                return TurnTo(MatrixDirection.Right);
            return TurnTo(MatrixDirection.Down);
        }

        public MatrixDirection TurnRight()
        {
            if (_direction == MatrixDirection.Up)
                return TurnTo(MatrixDirection.Right);
            if (_direction == MatrixDirection.Right)
                return TurnTo(MatrixDirection.Down);
            if (_direction == MatrixDirection.Down)
                return TurnTo(MatrixDirection.Left);
            return TurnTo(MatrixDirection.Up);
        }

        public MatrixDirection TurnTo(MatrixDirection direction)
        {
            _direction = direction;
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