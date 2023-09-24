using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2018.Aoc201812;

public class Year2018Day12 : AocPuzzle
{
    public override string Name => "Subterranean Sustainability";

    protected override PuzzleResult RunPart1()
    {
        var spreader = new PlantSpreader(InputFile);
        return new PuzzleResult(spreader.PlantScore20, 1623);
    }

    protected override PuzzleResult RunPart2()
    {
        var spreader = new PlantSpreader(InputFile);
        return new PuzzleResult(spreader.PlantScore50B, 1600000000401);
    }
}