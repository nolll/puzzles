using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2018.Aoc201810;

[Name("The Stars Align")]
public class Aoc201810 : AocPuzzle
{
    public PuzzleResult RunPart1(string input)
    {
        var finder = new StarMessageFinder(input, 9);
        return new PuzzleResult(finder.Message, "fe599bdad14da318ee1e5741dda34bce");
    }

    public PuzzleResult RunPart2(string input)
    {
        var finder = new StarMessageFinder(input, 9);
        return new PuzzleResult(finder.IterationCount, "05ede0b8fbe47e6f4fba31b20085c653");
    }
}