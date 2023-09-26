using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2020.Aoc202008;

public class Aoc202008 : AocPuzzle
{
    public override string Name => "Handheld Halting";

    protected override PuzzleResult RunPart1()
    {
        var console = new GameConsoleRunner(InputFile);
        var acc = console.RunUntilLoop();
        return new PuzzleResult(acc, 1446);
    }

    protected override PuzzleResult RunPart2()
    {
        var console = new GameConsoleRunner(InputFile);
        var acc = console.RunUntilTermination();
        return new PuzzleResult(acc, 1403);
    }
}