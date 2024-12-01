using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2020.Aoc202006;

[Name("Custom Customs")]
public class Aoc202006 : AocPuzzle
{
    public PuzzleResult RunPart1(string input)
    {
        var reader = new DeclarationFormReader(input);
        return new PuzzleResult(reader.SumOfAtLeastOneYes, "15504e0b1c6cbf2a51c9cae0ce1a7ec1");
    }

    public PuzzleResult RunPart2(string input)
    {
        var reader = new DeclarationFormReader(input);
        return new PuzzleResult(reader.SumOfAllYes, "68cdb9b46ee8ea4505031a144aef81d2");
    }
}