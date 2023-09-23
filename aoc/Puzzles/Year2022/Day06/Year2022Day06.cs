using Common.Puzzles;

namespace Aoc.Puzzles.Year2022.Day06;

public class Year2022Day06 : AocPuzzle
{
    public override string Name => "Tuning Trouble";

    protected override PuzzleResult RunPart1()
    {
        var result = TuningTrouble.FindMarker(FileInput);
        return new PuzzleResult(result, 1542);
    }

    protected override PuzzleResult RunPart2()
    {
        var result = TuningTrouble.FindMessage(FileInput);
        return new PuzzleResult(result, 3153);
    }
}