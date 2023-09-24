using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2016.Aoc201615;

public class Year2016Day15 : AocPuzzle
{
    public override string Name => "Timing is Everything";

    protected override PuzzleResult RunPart1()
    {
        var sculpture = new KineticSculpture(InputFile);
        return new PuzzleResult(sculpture.TimeToPressButton, 317_371);
    }

    protected override PuzzleResult RunPart2()
    {
        var sculpture = new KineticSculpture(InputFile, true);
        return new PuzzleResult(sculpture.TimeToPressButton, 2_080_951);
    }
}