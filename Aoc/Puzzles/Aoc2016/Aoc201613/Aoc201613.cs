using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2016.Aoc201613;

[Name("A Maze of Twisty Little Cubicles")]
public class Aoc201613 : AocPuzzle
{
    protected override PuzzleResult RunPart1(string input)
    {
        var maze = new Maze(50, 50, int.Parse(input));
        var stepCount = maze.StepCountToTarget(31, 39);
        return new PuzzleResult(stepCount, "7cedb689517199a6fa49637072deb141");
    }

    protected override PuzzleResult RunPart2(string input)
    {
        var maze = new Maze(75, 75, int.Parse(input));
        var locationCount = maze.LocationCountAfter(50);
        return new PuzzleResult(locationCount, "d8ee6b0475f3971b598eab03bf31bed4");
    }
}