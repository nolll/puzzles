using System.Linq;
using Aoc.Platform;

namespace Aoc.Puzzles.Year2020.Day01;

public class Year2020Day01 : Puzzle
{
    public override string Title => "Report Repair";

    public override PuzzleResult RunPart1()
    {
        var sumFinder = new SumFinder(FileInput);
        var numbers1 = sumFinder.FindNumbersThatAddUpTo(Target, 2);
        var product = numbers1.Aggregate(1, (a, b) => a * b);
        return new PuzzleResult(product, 365_619);
    }

    public override PuzzleResult RunPart2()
    {
        var sumFinder = new SumFinder(FileInput);
        var numbers = sumFinder.FindNumbersThatAddUpTo(Target, 3);
        var product = numbers.Aggregate(1, (a, b) => a * b);
        return new PuzzleResult(product, 236_873_508);
    }

    private const int Target = 2020;
}