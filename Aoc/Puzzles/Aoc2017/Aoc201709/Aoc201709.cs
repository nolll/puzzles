using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2017.Aoc201709;

[Name("Stream Processing")]
public class Aoc201709 : AocPuzzle
{
    [Puzzle("bf1171e2cba9455c97359e9a72e8586f")]
    public int Part1(string input) => new StreamProcessor(input).Score;

    [Puzzle("ff9d742fc8ce537c4cc9bfc6414c7ed6")]
    public int Part2(string input) => new StreamProcessor(input).GarbageCount;
}