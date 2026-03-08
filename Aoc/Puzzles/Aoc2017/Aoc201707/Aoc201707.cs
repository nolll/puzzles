using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2017.Aoc201707;

[Name("Recursive Circus")]
public class Aoc201707 : AocPuzzle
{
    [Puzzle("7005dac413613feef76e5931331aac39")]
    public string Part1(string input)
    {
        var towers = new RecursiveTowers(input);
        return towers.BottomName ?? "";
    }

    [Puzzle("a431cfa493227f90dd341325e0c8992b")]
    public int Part2(string input) => new RecursiveTowers(input).AdjustedWeight;
}