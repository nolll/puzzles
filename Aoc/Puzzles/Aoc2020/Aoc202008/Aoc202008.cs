using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2020.Aoc202008;

[Name("Handheld Halting")]
public class Aoc202008 : AocPuzzle
{
    protected override PuzzleResult RunPart1(string input)
    {
        var console = new GameConsoleRunner(input);
        var acc = console.RunUntilLoop();
        return new PuzzleResult(acc, "2a2e64378fc4cf027efb60009544e68b");
    }

    protected override PuzzleResult RunPart2(string input)
    {
        var console = new GameConsoleRunner(input);
        var acc = console.RunUntilTermination();
        return new PuzzleResult(acc, "e903a634ebeec273f64636f8b241c21b");
    }
}