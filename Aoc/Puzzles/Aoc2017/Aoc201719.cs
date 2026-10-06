using System.Text;
using Pzl.Common;
using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Aoc.Puzzles.Aoc2017;

[Name("A Series of Tubes")]
public class Aoc201719 : AocPuzzle
{
    private const char Space = ' ';
    private const char Empty = '.';
    private const char Vertical = '|';
    private const char Horizontal = '-';
    private const char Plus = '+';
    
    [Puzzle("36064495be39a4cd3633df813ec64919")]
    public string Part1(string input)
    {
        var (route, _) = FindRoute(input);
        return route;
    }

    [Puzzle("b6a57d5dbd470ae22225f4116dc39da0")]
    public int Part2(string input)
    {
        var (_, stepCount) = FindRoute(input);
        return stepCount;
    }

    public (string, int) FindRoute(string input)
    {
        var stepCount = 0;
        var route = new StringBuilder();

        var adjustedInput = input.Replace(Space, Empty);
        var grid = GridBuilder.BuildCharGrid(adjustedInput);
        var y = 0;
        var x = grid.Values.ToList().IndexOf(Vertical);
        grid.MoveTo(x, y);
        grid.TurnTo(GridDirection.Down);

        while (true)
        {
            var val = grid.ReadValue();

            if (val == Empty)
                break;

            stepCount++;

            if (val is Vertical or Horizontal)
            {
                grid.MoveForward();
                continue;
            }

            if (val == Plus)
            {
                grid.TurnLeft();
                grid.MoveForward();
                var invalidChar = grid.Direction.Equals(GridDirection.Left) || grid.Direction.Equals(GridDirection.Right)
                    ? Vertical
                    : Horizontal;

                var tempVal = grid.ReadValue();
                if (tempVal == invalidChar || tempVal == Empty)
                {
                    grid.MoveBackward();
                    grid.TurnLeft();
                    grid.TurnLeft();
                }
                else
                {
                    grid.MoveBackward();
                }

                grid.MoveForward();
                continue;
            }

            route.Append(val);
            grid.MoveForward();
        }

        return (route.ToString(), stepCount);
    }
}