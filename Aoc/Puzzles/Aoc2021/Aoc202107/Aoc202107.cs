using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2021.Aoc202107;

[Name("The Treachery of Whales")]
public class Aoc202107 : AocPuzzle
{
    protected override PuzzleResult RunPart1()
    {
        var crabSubmarines = new CrabSubmarines();
        var result = crabSubmarines.GetFuel1(InputFile, false);
        return new PuzzleResult(result, "666d31015d60e4cd37891ed574d5227f");
    }

    protected override PuzzleResult RunPart2()
    {
        var crabSubmarines = new CrabSubmarines();
        var result = crabSubmarines.GetFuel1(InputFile, true);
        return new PuzzleResult(result, "7930686503708646dfb6d7f6a7e36ab2");
    }
}