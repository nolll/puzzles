using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2018.Aoc201817;

[Name("Reservoir Research")]
public class Aoc201817(string input) : AocPuzzle(input)
{
    protected override PuzzleResult RunPart1()
    {
        var filler = new ReservoirFiller(Input);
        filler.Fill();
        return new PuzzleResult(filler.TotalWaterTileCount, "670e4fda6254e4ae79cdf1065fba7c51");
    }

    protected override PuzzleResult RunPart2()
    {
        var filler = new ReservoirFiller(Input);
        filler.Fill();
        return new PuzzleResult(filler.RetainedWaterTileCount, "c188fe62ee29321d37a6c8cee549a1db");
    }
}