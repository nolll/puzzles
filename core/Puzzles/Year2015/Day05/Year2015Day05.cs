using Core.Platform;

namespace Core.Puzzles.Year2015.Day05;

public class Year2015Day05 : Puzzle
{
    public override string Title => "Doesn't He Have Intern-Elves For This?";

    public override PuzzleResult RunPart1()
    {
        var niceCount = NaughtyOrNiceEvaluator.GetNiceCount1(FileInput);
        return new PuzzleResult(niceCount, 255);
    }

    public override PuzzleResult RunPart2()
    {
        var niceCount = NaughtyOrNiceEvaluator.GetNiceCount2(FileInput);
        return new PuzzleResult(niceCount, 55);
    }
}