using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2015.Aoc201520;

[Name("Infinite Elves and Infinite Houses")]
public class Aoc201520 : AocPuzzle
{
    [Puzzle("0c8e60136d2393905b0cf33e2062864e")]
    public int Part1(string input) => new PresentDelivery().Deliver1(int.Parse(input), true);

    [Puzzle("ef369a6f63a7879f19640219124debe7")]
    public int Part2(string input) => new PresentDelivery().Deliver2(int.Parse(input));
}