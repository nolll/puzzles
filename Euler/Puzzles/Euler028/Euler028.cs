using Puzzles.Common.CoordinateSystems.CoordinateSystem2D;
using Puzzles.Common.Puzzles;

namespace Pzl.Euler.Puzzles.Euler028;

public class Euler028 : EulerPuzzle
{
    public override string Name => "Number spiral diagonals";

    protected override PuzzleResult Run()
    {
        var result = Run(1001);

        return new PuzzleResult(result, "3966c6e62dfa03219f032ab903568901");
    }

    public int Run(int size)
    {
        var matrix = BuildMatrix(size);
        return CalculateDiagonalSum(matrix);
    }

    private static int CalculateDiagonalSum(Matrix<int> matrix)
    {
        var sum = 0;

        matrix.MoveTo(0, 0);
        while (true)
        {
            sum += matrix.ReadValue();
            if (matrix.TryMoveRight())
                matrix.MoveDown();
            else
                break;
        }

        matrix.MoveTo(matrix.Width - 1, 0);
        while (true)
        {
            sum += matrix.ReadValue();
            if (matrix.TryMoveLeft())
                matrix.MoveDown();
            else
                break;
        }

        sum -= 1;

        return sum;
    }

    private static Matrix<int> BuildMatrix(int size)
    {
        var i = 1;
        var matrix = new Matrix<int>(1001, 1001);
        matrix.MoveTo(500, 500);
        matrix.WriteValue(i);
        matrix.TurnTo(MatrixDirection.Right);
        matrix.MoveForward();
        i++;
        matrix.WriteValue(i);
        i++;
        var max = size * size;

        while (i <= max)
        {
            matrix.TurnRight();
            matrix.MoveForward();
            if(matrix.ReadValue() > 0)
            {
                matrix.MoveBackward();
                matrix.TurnLeft();
                matrix.MoveForward();
            }

            matrix.WriteValue(i);

            i++;
        }

        return matrix;
    }
}