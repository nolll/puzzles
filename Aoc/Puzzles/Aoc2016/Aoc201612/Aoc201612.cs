using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2016.Aoc201612;

[Name("Leonardo's Monorail")]
public class Aoc201612 : AocPuzzle
{
    [Puzzle("4ba2fa440d50bec300e43771065afd61")]
    public int Part1(string input) => new MonorailComputer(input, 0, 0).ValueA;

    [Puzzle("5c02e7d4176ed51a799484797ba99661")]
    public int Part2(string input) => new MonorailComputer(input, 0, 1).ValueA;
}