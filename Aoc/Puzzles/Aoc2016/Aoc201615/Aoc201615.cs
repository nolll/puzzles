using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2016.Aoc201615;

[Name("Timing is Everything")]
public class Aoc201615 : AocPuzzle
{
    protected override PuzzleResult RunPart1(string input)
    {
        var sculpture = new KineticSculpture(input);
        return new PuzzleResult(sculpture.TimeToPressButton, "c2b25510c1da608c5f3a22a5d84c55dd");
    }

    protected override PuzzleResult RunPart2(string input)
    {
        var sculpture = new KineticSculpture(input, true);
        return new PuzzleResult(sculpture.TimeToPressButton, "7e078d8dabad268a34def302abd59ce8");
    }
}