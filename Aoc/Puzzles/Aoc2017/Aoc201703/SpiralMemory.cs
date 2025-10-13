using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Aoc.Puzzles.Aoc2017.Aoc201703;

public class SpiralMemory
{
    public int Distance { get; }
    public long Value { get; }

    public SpiralMemory(int targetSquare, SpiralMemoryMode mode)
    {
        var matrix = BuildMatrix(targetSquare, mode);
        Distance = matrix.Address.ManhattanDistanceTo(matrix.StartAddress);
        Value = matrix.ReadValue();
    }

    private static Matrix<long> BuildMatrix(int targetSquare, SpiralMemoryMode mode)
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