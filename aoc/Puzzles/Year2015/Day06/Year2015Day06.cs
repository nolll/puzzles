using Aoc.Platform;
using common.Puzzles;

namespace Aoc.Puzzles.Year2015.Day06;

public class Year2015Day06 : AocPuzzle
{
    public override string Name => "Probably a Fire Hazard";

    public override PuzzleResult RunPart1()
    {
        var controller = new ChristmasLightsController();
        controller.RunCommands(FileInput, false);
        return new PuzzleResult(controller.LitCount, 377_891);
    }

    public override PuzzleResult RunPart2()
    {
        var controller = new ChristmasLightsController();
        controller.RunCommands(FileInput, true);
        return new PuzzleResult(controller.TotalBrightness, 14_110_788);
    }
}