using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2015.Aoc201508;

public class Aoc201508 : AocPuzzle
{
    public override string Name => "Matchsticks";

    protected override PuzzleResult RunPart1()
    {
        var digitalList = new DigitalList(InputFile);
        return new PuzzleResult(digitalList.CodeMinusMemoryDiff, 1342);
    }

    protected override PuzzleResult RunPart2()
    {
        var digitalList = new DigitalList(InputFile);
        return new PuzzleResult(digitalList.EncodedMinusCodeDiff, 2074);
    }
}