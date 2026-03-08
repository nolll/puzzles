using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2016.Aoc201621;

[Name("Scrambled Letters and Hash")]
public class Aoc201621 : AocPuzzle
{
    [Puzzle("d23262df6c0ae121dad862c4941b0e84")]
    public string Part1(string input) => new StringScrambler(input).Scramble("abcdefgh");

    [Puzzle("c7601768c42b9f9aa8cbb994da21b9fd")]
    public string Part2(string input) => new StringScrambler(input).Unscramble("fbgdceah");
}