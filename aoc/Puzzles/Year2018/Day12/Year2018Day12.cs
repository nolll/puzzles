using Aoc.Platform;
using common.Puzzles;

namespace Aoc.Puzzles.Year2018.Day12;

public class Year2018Day12 : AocPuzzle
{
    public override string Name => "Subterranean Sustainability";

    protected override PuzzleResult RunPart1()
    {
        var spreader = new PlantSpreader(FileInput);
        return new PuzzleResult(spreader.PlantScore20, 1623);
    }

    protected override PuzzleResult RunPart2()
    {
        var spreader = new PlantSpreader(FileInput);
        return new PuzzleResult(spreader.PlantScore50B, 1600000000401);
    }
}