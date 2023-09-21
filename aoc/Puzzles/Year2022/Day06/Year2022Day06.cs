using Aoc.Platform;
using common.Puzzles;

namespace Aoc.Puzzles.Year2022.Day06;

public class Year2022Day06 : AocPuzzle
{
    public override string Name => "Tuning Trouble";

    public override PuzzleResult RunPart1()
    {
        var result = TuningTrouble.FindMarker(FileInput);
        return new PuzzleResult(result, 1542);
    }

    public override PuzzleResult RunPart2()
    {
        var result = TuningTrouble.FindMessage(FileInput);
        return new PuzzleResult(result, 3153);
    }
}