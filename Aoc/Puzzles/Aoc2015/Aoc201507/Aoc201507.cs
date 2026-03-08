using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2015.Aoc201507;

[Name("Some Assembly Required")]
public class Aoc201507 : AocPuzzle
{
    [Puzzle("d726fcd2e75525a2fa0a5c741cc7582f")]
    public int Part1(string input) => new Circuit(input).RunOne("a");

    [Puzzle("135c8ac6a573e214fabaf9728fc2cddb")]
    public int Part2(string input) => new Circuit(input).RunTwo("a", "b");
}