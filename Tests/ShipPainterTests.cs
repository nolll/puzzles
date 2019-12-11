using System.Collections.Generic;
using Core.Computer;
using NUnit.Framework;

namespace Tests
{
    public class MatrixTests
    {
        [Test]
        public void MoveToWorks()
        {
            var matrix = new Matrix(5);
            matrix.MoveTo(1, 2);

            Assert.That(matrix.Address.X, Is.EqualTo(1));
            Assert.That(matrix.Address.Y, Is.EqualTo(2));
        }

        [Test]
        public void MoveForwardWorks()
        {
            var matrix = new Matrix(5);
            matrix.MoveTo(1, 3);
            matrix.MoveForward();

            Assert.That(matrix.Address.X, Is.EqualTo(1));
            Assert.That(matrix.Address.Y, Is.EqualTo(2));
        }

        [Test]
        public void TurnAndMoveForwardWorks()
        {
            var matrix = new Matrix(5);
            matrix.TurnRight();
            matrix.MoveForward();
            matrix.TurnRight();
            matrix.MoveForward();

            Assert.That(matrix.Address.X, Is.EqualTo(1));
            Assert.That(matrix.Address.Y, Is.EqualTo(1));
        }
    }

    public class ShipPainterTests
    {
        [Test]
        public void ReturnsInputMemoryAsOutputMemory()
        {
            const string program = "109,1,204,-1,1001,100,1,100,1008,100,16,101,1006,101,0,99";

            var shipPainter = new ShipPainter(program);
            var result = shipPainter.Paint();

            Assert.That(result.PaintedPanels, Is.EqualTo(program));
        }
    }

    public class MatrixAddress
    {
        public int X { get; }
        public int Y { get; }

        public MatrixAddress(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

    public enum PaintMode
    {
        Paint,
        Move
    }

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

    public class MatrixDirection
    {
        public int X { get; }
        public int Y { get; }

        private MatrixDirection(int x, int y)
        {
            X = x;
            Y = y;
        }
        
        public static readonly MatrixDirection Up = new MatrixDirection(0, -1);
        public static readonly MatrixDirection Right = new MatrixDirection(1, 0);
        public static readonly MatrixDirection Down = new MatrixDirection(0, 1);
        public static readonly MatrixDirection Left = new MatrixDirection(-1, 0);
    }

    public class ShipPainter
    {
        private readonly string _program;
        private int _lastOutput;
        private MatrixAddress _matrixAddress;
        private IList<IList<int>> _panels;
        private MatrixDirection _direction = MatrixDirection.Up;
        private PaintMode _mode;

        public ShipPainter(string program, int shipSize = 100)
        {
            _program = program;
            var startPoint = shipSize / 2 - 1;
            _matrixAddress = new MatrixAddress(startPoint, startPoint);
            _panels = GetPanels(shipSize);
            _mode = PaintMode.Paint;
        }

        public Result Paint()
        {
            var computer = new ComputerInterface(_program, ReadInput, WriteOutput);
            computer.Start();

            return new Result(_lastOutput);
        }

        private IList<IList<int>> GetPanels(int shipSize)
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

        private long ReadInput()
        {
            return _panels[_matrixAddress.Y][_matrixAddress.X];
        }

        private void WriteOutput(long output)
        {
            if (_mode == PaintMode.Paint)
            {
                _panels[_matrixAddress.Y][_matrixAddress.X] = (int)output;
                _mode = PaintMode.Move;
            }
            else
            {

            }
        }

        public class Result
        {
            public int PaintedPanels { get; }

            public Result(int paintedPanels)
            {
                PaintedPanels = paintedPanels;
            }
        }
    }
}