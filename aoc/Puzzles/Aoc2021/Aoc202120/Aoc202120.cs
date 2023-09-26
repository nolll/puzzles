using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2021.Aoc202120;

public class Aoc202120 : AocPuzzle
{
    public override string Name => "Trench Map";

    protected override PuzzleResult RunPart1()
    {
        var trenchMap = new TrenchMap();
        var result = trenchMap.GetLitPixelCount(InputFile, 2);

        return new PuzzleResult(result, 5765);
    }

    protected override PuzzleResult RunPart2()
    {
        var trenchMap = new TrenchMap();
        var result = trenchMap.GetLitPixelCount(InputFile, 50);

        return new PuzzleResult(result, 18509);
    }
}