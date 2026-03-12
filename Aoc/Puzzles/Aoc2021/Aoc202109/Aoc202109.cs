using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2021.Aoc202109;

[Name("Smoke Basin")]
public class Aoc202109 : AocPuzzle
{
    [Puzzle("de7031e6bc6f92fb3ebea43ee2b3fe27")]
    public int Part1(string input) => new HeightMap().FindLowPointSum(input);

    [Puzzle("1079be915c188387b9068d26a9911fcc")]
    public int Part2(string input) => new HeightMap().FindBasinSizes(input);
}