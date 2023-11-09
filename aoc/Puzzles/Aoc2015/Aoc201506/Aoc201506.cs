using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2015.Aoc201506;

public class Aoc201506 : AocPuzzle
{
    public override string Name => "Probably a Fire Hazard";

    protected override PuzzleResult RunPart1()
    {
        var controller = new ChristmasLightsController();
        controller.RunCommands(InputFile, false);
        return new PuzzleResult(controller.LitCount, "8cde00a802ab8a80c8939584c4fede8a");
    }

    protected override PuzzleResult RunPart2()
    {
        var controller = new ChristmasLightsController();
        controller.RunCommands(InputFile, true);
        return new PuzzleResult(controller.TotalBrightness, "d8489f6672714633835714401c5d3116");
    }
}