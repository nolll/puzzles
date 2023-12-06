using Pzl.Tools.Puzzles;

namespace Pzl.Aoc.Puzzles.Aoc2020.Aoc202006;

public class Aoc202006 : AocPuzzle
{
    public override string Name => "Custom Customs";

    protected override PuzzleResult RunPart1()
    {
        var reader = new DeclarationFormReader(InputFile);
        return new PuzzleResult(reader.SumOfAtLeastOneYes, "15504e0b1c6cbf2a51c9cae0ce1a7ec1");
    }

    protected override PuzzleResult RunPart2()
    {
        var reader = new DeclarationFormReader(InputFile);
        return new PuzzleResult(reader.SumOfAllYes, "68cdb9b46ee8ea4505031a144aef81d2");
    }
}