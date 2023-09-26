using System.Linq;
using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2020.Aoc202001;

public class Aoc202001 : AocPuzzle
{
    public override string Name => "Report Repair";

    protected override PuzzleResult RunPart1()
    {
        var sumFinder = new SumFinder(InputFile);
        var numbers1 = sumFinder.FindNumbersThatAddUpTo(Target, 2);
        var product = numbers1.Aggregate(1, (a, b) => a * b);
        return new PuzzleResult(product, 365_619);
    }

    protected override PuzzleResult RunPart2()
    {
        var sumFinder = new SumFinder(InputFile);
        var numbers = sumFinder.FindNumbersThatAddUpTo(Target, 3);
        var product = numbers.Aggregate(1, (a, b) => a * b);
        return new PuzzleResult(product, 236_873_508);
    }

    private const int Target = 2020;
}