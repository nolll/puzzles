using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2021.Aoc202121;

[Name("Dirac Dice")]
public class Aoc202121 : AocPuzzle
{
    [Puzzle("97097680a3e3bcba7ebb46d172476cd9")]
    public int Part1(string input) => new DiracDiceGame().Play(8, 2).Result;

    [Puzzle("677e241c3997b2a9a5c99891d90399f3")]
    public long Part2(string input) => new RealDiracDiceGame().Play(8, 2);
}