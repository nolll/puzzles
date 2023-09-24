using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2020.Aoc202005;

public class Year2020Day05 : AocPuzzle
{
    public override string Name => "Binary Boarding";

    protected override PuzzleResult RunPart1()
    {
        var processor = new BoardingCardProcessor(InputFile);
        return new PuzzleResult(processor.HighestId, 953);
    }

    protected override PuzzleResult RunPart2()
    {
        var processor = new BoardingCardProcessor(InputFile);
        var mySeat = processor.FindMySeat();
        return new PuzzleResult(mySeat?.Id, 615);
    }
}