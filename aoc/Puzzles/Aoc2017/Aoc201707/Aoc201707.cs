using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2017.Aoc201707;

public class Aoc201707 : AocPuzzle
{
    public override string Name => "Recursive Circus";

    protected override PuzzleResult RunPart1()
    {
        var towers = new RecursiveTowers(InputFile);
        return new PuzzleResult(towers.BottomName, "dgoocsw");
    }

    protected override PuzzleResult RunPart2()
    {
        var towers = new RecursiveTowers(InputFile);
        return new PuzzleResult(towers.AdjustedWeight, 1275);
    }
}