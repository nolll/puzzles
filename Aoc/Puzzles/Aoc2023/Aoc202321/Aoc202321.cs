using Pzl.Common;
using Pzl.Tools.CoordinateSystems.CoordinateSystem2D;

namespace Pzl.Aoc.Puzzles.Aoc2023.Aoc202321;

[Name("Step Counter")]
public class Aoc202321(string input) : AocPuzzle
{
    protected override PuzzleResult RunPart1()
    {
        return new PuzzleResult(CountPositionsAfter64(input), "c843850a004e76c6cad0745f43786af0");
    }

    protected override PuzzleResult RunPart2()
    {
        // guesses
        // 608_148_528_908_778 not correct
        // 608_148_533_763_966 not correct

        return new PuzzleResult(CountPositionsAfterMany(input));
    }

    public static int CountPositionsAfter64(string s, int steps = 64)
    {
        var matrix = MatrixBuilder.BuildCharMatrix(s);
        var start = matrix.FindAddresses('S').First();
        matrix.WriteValueAt(start, '.');
        return CountPositionsAfter(matrix, start, steps);
    }

    public static long CountPositionsAfterMany(string s)
    {
        var matrix = MatrixBuilder.BuildCharMatrix(s);
        var start = matrix.FindAddresses('S').First();
        var (sx, sy) = start.Tuple;
        var (minx, miny) = new MatrixAddress(matrix.XMin, matrix.YMin).Tuple;
        var (maxx, maxy) = new MatrixAddress(matrix.XMax, matrix.YMax).Tuple;
        var size = matrix.Width;
        matrix.WriteValueAt(start, '.');

        const int stepCount = 26_501_365;
        var gridSize = (stepCount - size / 2) / size - 1;

        var oddSectionCount = (long)Math.Pow(Math.Floor((double)gridSize / 2) * 2 + 1, 2);
        var evenSectionCount = (long)Math.Pow(Math.Floor((double)(gridSize + 1) / 2) * 2, 2);

        var filledOddSection = CountPositionsAfter(matrix, start, size * 2 + 1);
        var filledEvenSection = CountPositionsAfter(matrix, start, size * 2);

        var largeSectionCount = gridSize;
        var smallSectionCount = gridSize + 1;

        var sectionSteps = size - 1;
        var smallSectionSteps = (int)Math.Floor((double)size / 2);
        var largeSectionSteps = (int)Math.Floor((double)size * 3 / 2);

        var top = new MatrixAddress(sx, miny);
        var fromTop = CountPositionsAfter(matrix, top, sectionSteps);
        var right = new MatrixAddress(maxx, sy);
        var fromRight = CountPositionsAfter(matrix, right, sectionSteps);
        var bottom = new MatrixAddress(sx, maxy);
        var fromBottom = CountPositionsAfter(matrix, bottom, sectionSteps);
        var left = new MatrixAddress(minx, sy);
        var fromLeft = CountPositionsAfter(matrix, left, sectionSteps);

        var topRight = new MatrixAddress(maxx, miny);
        var fromTopRightSmall = CountPositionsAfter(matrix, topRight, smallSectionSteps);
        var fromTopRightLarge = CountPositionsAfter(matrix, topRight, largeSectionSteps);

        var bottomRight = new MatrixAddress(maxx, maxy);
        var fromBottomRightSmall = CountPositionsAfter(matrix, bottomRight, smallSectionSteps);
        var fromBottomRightLarge = CountPositionsAfter(matrix, bottomRight, largeSectionSteps);
        
        var bottomLeft = new MatrixAddress(minx, maxy);
        var fromBottomLeftSmall = CountPositionsAfter(matrix, bottomLeft, smallSectionSteps);
        var fromBottomLeftLarge = CountPositionsAfter(matrix, bottomLeft, largeSectionSteps);
        
        var topLeft = new MatrixAddress(minx, miny);
        var fromTopLeftSmall = CountPositionsAfter(matrix, topLeft, smallSectionSteps);
        var fromTopLeftLarge = CountPositionsAfter(matrix, topLeft, largeSectionSteps);

        var filledPlots = filledOddSection * oddSectionCount
                          + filledEvenSection * evenSectionCount
                          + (fromTopRightLarge + fromBottomRightLarge + fromBottomLeftLarge + fromTopLeftLarge) * largeSectionCount
                          + (fromTopRightSmall + fromBottomRightSmall + fromBottomLeftSmall + fromTopLeftSmall) * smallSectionCount
                          + fromTop + fromRight + fromBottom + fromLeft;

        return filledPlots;
    }

    private static int CountPositionsAfter(Matrix<char> matrix, MatrixAddress start, int steps = 64)
    {
        var lit = new HashSet<MatrixAddress> { start };

        for (var i = 0; i < steps; i++)
        {
            var newLit = new HashSet<MatrixAddress>();
            foreach (var litCoord in lit)
            {
                var allAdjacent = matrix.OrthogonalAdjacentCoordsTo(litCoord);
                foreach (var a in allAdjacent)
                {
                    if (matrix.ReadValueAt(a) != '#')
                    {
                        newLit.Add(a);
                    }
                }
            }

            lit = newLit;
        }

        var pm = matrix.Clone();
        foreach (var coord in lit)
        {
            pm.WriteValueAt(coord, 'O');
        }
        var print = pm.Print();

        return lit.Count;
    }
}