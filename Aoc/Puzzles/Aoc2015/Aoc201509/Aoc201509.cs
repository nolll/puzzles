using Pzl.Tools.Puzzles;

namespace Pzl.Aoc.Puzzles.Aoc2015.Aoc201509;

public class Aoc201509 : AocPuzzle
{
    public override string Name => "All in a Single Night";

    protected override PuzzleResult RunPart1()
    {
        var calculator = new RouteCalculator(InputFile);
        return new PuzzleResult(calculator.ShortestDistance, "4cc29488fe313222695140cafd29224d");
    }

    protected override PuzzleResult RunPart2()
    {
        var calculator = new RouteCalculator(InputFile);
        return new PuzzleResult(calculator.LongestDistance, "6d5195b794f070d181a56006b064ff95");
    }
}