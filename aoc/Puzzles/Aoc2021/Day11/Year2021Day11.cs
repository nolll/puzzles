using Common.Puzzles;

namespace Aoc.Puzzles.Year2021.Day11;

public class Year2021Day11 : AocPuzzle
{
    public override string Name => "Dumbo Octopus";

    protected override PuzzleResult RunPart1()
    {
        var flasher = new OctopusFlasher(InputFile);
        var result = flasher.Run(100);
        return new PuzzleResult(result, 1591);
    }

    protected override PuzzleResult RunPart2()
    {
        var flasher = new OctopusFlasher(InputFile);
        var result = flasher.Run();
        return new PuzzleResult(result, 314);
    }
}