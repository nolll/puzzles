using Aoc.Platform;
using common.Puzzles;

namespace Aoc.Puzzles.Year2018.Day17;

public class Year2018Day17 : AocPuzzle
{
    public override string Name => "Reservoir Research";

    public override PuzzleResult RunPart1()
    {
        var filler = new ReservoirFiller(FileInput);
        filler.Fill();
        return new PuzzleResult(filler.TotalWaterTileCount, 29_802);
    }

    public override PuzzleResult RunPart2()
    {
        var filler = new ReservoirFiller(FileInput);
        filler.Fill();
        return new PuzzleResult(filler.RetainedWaterTileCount, 24_660);
    }
}