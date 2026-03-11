using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2021.Aoc202106;

[Name("Lanternfish")]
public class Aoc202106 : AocPuzzle
{
    [Puzzle("f41058112a3490c1842a14e75ebfef8c")]
    public long Part1(string input) => new FishCounter(input).FishCountAfter(80);

    [Puzzle("d49cf732d5285745340ba70c6a3ddc15")]
    public long Part2(string input) => new FishCounter(input).FishCountAfter(256);
}