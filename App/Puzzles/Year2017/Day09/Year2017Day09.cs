using App.Platform;

namespace App.Puzzles.Year2017.Day09;

public class Year2017Day09 : Puzzle
{
    public override PuzzleResult RunPart1()
    {
        var processor = new StreamProcessor(FileInput);
        return new PuzzleResult(processor.Score, 14_421);
    }

    public override PuzzleResult RunPart2()
    {
        var processor = new StreamProcessor(FileInput);
        return new PuzzleResult(processor.GarbageCount, 6817);
    }
}