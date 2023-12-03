using Puzzles.Common.Puzzles;

namespace Puzzles.Aoc.Puzzles.Aoc2018.Aoc201812;

public class Aoc201812 : AocPuzzle
{
    public override string Name => "Subterranean Sustainability";

    protected override PuzzleResult RunPart1()
    {
        var spreader = new PlantSpreader(InputFile);
        return new PuzzleResult(spreader.PlantScore20, "0ed64899552ad3524168fa5d31b0aa8b");
    }

    protected override PuzzleResult RunPart2()
    {
        var spreader = new PlantSpreader(InputFile);
        return new PuzzleResult(spreader.PlantScore50B, "7efddf05168f7291240396f1a5263653");
    }
}