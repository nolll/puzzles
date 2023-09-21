using Aoc.Platform;

namespace Aoc.Puzzles.Year2018.Day10;

public class Year2018Day10 : Puzzle
{
    public override string Title => "The Stars Align";

    public override PuzzleResult RunPart1()
    {
        var finder = new StarMessageFinder(FileInput, 9);
        return new PuzzleResult(finder.Message, "HRPHBRKG");
    }

    public override PuzzleResult RunPart2()
    {
        var finder = new StarMessageFinder(FileInput, 9);
        return new PuzzleResult(finder.IterationCount, 10355);
    }
}