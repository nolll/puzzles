using Puzzles.common.Puzzles;
using Puzzles.common.Strings;

namespace Puzzles.aoc.Puzzles.Aoc2019.Aoc201903;

public class Aoc201903 : AocPuzzle
{
    public override string Name => "Crossed Wires";

    protected override PuzzleResult RunPart1()
    {
        var wirePaths = PuzzleInputReader.ReadLines(InputFile);
        var wirePathA = wirePaths[0];
        var wirePathB = wirePaths[1];

        var intersectionFinder = new IntersectionFinder(wirePathA, wirePathB);
        var distance = intersectionFinder.ClosestIntersection.Distance;
        return new PuzzleResult(distance, "3dbd15d37a682cfa1ca55525a248c184");
    }

    protected override PuzzleResult RunPart2()
    {
        var wirePaths = PuzzleInputReader.ReadLines(InputFile);
        var wirePathA = wirePaths[0];
        var wirePathB = wirePaths[1];

        var intersectionFinder = new IntersectionFinder(wirePathA, wirePathB);
        var steps = intersectionFinder.FewestSteps.Steps;
        return new PuzzleResult(steps, "51670676a41763c6093416dd009a8ba6");
    }
}