using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2017.Aoc201707;

[Name("Recursive Circus")]
public class Aoc201707 : AocPuzzle
{
    public PuzzleResult RunPart1(string input)
    {
        var towers = new RecursiveTowers(input);
        return new PuzzleResult(towers.BottomName, "7005dac413613feef76e5931331aac39");
    }

    public PuzzleResult RunPart2(string input)
    {
        var towers = new RecursiveTowers(input);
        return new PuzzleResult(towers.AdjustedWeight, "a431cfa493227f90dd341325e0c8992b");
    }
}