using Puzzles.Common.Puzzles;

namespace Pzl.Aoc.Puzzles.Aoc2016.Aoc201615;

public class Aoc201615 : AocPuzzle
{
    public override string Name => "Timing is Everything";

    protected override PuzzleResult RunPart1()
    {
        var sculpture = new KineticSculpture(InputFile);
        return new PuzzleResult(sculpture.TimeToPressButton, "c2b25510c1da608c5f3a22a5d84c55dd");
    }

    protected override PuzzleResult RunPart2()
    {
        var sculpture = new KineticSculpture(InputFile, true);
        return new PuzzleResult(sculpture.TimeToPressButton, "7e078d8dabad268a34def302abd59ce8");
    }
}