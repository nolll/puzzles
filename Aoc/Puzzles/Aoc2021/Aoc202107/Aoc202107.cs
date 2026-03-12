using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2021.Aoc202107;

[Name("The Treachery of Whales")]
public class Aoc202107 : AocPuzzle
{
    [Puzzle("666d31015d60e4cd37891ed574d5227f")]
    public int Part1(string input) => new CrabSubmarines().GetFuel(input, false);

    [Puzzle("7930686503708646dfb6d7f6a7e36ab2")]
    public int Part2(string input) => new CrabSubmarines().GetFuel(input, true);
}