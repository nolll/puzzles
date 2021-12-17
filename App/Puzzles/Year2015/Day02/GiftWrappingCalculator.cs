using System.Collections.Generic;
using System.Linq;

namespace App.Puzzles.Year2015.Day02;

public class GiftWrappingCalculator
{
    public int GetRequiredPaper(string input)
    {
        var gifts = input.Trim().Split('\n').Select(o => o.Trim());
        return gifts.Sum(GetRequiredPaperForOneBox);
    }

    public int GetRequiredPaperForOneBox(string input)
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

    public int GetRequiredRibbon(string input)
    {
        var gifts = input.Trim().Split('\n').Select(o => o.Trim());
        return gifts.Sum(GetRequiredRibbonForOneBox);
    }

    public int GetRequiredRibbonForOneBox(string input)
    {
        var dimensions = input.Split('x').Select(int.Parse).ToList().OrderBy(o => o).ToList();
        return dimensions[0] * 2 + dimensions[1] * 2 + dimensions[0] * dimensions[1] * dimensions[2];
    }
}