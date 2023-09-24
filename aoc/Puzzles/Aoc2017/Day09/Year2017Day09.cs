using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2017.Day09;

public class Year2017Day09 : AocPuzzle
{
    public override string Name => "Stream Processing";

    protected override PuzzleResult RunPart1()
    {
        var processor = new StreamProcessor(InputFile);
        return new PuzzleResult(processor.Score, 14_421);
    }

    protected override PuzzleResult RunPart2()
    {
        var processor = new StreamProcessor(InputFile);
        return new PuzzleResult(processor.GarbageCount, 6817);
    }
}