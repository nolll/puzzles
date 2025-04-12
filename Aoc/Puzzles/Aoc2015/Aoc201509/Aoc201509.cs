using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2015.Aoc201509;

[Name("All in a Single Night")]
public class Aoc201509 : AocPuzzle
{
    public PuzzleResult Part1(string input)
    {
        var calculator = new RouteCalculator(input);
        return new PuzzleResult(calculator.ShortestDistance, "4cc29488fe313222695140cafd29224d");
    }

    public PuzzleResult Part2(string input)
    {
        var calculator = new RouteCalculator(input);
        return new PuzzleResult(calculator.LongestDistance, "6d5195b794f070d181a56006b064ff95");
    }
}