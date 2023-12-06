using Pzl.Tools.Puzzles;

namespace Pzl.Aoc.Puzzles.Aoc2020.Aoc202008;

public class Aoc202008 : AocPuzzle
{
    public override string Name => "Handheld Halting";

    protected override PuzzleResult RunPart1()
    {
        var console = new GameConsoleRunner(InputFile);
        var acc = console.RunUntilLoop();
        return new PuzzleResult(acc, "2a2e64378fc4cf027efb60009544e68b");
    }

    protected override PuzzleResult RunPart2()
    {
        var console = new GameConsoleRunner(InputFile);
        var acc = console.RunUntilTermination();
        return new PuzzleResult(acc, "e903a634ebeec273f64636f8b241c21b");
    }
}