using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2016.Aoc201613;

[Name("A Maze of Twisty Little Cubicles")]
public class Aoc201613(string input) : AocPuzzle(input)
{
    private int IntInput => int.Parse(Input);

    protected override PuzzleResult RunPart1()
    {
        var maze = new Maze(50, 50, IntInput);
        var stepCount = maze.StepCountToTarget(31, 39);
        return new PuzzleResult(stepCount, "7cedb689517199a6fa49637072deb141");
    }

    protected override PuzzleResult RunPart2()
    {
        var maze = new Maze(75, 75, IntInput);
        var locationCount = maze.LocationCountAfter(50);
        return new PuzzleResult(locationCount, "d8ee6b0475f3971b598eab03bf31bed4");
    }
}