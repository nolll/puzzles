using Pzl.Common;
using Pzl.Tools.CoordinateSystems.CoordinateSystem2D;

namespace Pzl.Aoc.Puzzles.Aoc2023.Aoc202311;

[Name("Cosmic Expansion")]
public class Aoc202311 : AocPuzzle
{
    protected override PuzzleResult RunPart1()
    {
        return new PuzzleResult(Distances(InputFile, 1), "04a7795748b2f6d2e38898623e8ef01a");
    }

    protected override PuzzleResult RunPart2()
    {
        return new PuzzleResult(Distances(InputFile, 1_000_000), "73bccfdcdd826f77dcdaf67bedecded9");
    }

    public static long Distances(string input, long multiplier)
    {
        var matrix = MatrixBuilder.BuildCharMatrix(input);
        var expandedCols = new List<long>();
        var expandedX = 0L;
        for (var x = 0; x <= matrix.XMax; x++)
        {
            var galaxies = 0;
            for (var y = 0; y <= matrix.YMax; y++)
            {
                if (matrix.ReadValueAt(x, y) == '#')
                {
                    galaxies++;
                }
            }

            if(galaxies == 0)
            {
                expandedX += multiplier - 1;
            }

            expandedCols.Add(x + expandedX);
        }

        var expandedRows = new List<long>();
        var expandedY = 0L;
        for (var y = 0; y <= matrix.YMax; y++)
        {
            var galaxies = 0;
            for (var x = 0; x <= matrix.XMax; x++)
            {
                if (matrix.ReadValueAt(x, y) == '#')
                {
                    galaxies++;
                }
            }

            if (galaxies == 0)
            {
                expandedY += multiplier - 1;
            }

            expandedRows.Add(y + expandedY);
        }

        var galaxyCoords = matrix.Coords.Where(o => matrix.ReadValueAt(o) == '#');
        var expandedCoords = galaxyCoords.Select(o => (expandedCols[o.X], expandedRows[o.Y])).ToList();

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

    private static long ManhattanDistance((long x, long y) a, (long x, long y) b)
    {
        var xMax = Math.Max(a.x, b.x);
        var xMin = Math.Min(a.x, b.x);
        var xDiff = xMax - xMin;

        var yMax = Math.Max(a.y, b.y);
        var yMin = Math.Min(a.y, b.y);
        var yDiff = yMax - yMin;

        return xDiff + yDiff;
    }
}