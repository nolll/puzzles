using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2021.Aoc202119;

[Name("Beacon Scanner")]
public class Aoc202119 : AocPuzzle
{
    [Puzzle("a6668fd005e7ebda4e124253eea1e56e")]
    public int Part1(string input) => new BeaconSystem().GetResult(input).BeaconCount;

    [Puzzle("ce2bc05651a369b5171388ec7e4f2438")]
    public int Part2(string input) => new BeaconSystem().GetResult(input).MaxDistance;
}