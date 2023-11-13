using Puzzles.common.Puzzles;

namespace Puzzles.aoc.Puzzles.Aoc2020.Aoc202005;

public class Aoc202005 : AocPuzzle
{
    public override string Name => "Binary Boarding";

    protected override PuzzleResult RunPart1()
    {
        var processor = new BoardingCardProcessor(InputFile);
        return new PuzzleResult(processor.HighestId, "0c707dd92ed04ceea0c32086af11620a");
    }

    protected override PuzzleResult RunPart2()
    {
        var processor = new BoardingCardProcessor(InputFile);
        var mySeat = processor.FindMySeat();
        return new PuzzleResult(mySeat?.Id, "886c488b39cd9f4848e5a6a2358861c6");
    }
}