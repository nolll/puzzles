using Puzzles.common.Puzzles;

namespace Puzzles.aoc.Puzzles.Aoc2021.Aoc202120;

public class Aoc202120 : AocPuzzle
{
    public override string Name => "Trench Map";

    protected override PuzzleResult RunPart1()
    {
        var trenchMap = new TrenchMap();
        var result = trenchMap.GetLitPixelCount(InputFile, 2);

        return new PuzzleResult(result, "45662f27fb9cbf099b4d5453539159a2");
    }

    protected override PuzzleResult RunPart2()
    {
        var trenchMap = new TrenchMap();
        var result = trenchMap.GetLitPixelCount(InputFile, 50);

        return new PuzzleResult(result, "0225d04616fb918456e876afd4831afd");
    }
}