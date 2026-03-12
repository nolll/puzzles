using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2021.Aoc202118;

[Name("Snailfish")]
public class Aoc202118 : AocPuzzle
{
    [Puzzle("1d3da7fb83304ae6368c25c4835fb0af")]
    public int Part1(string input) => new SnailfishMath().Sum(input).Magnitude;

    [Puzzle("a9626bd58c604514d0e274952464ba7d")]
    public int Part2(string input) => new SnailfishMath().LargestMagnitude(input);
}