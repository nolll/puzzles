using Pzl.Common;
using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Aoc.Puzzles.Aoc2023.Aoc202311;

[Name("Cosmic Expansion")]
public class Aoc202311 : AocPuzzle
{
    public PuzzleResult RunPart1(string input)
    {
        return new PuzzleResult(Distances(input, 1), "04a7795748b2f6d2e38898623e8ef01a");
    }

    public PuzzleResult RunPart2(string input)
    {
        return new PuzzleResult(Distances(input, 1_000_000), "73bccfdcdd826f77dcdaf67bedecded9");
    }

    public static long Distances(string input, long multiplier)
    {
        var matrix = GridBuilder.BuildCharGrid(input);
        var expandedXValues = ExpandX(matrix, multiplier);
        var expandedYValues = ExpandY(matrix, multiplier);

        var galaxyCoords = matrix.Coords.Where(o => matrix.ReadValueAt(o) == '#');
        var expandedCoords = galaxyCoords.Select(o => (expandedXValues[o.X], expandedYValues[o.Y])).ToList();

        return GetManhattanTotal(expandedCoords);
    }

    private static long GetManhattanTotal(List<(long, long)> expandedCoords)
    {
        var total = 0L;
        foreach (var a in expandedCoords)
        {
            foreach (var b in expandedCoords)
            {
                if (!a.Equals(b))
                {
                    total += ManhattanDistance(a, b);
                }
            }
        }

        return total / 2;
    }

    private static List<long> ExpandX(Grid<char> grid, long multiplier)
    {
        var expandedXValues = new List<long>();
        var expandedX = 0L;
        var galaxyCounts = new List<int>();

        for (var x = 0; x <= grid.XMax; x++)
        {
            var galaxies = 0;
            for (var y = 0; y <= grid.YMax; y++)
            {
                if (grid.ReadValueAt(x, y) == '#') 
                    galaxies++;
            }

            galaxyCounts.Add(galaxies);
        }

        for (var x = 0; x < galaxyCounts.Count; x++)
        {
            if (galaxyCounts[x] == 0) 
                expandedX += multiplier - 1;

            expandedXValues.Add(x + expandedX);
        }

        return expandedXValues;
    }

    private static List<long> ExpandY(Grid<char> grid, long multiplier)
    {
        var expandedYValues = new List<long>();
        var expandedY = 0L;
        var galaxyCounts = new List<int>();

        for (var y = 0; y <= grid.YMax; y++)
        {
            var galaxies = 0;
            for (var x = 0; x <= grid.XMax; x++)
            {
                if (grid.ReadValueAt(x, y) == '#') 
                    galaxies++;
            }

            galaxyCounts.Add(galaxies);
        }

        for (var y = 0; y < galaxyCounts.Count; y++)
        {
            if (galaxyCounts[y] == 0) 
                expandedY += multiplier - 1;

            expandedYValues.Add(y + expandedY);
        }

        return expandedYValues;
    }

    private static long ManhattanDistance((long x, long y) a, (long x, long y) b) => 
        Math.Abs(a.x - b.x) + Math.Abs(a.y - b.y);
}