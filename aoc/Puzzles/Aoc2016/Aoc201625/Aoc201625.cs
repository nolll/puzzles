using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2016.Aoc201625;

public class Aoc201625 : AocPuzzle
{
    public override string Name => "Clock Signal";

    protected override PuzzleResult RunPart1()
    {
        var generator = new ClockSignalGenerator();
        return new PuzzleResult(generator.LowestA, 198);
    }

    protected override PuzzleResult RunPart2() => PuzzleResult.Empty;
}