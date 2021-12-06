using System.Linq;
using Core.Common.CoordinateSystems;

namespace ConsoleApp.Puzzles.Year2017.Day03
{
    public class SpiralMemory
    {
        private readonly Matrix<long> _matrix;
        public int Distance { get; }
        public long Value { get; }

        public SpiralMemory(int targetSquare, SpiralMemoryMode mode)
        {
            _matrix = BuildMatrix(targetSquare, mode);
            Distance = _matrix.Address.ManhattanDistanceTo(_matrix.StartAddress);
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
                    ? matrix.AllAdjacentValues.Sum() 
                    : currentSquare;

                matrix.WriteValue(valueToWrite);
                if (mode == SpiralMemoryMode.RunToValue && valueToWrite > targetSquare)
                    break;

                currentSquare += 1;
            }

            return matrix;
        }
    }
}