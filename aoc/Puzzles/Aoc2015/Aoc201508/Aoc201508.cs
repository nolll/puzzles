using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2015.Aoc201508;

public class Aoc201508 : AocPuzzle
{
    public override string Name => "Matchsticks";

    protected override PuzzleResult RunPart1()
    {
        var digitalList = new DigitalList(InputFile);
        return new PuzzleResult(digitalList.CodeMinusMemoryDiff, "d1ca0ea6d28dd7f5e3d1551600b6b2c5");
    }

    protected override PuzzleResult RunPart2()
    {
        var digitalList = new DigitalList(InputFile);
        return new PuzzleResult(digitalList.EncodedMinusCodeDiff, "6ea0bb2ac1526f96307f0eeb8c4d25b7");
    }
}