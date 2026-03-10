using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2020.Aoc202006;

[Name("Custom Customs")]
public class Aoc202006 : AocPuzzle
{
    [Puzzle("15504e0b1c6cbf2a51c9cae0ce1a7ec1")]
    public PuzzleResult Part1(string input)
    {
        var reader = new DeclarationFormReader(input);
        return new PuzzleResult(reader.SumOfAtLeastOneYes);
    }

    [Puzzle("68cdb9b46ee8ea4505031a144aef81d2")]
    public PuzzleResult Part2(string input)
    {
        var reader = new DeclarationFormReader(input);
        return new PuzzleResult(reader.SumOfAllYes);
    }
}