using Pzl.Tools.Numbers;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2015.Aoc201502;

public static class GiftWrappingCalculator
{
    public static int GetRequiredPaper(string input) => 
        input.Split(LineBreaks.Single).Sum(GetRequiredPaperForOneBox);

    public static int GetRequiredPaperForOneBox(string input)
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

    public static int GetRequiredRibbon(string input) => 
        input.Split(LineBreaks.Single).Sum(GetRequiredRibbonForOneBox);

    public static int GetRequiredRibbonForOneBox(string input)
    {
        var dimensions = Numbers.IntsFromString(input).OrderBy(o => o).ToList();
        return dimensions[0] * 2 + dimensions[1] * 2 + dimensions[0] * dimensions[1] * dimensions[2];
    }
}