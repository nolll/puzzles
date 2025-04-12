using Pzl.Common;
using Pzl.Tools.Numbers;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2015.Aoc201502;

[Name("I Was Told There Would Be No Math")]
public class Aoc201502 : AocPuzzle
{
    public PuzzleResult Part1(string input)
    {
        var paperResult = GetRequiredPaper(input);
        return new PuzzleResult(paperResult, "dfdf9c79dfad493d6417a9a284a9670b");
    }

    public PuzzleResult Part2(string input)
    {
        var ribbonResult = GetRequiredRibbon(input);
        return new PuzzleResult(ribbonResult, "385d3372d91329e3166413c1cb3126d5");
    }

    public int GetRequiredPaper(string input) => 
        input.Split(LineBreaks.Single).Sum(GetRequiredPaperForOneBox);

    public int GetRequiredPaperForOneBox(string input)
    {
        var dimensions = Numbers.IntsFromString(input);
        var sides = new List<int>
        {
            dimensions[0] * dimensions[1],
            dimensions[0] * dimensions[2],
            dimensions[1] * dimensions[2]
        }.OrderBy(o => o).ToList();

        return sides[0] * 3 + sides[1] * 2 + sides[2] * 2;
    }

    public int GetRequiredRibbon(string input) => 
        input.Split(LineBreaks.Single).Sum(GetRequiredRibbonForOneBox);

    public int GetRequiredRibbonForOneBox(string input)
    {
        var dimensions = Numbers.IntsFromString(input).OrderBy(o => o).ToList();
        return dimensions[0] * 2 + dimensions[1] * 2 + dimensions[0] * dimensions[1] * dimensions[2];
    }
}