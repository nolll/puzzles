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
        var grid = BuildGrid(size);
        return CalculateDiagonalSum(grid);
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

    private static Grid<int> BuildGrid(int size)
    {
        var i = 1;
        var grid = new Grid<int>(1001, 1001);
        grid.MoveTo(500, 500);
        grid.WriteValue(i);
        grid.TurnTo(GridDirection.Right);
        grid.MoveForward();
        i++;
        grid.WriteValue(i);
        i++;
        var max = size * size;

        while (i <= max)
        {
            grid.TurnRight();
            grid.MoveForward();
            if(grid.ReadValue() > 0)
            {
                grid.MoveBackward();
                grid.TurnLeft();
                grid.MoveForward();
            }

            grid.WriteValue(i);

            i++;
        }

        return grid;
    }
}