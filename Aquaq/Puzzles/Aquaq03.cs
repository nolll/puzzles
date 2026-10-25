using Pzl.Common;
using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Aquaq.Puzzles;

[Name("Short walks")]
public class Aquaq03 : AquaqPuzzle
{
    [Puzzle("3fdb562cfba1d01d5ae2817d476f3120")]
    public int Solve(string input)
    {
        var sum = 0;
        var grid = GridBuilder.BuildCharGridWithoutTrim(Room);
        grid.MoveTo(2, 0);

        foreach (var c in input)
        {
            Move(grid, c);
            sum += grid.Coord.X + grid.Coord.Y;
        }

        return sum;
    }

    private static void Move(Grid<char> grid, char c)
    {
        Turn(grid, c);
        grid.TryMoveForward();
        if (grid.ReadValue() == ' ')
            grid.MoveBackward();
    }

    private static void Turn(Grid<char> grid, char c) => grid.TurnTo(GetDirection(c));

    private static GridDirection GetDirection(char c) => c switch
    {
        'U' => GridDirection.Up,
        'R' => GridDirection.Right,
        'D' => GridDirection.Down,
        _ => GridDirection.Left
    };

    private const string Room = """
                                  ##  
                                 #### 
                                ######
                                ######
                                 #### 
                                  ##  
                                """;
}