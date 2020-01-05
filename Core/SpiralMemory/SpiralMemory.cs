using System;
using Core.Tools;

namespace Core.SpiralMemory
{
    public class SpiralMemory
    {
        private Matrix<int> _matrix;
        public int Distance { get; }

        public SpiralMemory(int targetSquare)
        {
            _matrix = BuildMatrix(targetSquare);
            Distance = GetDistance(_matrix.Address, _matrix.StartAddress);
        }

        private Matrix<int> BuildMatrix(int targetSquare)
        {
            var matrix = new Matrix<int>();
            matrix.TurnTo(MatrixDirection.Down);
            var currentSquare = 1;
            matrix.WriteValue(currentSquare);
            while (currentSquare < targetSquare)
            {
                matrix.TurnLeft();
                matrix.MoveForward();
                var v = matrix.ReadValue();
                if (v > 0)
                {
                    matrix.MoveBackward();
                    matrix.TurnRight();
                    matrix.MoveForward();
                }
                matrix.WriteValue(currentSquare);
                currentSquare += 1;
            }

            return matrix;
        }

        private static int GetDistance(MatrixAddress a, MatrixAddress b)
        {
            var xMax = Math.Max(a.X, b.X);
            var xMin = Math.Min(a.X, b.X);
            var xDiff = xMax - xMin;

            var yMax = Math.Max(a.Y, b.Y);
            var yMin = Math.Min(a.Y, b.Y);
            var yDiff = yMax - yMin;

            return xDiff + yDiff;
        }
    }
}