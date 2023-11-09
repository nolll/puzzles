using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2018.Aoc201810;

public class Aoc201810 : AocPuzzle
{
    public override string Name => "The Stars Align";

    protected override PuzzleResult RunPart1()
    {
        var finder = new StarMessageFinder(InputFile, 9);
        return new PuzzleResult(finder.Message, "fe599bdad14da318ee1e5741dda34bce");
    }

    protected override PuzzleResult RunPart2()
    {
        var finder = new StarMessageFinder(InputFile, 9);
        return new PuzzleResult(finder.IterationCount, "05ede0b8fbe47e6f4fba31b20085c653");
    }
}