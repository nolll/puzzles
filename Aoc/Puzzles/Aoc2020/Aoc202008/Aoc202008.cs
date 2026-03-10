using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2020.Aoc202008;

[Name("Handheld Halting")]
public class Aoc202008 : AocPuzzle
{
    [Puzzle("2a2e64378fc4cf027efb60009544e68b")]
    public PuzzleResult Part1(string input)
    {
        var console = new GameConsoleRunner(input);
        var acc = console.RunUntilLoop();
        return new PuzzleResult(acc);
    }

    [Puzzle("e903a634ebeec273f64636f8b241c21b")]
    public PuzzleResult Part2(string input)
    {
        var console = new GameConsoleRunner(input);
        var acc = console.RunUntilTermination();
        return new PuzzleResult(acc);
    }
}