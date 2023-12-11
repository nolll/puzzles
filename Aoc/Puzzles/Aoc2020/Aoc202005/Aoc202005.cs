using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2020.Aoc202005;

[Name("Binary Boarding")]
public class Aoc202005(string input) : AocPuzzle(input)
{
    protected override PuzzleResult RunPart1()
    {
        var processor = new BoardingCardProcessor(Input);
        return new PuzzleResult(processor.HighestId, "0c707dd92ed04ceea0c32086af11620a");
    }

    protected override PuzzleResult RunPart2()
    {
        var processor = new BoardingCardProcessor(Input);
        var mySeat = processor.FindMySeat();
        return new PuzzleResult(mySeat?.Id, "886c488b39cd9f4848e5a6a2358861c6");
    }
}