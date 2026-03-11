using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2022.Aoc202217;

[Name("Pyroclastic Flow")]
public class Aoc202217 : AocPuzzle
{
    [Puzzle("cdc90a19ac724ffd4fa126a641706d13")]
    public long Part1(string input) => new Tetris().Run(input, 2022);

    [Puzzle("3a90eb3ba5f3fc471fa832e199a1b7f9")]
    public long Part2(string input) => new Tetris().Run(input, 1_000_000_000_000);
}   