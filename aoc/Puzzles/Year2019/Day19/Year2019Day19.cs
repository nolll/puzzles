using Aoc.Platform;
using common.Puzzles;

namespace Aoc.Puzzles.Year2019.Day19;

public class Year2019Day19 : AocPuzzle
{
    public override string Title => "Tractor Beam";

    public override PuzzleResult RunPart1()
    {
        var tbc = new TractorBeamComputer1(FileInput, 50, 50);
        var result = tbc.GetPullCount();

        return new PuzzleResult(result, 141);
    }

    public override PuzzleResult RunPart2()
    {
        var tbc = new TractorBeamComputer2(FileInput, 50, 50);
        var result = tbc.Find100By100Square();

        return new PuzzleResult(result.Checksum, 15_641_348);
    }
}