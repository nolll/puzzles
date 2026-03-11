using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2021.Aoc202122;

[Name("Reactor Reboot")]
public class Aoc202122 : AocPuzzle
{
    [Puzzle("f49f5f28c7496f86abfeaed9d077e669")]
    public long Part1(string input) => new SubmarineReactor().Reboot2(input, 50);

    [Puzzle("1b4e931c995f2d8296dc20828a66283b")]
    public long Part2(string input) => new SubmarineReactor().Reboot2(input);
}