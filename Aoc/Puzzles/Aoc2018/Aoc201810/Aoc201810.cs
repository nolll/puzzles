using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2018.Aoc201810;

[Name("The Stars Align")]
public class Aoc201810 : AocPuzzle
{
    [Puzzle("fe599bdad14da318ee1e5741dda34bce")]
    public string Part1(string input) => new StarMessageFinder(input, 9).Message;

    [Puzzle("05ede0b8fbe47e6f4fba31b20085c653")]
    public int Part2(string input) => new StarMessageFinder(input, 9).IterationCount;
}