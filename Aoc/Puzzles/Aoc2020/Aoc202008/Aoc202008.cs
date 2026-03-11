using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2020.Aoc202008;

[Name("Handheld Halting")]
public class Aoc202008 : AocPuzzle
{
    [Puzzle("2a2e64378fc4cf027efb60009544e68b")]
    public int Part1(string input) => new GameConsoleRunner(input).RunUntilLoop();

    [Puzzle("e903a634ebeec273f64636f8b241c21b")]
    public int Part2(string input) => new GameConsoleRunner(input).RunUntilTermination();
}