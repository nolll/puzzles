using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2020.Aoc202009;

[Name("Encoding Error")]
public class Aoc202009 : AocPuzzle
{
    [Puzzle("6c1a0cf69a058bbc7f0efbe438d2f8e7")]
    public long Part1(string input) => new XmasPort(input, 25).FindFirstInvalidNumber();

    [Puzzle("b6c20cca8f108e6c19637716982ff96f")]
    public long Part2(string input) => new XmasPort(input, 25).FindWeakness();
}