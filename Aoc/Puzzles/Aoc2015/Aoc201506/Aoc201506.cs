using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2015.Aoc201506;

[Name("Probably a Fire Hazard")]
public class Aoc201506 : AocPuzzle
{
    [Puzzle("8cde00a802ab8a80c8939584c4fede8a")]
    public int Part1(string input)
    {
        var controller = new ChristmasLightsController();
        controller.RunCommands(input, false);
        return controller.LitCount;
    }

    [Puzzle("d8489f6672714633835714401c5d3116")]
    public int Part2(string input)
    {
        var controller = new ChristmasLightsController();
        controller.RunCommands(input, true);
        return controller.TotalBrightness;
    }
}