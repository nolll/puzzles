using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2021.Aoc202104;

[Name("Giant Squid")]
public class Aoc202104 : AocPuzzle
{
    [Puzzle("95287604b1b5cd043b3268068d4c34ef")]
    public int Part1(string input) => new BingoGame(input).Play(false);

    [Puzzle("d3b6f7e7618d28f0aac8b2a2c99f5b2e")]
    public int Part2(string input) => new BingoGame(input).Play(true);
}