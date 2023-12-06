using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2016.Aoc201613;

public class Aoc201613 : AocPuzzle
{
    public override string Name => "A Maze of Twisty Little Cubicles";

    protected override PuzzleResult RunPart1()
    {
        var maze = new Maze(50, 50, Input);
        var stepCount = maze.StepCountToTarget(31, 39);
        return new PuzzleResult(stepCount, "7cedb689517199a6fa49637072deb141");
    }

    protected override PuzzleResult RunPart2()
    {
        var maze = new Maze(75, 75, Input);
        var locationCount = maze.LocationCountAfter(50);
        return new PuzzleResult(locationCount, "d8ee6b0475f3971b598eab03bf31bed4");
    }

    private const int Input = 1362;
}