namespace Puzzles.aoc.Puzzles.Aoc2015.Aoc201502;

public class GiftWrappingCalculator
{
    public static int GetRequiredPaper(string input)
    {
        var gifts = input.Trim().Split('\n').Select(o => o.Trim());
        return gifts.Sum(GetRequiredPaperForOneBox);
    }

    public static int GetRequiredPaperForOneBox(string input)
    {
        var dimensions = input.Split('x').Select(int.Parse).ToList();
        var sides = new List<int>
        {
            dimensions[0] * dimensions[1],
            dimensions[0] * dimensions[2],
            dimensions[1] * dimensions[2]
        }.OrderBy(o => o).ToList();

        return sides[0] * 3 + sides[1] * 2 + sides[2] * 2;
    }

    public static int GetRequiredRibbon(string input)
    {
        var gifts = input.Trim().Split('\n').Select(o => o.Trim());
        return gifts.Sum(GetRequiredRibbonForOneBox);
    }

    public static int GetRequiredRibbonForOneBox(string input)
    {
        var dimensions = input.Split('x').Select(int.Parse).ToList().OrderBy(o => o).ToList();
        return dimensions[0] * 2 + dimensions[1] * 2 + dimensions[0] * dimensions[1] * dimensions[2];
    }
}