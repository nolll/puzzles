using Aoc.Platform;
using common.Puzzles;

namespace Aoc.Puzzles.Year2020.Day05;

public class Year2020Day05 : AocPuzzle
{
    public override string Name => "Binary Boarding";

    protected override PuzzleResult RunPart1()
    {
        var processor = new BoardingCardProcessor(FileInput);
        return new PuzzleResult(processor.HighestId, 953);
    }

    protected override PuzzleResult RunPart2()
    {
        var processor = new BoardingCardProcessor(FileInput);
        var mySeat = processor.FindMySeat();
        return new PuzzleResult(mySeat.Id, 615);
    }
}