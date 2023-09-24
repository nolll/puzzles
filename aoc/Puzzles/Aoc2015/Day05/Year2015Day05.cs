using Common.Puzzles;

namespace Aoc.Puzzles.Year2015.Day05;

public class Year2015Day05 : AocPuzzle
{
    public override string Name => "Doesn't He Have Intern-Elves For This?";

    protected override PuzzleResult RunPart1()
    {
        var niceCount = NaughtyOrNiceEvaluator.GetNiceCount1(InputFile);
        return new PuzzleResult(niceCount, 255);
    }

    protected override PuzzleResult RunPart2()
    {
        var niceCount = NaughtyOrNiceEvaluator.GetNiceCount2(InputFile);
        return new PuzzleResult(niceCount, 55);
    }
}