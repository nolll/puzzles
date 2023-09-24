using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2015.Day06;

public class Year2015Day06 : AocPuzzle
{
    public override string Name => "Probably a Fire Hazard";

    protected override PuzzleResult RunPart1()
    {
        var controller = new ChristmasLightsController();
        controller.RunCommands(InputFile, false);
        return new PuzzleResult(controller.LitCount, 377_891);
    }

    protected override PuzzleResult RunPart2()
    {
        var controller = new ChristmasLightsController();
        controller.RunCommands(InputFile, true);
        return new PuzzleResult(controller.TotalBrightness, 14_110_788);
    }
}