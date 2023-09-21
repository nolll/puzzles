using Aoc.Platform;

namespace Aoc.Puzzles.Year2015.Day08;

public class Year2015Day08 : Puzzle
{
    public override string Title => "Matchsticks";

    public override PuzzleResult RunPart1()
    {
        var digitalList = new DigitalList(FileInput);
        return new PuzzleResult(digitalList.CodeMinusMemoryDiff, 1342);
    }

    public override PuzzleResult RunPart2()
    {
        var digitalList = new DigitalList(FileInput);
        return new PuzzleResult(digitalList.EncodedMinusCodeDiff, 2074);
    }
}