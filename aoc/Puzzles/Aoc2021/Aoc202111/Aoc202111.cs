using Puzzles.Common.Puzzles;

namespace Puzzles.Aoc.Puzzles.Aoc2021.Aoc202111;

public class Aoc202111 : AocPuzzle
{
    public override string Name => "Dumbo Octopus";

    protected override PuzzleResult RunPart1()
    {
        var flasher = new OctopusFlasher(InputFile);
        var result = flasher.Run(100);
        return new PuzzleResult(result, "4aec5027d57e852d3dc2c0fa275d9d7a");
    }

    protected override PuzzleResult RunPart2()
    {
        var flasher = new OctopusFlasher(InputFile);
        var result = flasher.Run();
        return new PuzzleResult(result, "ffd6657cda58c97fce2c4c27d8fd43a9");
    }
}