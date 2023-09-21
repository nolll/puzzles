using Aoc.Platform;
using common.Puzzles;

namespace Aoc.Puzzles.Year2016.Day15;

public class Year2016Day15 : AocPuzzle
{
    public override string Title => "Timing is Everything";

    public override PuzzleResult RunPart1()
    {
        var sculpture = new KineticSculpture(FileInput);
        return new PuzzleResult(sculpture.TimeToPressButton, 317_371);
    }

    public override PuzzleResult RunPart2()
    {
        var sculpture = new KineticSculpture(FileInput, true);
        return new PuzzleResult(sculpture.TimeToPressButton, 2_080_951);
    }
}