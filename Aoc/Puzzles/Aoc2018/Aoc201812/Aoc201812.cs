using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2018.Aoc201812;

[Name("Subterranean Sustainability")]
public class Aoc201812 : AocPuzzle
{
    protected override PuzzleResult RunPart1(string input)
    {
        var spreader = new PlantSpreader(input);
        return new PuzzleResult(spreader.PlantScore20, "0ed64899552ad3524168fa5d31b0aa8b");
    }

    protected override PuzzleResult RunPart2(string input)
    {
        var spreader = new PlantSpreader(input);
        return new PuzzleResult(spreader.PlantScore50B, "7efddf05168f7291240396f1a5263653");
    }
}