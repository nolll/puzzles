using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2019.Aoc201919;

public class Year2019Day19 : AocPuzzle
{
    public override string Name => "Tractor Beam";

    protected override PuzzleResult RunPart1()
    {
        var tbc = new TractorBeamComputer1(InputFile, 50, 50);
        var result = tbc.GetPullCount();

        return new PuzzleResult(result, 141);
    }

    protected override PuzzleResult RunPart2()
    {
        var tbc = new TractorBeamComputer2(InputFile, 50, 50);
        var result = tbc.Find100By100Square();

        return new PuzzleResult(result.Checksum, 15_641_348);
    }
}