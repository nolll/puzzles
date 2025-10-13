using Pzl.Common;
using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Euler.Puzzles.Euler028;

[Name("Number spiral diagonals")]
public class Euler028 : EulerPuzzle
{
    public PuzzleResult Run()
    {
        var result = Run(1001);
        return new PuzzleResult(result, "3966c6e62dfa03219f032ab903568901");
    }

    public int Run(int size)
    {
        var matrix = BuildMatrix(size);
        return CalculateDiagonalSum(matrix);
    }

    private static int CalculateDiagonalSum(Grid<int> grid)
    {
        var sum = 0;

        grid.MoveTo(0, 0);
        while (true)
        {
            sum += grid.ReadValue();
            if (grid.TryMoveRight())
                grid.MoveDown();
            else
                break;
        }

        grid.MoveTo(grid.Width - 1, 0);
        while (true)
        {
            sum += grid.ReadValue();
            if (grid.TryMoveLeft())
                grid.MoveDown();
            else
                break;
        }

        sum -= 1;

        return sum;
    }

    private static Grid<int> BuildMatrix(int size)
    {
        var i = 1;
        var matrix = new Grid<int>(1001, 1001);
        matrix.MoveTo(500, 500);
        matrix.WriteValue(i);
        matrix.TurnTo(GridDirection.Right);
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