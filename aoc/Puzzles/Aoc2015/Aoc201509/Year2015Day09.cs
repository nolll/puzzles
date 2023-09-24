using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2015.Aoc201509;

public class Year2015Day09 : AocPuzzle
{
    public override string Name => "All in a Single Night";

    protected override PuzzleResult RunPart1()
    {
        var calculator = new RouteCalculator(InputFile);
        return new PuzzleResult(calculator.ShortestDistance, 117);
    }

    protected override PuzzleResult RunPart2()
    {
        var calculator = new RouteCalculator(InputFile);
        return new PuzzleResult(calculator.LongestDistance, 909);
    }
}