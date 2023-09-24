using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2020.Day08;

public class Year2020Day08 : AocPuzzle
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