using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2015.Aoc201512;

[Name("JSAbacusFramework.io")]
public class Aoc201512 : AocPuzzle
{
    [Puzzle("72e4a93f95510bb5f9d0b20360676111")]
    public int Part1(string input) => new JsonDoc(input, true).Sum;

    [Puzzle("c5934cc2e7d3cc9b1183329d8d2f1d82")]
    public int Part2(string input) => new JsonDoc(input, false).Sum;
}