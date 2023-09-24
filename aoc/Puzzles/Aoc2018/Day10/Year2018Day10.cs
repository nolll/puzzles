using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2018.Day10;

public class Year2018Day10 : AocPuzzle
{
    public override string Name => "The Stars Align";

    protected override PuzzleResult RunPart1()
    {
        var finder = new StarMessageFinder(InputFile, 9);
        return new PuzzleResult(finder.Message, "HRPHBRKG");
    }

    protected override PuzzleResult RunPart2()
    {
        var finder = new StarMessageFinder(InputFile, 9);
        return new PuzzleResult(finder.IterationCount, 10355);
    }
}