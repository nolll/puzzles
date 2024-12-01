using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2019.Aoc201903;

[Name("Crossed Wires")]
public class Aoc201903 : AocPuzzle
{
    protected override PuzzleResult RunPart1(string input)
    {
        var wirePaths = StringReader.ReadLines(input);
        var wirePathA = wirePaths[0];
        var wirePathB = wirePaths[1];

        var intersectionFinder = new IntersectionFinder(wirePathA, wirePathB);
        var distance = intersectionFinder.ClosestIntersection.Distance;
        return new PuzzleResult(distance, "3dbd15d37a682cfa1ca55525a248c184");
    }

    protected override PuzzleResult RunPart2(string input)
    {
        var wirePaths = StringReader.ReadLines(input);
        var wirePathA = wirePaths[0];
        var wirePathB = wirePaths[1];

        var intersectionFinder = new IntersectionFinder(wirePathA, wirePathB);
        var steps = intersectionFinder.FewestSteps.Steps;
        return new PuzzleResult(steps, "51670676a41763c6093416dd009a8ba6");
    }
}