using Aoc.Platform;
using common.Puzzles;

namespace Aoc.Puzzles.Year2021.Day11;

public class Year2021Day11 : AocPuzzle
{
    public override string Name => "Dumbo Octopus";

    public override PuzzleResult RunPart1()
    {
        var flasher = new OctopusFlasher(FileInput);
        var result = flasher.Run(100);
        return new PuzzleResult(result, 1591);
    }

    public override PuzzleResult RunPart2()
    {
        var flasher = new OctopusFlasher(FileInput);
        var result = flasher.Run();
        return new PuzzleResult(result, 314);
    }
}