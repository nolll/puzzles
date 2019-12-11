using System.Collections.Generic;

namespace Core.Tools
{
    public class Matrix
    {
        private IList<IList<int>> _matrix;
        private MatrixDirection _direction;
        
        public MatrixAddress Address { get; private set; }

        public Matrix(int size)
        {
            _matrix = BuildMatrix(size);
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

        public int ReadValue()
        {
            return _matrix[Address.Y][Address.X];
        }

        public void WriteValue(int value)
        {
            _matrix[Address.Y][Address.X] = value;
        }

        private IList<IList<int>> BuildMatrix(int shipSize)
        {
            var matrix = new List<IList<int>>();
            for (var y = 0; y < shipSize; y++)
            {
                var row = new List<int>();
                for (var x = 0; x < shipSize; x++)
                {
                    row.Add(x);
                }
                matrix.Add(row);
            }
            return matrix;
        }
    }
}