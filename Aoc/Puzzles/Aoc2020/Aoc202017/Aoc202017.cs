using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2020.Aoc202017;

[Name("Conway Cubes")]
public class Aoc202017 : AocPuzzle
{
    [Puzzle("86fb7e6bf0dd282e332fdf0fe14cb572")]
    public int Part1(string input) => new ConwayCube().Boot3D(input, 6);

    [Puzzle("7d43e2d315b28ef823069e2b5aef74e8")]
    public int Part2(string input) => new ConwayCube().Boot4D(input, 6);
}