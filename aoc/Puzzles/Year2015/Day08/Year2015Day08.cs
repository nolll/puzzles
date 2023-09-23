using Aoc.Platform;
using Common.Puzzles;

namespace Aoc.Puzzles.Year2015.Day08;

public class Year2015Day08 : AocPuzzle
{
    public override string Name => "Matchsticks";

    protected override PuzzleResult RunPart1()
    {
        var digitalList = new DigitalList(FileInput);
        return new PuzzleResult(digitalList.CodeMinusMemoryDiff, 1342);
    }

    protected override PuzzleResult RunPart2()
    {
        var digitalList = new DigitalList(FileInput);
        return new PuzzleResult(digitalList.EncodedMinusCodeDiff, 2074);
    }
}