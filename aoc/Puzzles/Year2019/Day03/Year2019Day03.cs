using Common.Puzzles;
using Common.Strings;

namespace Aoc.Puzzles.Year2019.Day03;

public class Year2019Day03 : AocPuzzle
{
    public override string Name => "Crossed Wires";

    protected override PuzzleResult RunPart1()
    {
        var wirePaths = PuzzleInputReader.ReadLines(FileInput);
        var wirePathA = wirePaths[0];
        var wirePathB = wirePaths[1];

        var intersectionFinder = new IntersectionFinder(wirePathA, wirePathB);
        var distance = intersectionFinder.ClosestIntersection.Distance;
        return new PuzzleResult(distance, 865);
    }

    protected override PuzzleResult RunPart2()
    {
        var wirePaths = PuzzleInputReader.ReadLines(FileInput);
        var wirePathA = wirePaths[0];
        var wirePathB = wirePaths[1];

        var intersectionFinder = new IntersectionFinder(wirePathA, wirePathB);
        var steps = intersectionFinder.FewestSteps.Steps;
        return new PuzzleResult(steps, 35_038);
    }
}