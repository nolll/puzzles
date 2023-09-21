using Aoc.Platform;
using common.Puzzles;

namespace Aoc.Puzzles.Year2016.Day25;

public class Year2016Day25 : AocPuzzle
{
    public override string Title => "Clock Signal";

    public override PuzzleResult RunPart1()
    {
        var generator = new ClockSignalGenerator();
        return new PuzzleResult(generator.LowestA, 198);
    }

    public override PuzzleResult RunPart2() => PuzzleResult.Empty;
}