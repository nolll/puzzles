using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2021.Aoc202107;

[Name("The Treachery of Whales")]
public class Aoc202107 : AocPuzzle
{
    public PuzzleResult RunPart1(string input)
    {
        var crabSubmarines = new CrabSubmarines();
        var result = crabSubmarines.GetFuel1(input, false);
        return new PuzzleResult(result, "666d31015d60e4cd37891ed574d5227f");
    }

    public PuzzleResult RunPart2(string input)
    {
        var crabSubmarines = new CrabSubmarines();
        var result = crabSubmarines.GetFuel1(input, true);
        return new PuzzleResult(result, "7930686503708646dfb6d7f6a7e36ab2");
    }
}