using Puzzles.Common.Puzzles;

namespace Pzl.Aoc.Puzzles.Aoc2016.Aoc201625;

public class Aoc201625 : AocPuzzle
{
    public override string Name => "Clock Signal";

    protected override PuzzleResult RunPart1()
    {
        var generator = new ClockSignalGenerator();
        return new PuzzleResult(generator.LowestA, "5523923bd52d76e1c1d68b1cfdff95b5");
    }

    protected override PuzzleResult RunPart2() => PuzzleResult.Empty;
}