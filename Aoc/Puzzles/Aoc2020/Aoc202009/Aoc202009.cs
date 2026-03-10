using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2020.Aoc202009;

[Name("Encoding Error")]
public class Aoc202009 : AocPuzzle
{
    [Puzzle("6c1a0cf69a058bbc7f0efbe438d2f8e7")]
    public PuzzleResult Part1(string input)
    {
        var port = new XmasPort(input, 25);
        var invalidNumber = port.FindFirstInvalidNumber();
        return new PuzzleResult(invalidNumber);
    }

    [Puzzle("b6c20cca8f108e6c19637716982ff96f")]
    public PuzzleResult Part2(string input)
    {
        var port = new XmasPort(input, 25);
        var weakness = port.FindWeakness();
        return new PuzzleResult(weakness);
    }
}