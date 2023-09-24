using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2018.Day17;

public class Year2018Day17 : AocPuzzle
{
    public override string Name => "Reservoir Research";

    protected override PuzzleResult RunPart1()
    {
        var filler = new ReservoirFiller(InputFile);
        filler.Fill();
        return new PuzzleResult(filler.TotalWaterTileCount, 29_802);
    }

    protected override PuzzleResult RunPart2()
    {
        var filler = new ReservoirFiller(InputFile);
        filler.Fill();
        return new PuzzleResult(filler.RetainedWaterTileCount, 24_660);
    }
}