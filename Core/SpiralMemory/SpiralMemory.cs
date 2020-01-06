using System;
using System.Linq;
using Core.Tools;

namespace Core.SpiralMemory
{
    public enum SpiralMemoryMode
    {
        RunToTarget,
        RunToValue
    }

    public class SpiralMemory
    {
        private readonly Matrix<long> _matrix;
        public int Distance { get; }
        public long Value { get; }

        public SpiralMemory(int targetSquare, SpiralMemoryMode mode)
        {
            _matrix = BuildMatrix(targetSquare, mode);
            Distance = GetDistance(_matrix.Address, _matrix.StartAddress);
            Value = _matrix.ReadValue();
        }

        private Matrix<long> BuildMatrix(int targetSquare, SpiralMemoryMode mode)
        {
            var matrix = new Matrix<long>();
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
                var valueToWrite = mode == SpiralMemoryMode.RunToValue
                    ? matrix.Adjacent8.Sum() 
                    : currentSquare;

                matrix.WriteValue(valueToWrite);
                if (mode == SpiralMemoryMode.RunToValue && valueToWrite > targetSquare)
                    break;

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