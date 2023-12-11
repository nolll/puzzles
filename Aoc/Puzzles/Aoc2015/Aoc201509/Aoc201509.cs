using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2015.Aoc201509;

[Name("All in a Single Night")]
public class Aoc201509(string input) : AocPuzzle(input)
{
    protected override PuzzleResult RunPart1()
    {
        var calculator = new RouteCalculator(Input);
        return new PuzzleResult(calculator.ShortestDistance, "4cc29488fe313222695140cafd29224d");
    }

    protected override PuzzleResult RunPart2()
    {
        var calculator = new RouteCalculator(Input);
        return new PuzzleResult(calculator.LongestDistance, "6d5195b794f070d181a56006b064ff95");
    }
}