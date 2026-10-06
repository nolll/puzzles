using Pzl.Common;
using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Aoc.Puzzles.Aoc2017;

[Name("Sporifica Virus")]
public class Aoc201722 : AocPuzzle
{
    private const char Clean = '.';
    private const char Weakened = 'W';
    private const char Infected = '#';
    private const char Flagged = 'F';
    
    [Puzzle("ae293a43b47d6820d75321581ad234d0")]
    public int Part1(string input) => RunPart1(input, 10_000);

    [Puzzle("890e30fb9efa1c72b53fa911a105caa2")]
    public int Part2(string input) => RunPart2(input, 10_000_000);

    public int RunPart1(string input, int iterations)
    {
        var infectionCount = 0;
        var grid = BuildGrid(input);
        for (var i = 0; i < iterations; i++)
        {
            var val = grid.ReadValue();
            if (val == Infected)
            {
                grid.TurnRight();
                grid.WriteValue(Clean);
            }
            else
            {
                grid.TurnLeft();
                grid.WriteValue(Infected);
                infectionCount++;
            }

            grid.MoveForward();
        }

        return infectionCount;
    }

    public int RunPart2(string input, int iterations)
    {
        var infectionCount = 0;
        var grid = BuildGrid(input);
        for (var i = 0; i < iterations; i++)
        {
            var val = grid.ReadValue();
            if (val == Clean)
            {
                grid.TurnLeft();
                grid.WriteValue(Weakened);
            }
            else if (val == Weakened)
            {
                grid.WriteValue(Infected);
                infectionCount++;
            }
            else if (val == Infected)
            {
                grid.TurnRight();
                grid.WriteValue(Flagged);
            }
            else
            {
                grid.TurnRight();
                grid.TurnRight();
                grid.WriteValue(Clean);
            }

            grid.MoveForward();
        }

        return infectionCount;
    }
    
    private static Grid<char> BuildGrid(string input)
    {
        var grid = GridBuilder.BuildCharGrid(input, '.');
        grid.MoveTo(GetMidpoint(grid.Width), GetMidpoint(grid.Height));
        grid.TurnTo(GridDirection.Up);
        return grid;
    }

    private static int GetMidpoint(int length) => (length - 1) / 2;
}