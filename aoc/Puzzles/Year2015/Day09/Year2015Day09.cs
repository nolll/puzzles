using Aoc.Platform;
using common.Puzzles;

namespace Aoc.Puzzles.Year2015.Day09;

public class Year2015Day09 : AocPuzzle
{
    public override string Name => "All in a Single Night";

    public override PuzzleResult RunPart1()
    {
        var calculator = new RouteCalculator(FileInput);
        return new PuzzleResult(calculator.ShortestDistance, 117);
    }

    public override PuzzleResult RunPart2()
    {
        var calculator = new RouteCalculator(FileInput);
        return new PuzzleResult(calculator.LongestDistance, 909);
    }
}