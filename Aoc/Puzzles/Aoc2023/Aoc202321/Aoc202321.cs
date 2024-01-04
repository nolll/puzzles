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
        // 608_148_613_469_947 not correct
        // 608_148_528_908_778 not correct
        // 608_151_537_506_942

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
        var center = start.X;
        var (left, top) = new MatrixAddress(matrix.XMin, matrix.YMin).Tuple;
        var (right, bottom) = new MatrixAddress(matrix.XMax, matrix.YMax).Tuple;
        var size = matrix.Width;
        matrix.WriteValueAt(start, '.');
         
        const int stepCount = 26_501_365;
        var gridWidth = stepCount / size - 1;

        //var odd = (long)Math.Pow(Math.Floor((double)gridWidth / 2) * 2 + 1, 2);
        //var even = (long)Math.Pow(Math.Floor((double)(gridWidth + 1) / 2) * 2, 2);

        long oddMultiplier = gridWidth / 2 * 2 + 1;
        var odd = oddMultiplier * oddMultiplier;

        long evenMultiplier = (gridWidth + 1) / 2 * 2;
        var even = evenMultiplier * evenMultiplier;

        var oddPoints = CountPositionsAfter(matrix, start, size);
        var evenPoints = CountPositionsAfter(matrix, start, size + 1);

        var smallCount = gridWidth + 1;
        var largeCount = gridWidth;

        var cornerSteps = size - 1;
        var smallSteps = (int)Math.Floor((double)size / 2) - 1;
        var largeSteps = (int)Math.Floor((double)size * 3 / 2) - 1;

        var ct = CountPositionsAfter(matrix, new MatrixAddress(center, bottom), cornerSteps);
        var cr = CountPositionsAfter(matrix, new MatrixAddress(left, center), cornerSteps);
        var cb = CountPositionsAfter(matrix, new MatrixAddress(center, top), cornerSteps);
        var cl = CountPositionsAfter(matrix, new MatrixAddress(right, center), cornerSteps);

        var str = CountPositionsAfter(matrix, new MatrixAddress(left, bottom), smallSteps);
        var ltr = CountPositionsAfter(matrix, new MatrixAddress(left, bottom), largeSteps);

        var sbr = CountPositionsAfter(matrix, new MatrixAddress(left, top), smallSteps);
        var lbr = CountPositionsAfter(matrix, new MatrixAddress(left, top), largeSteps);

        var sbl = CountPositionsAfter(matrix, new MatrixAddress(right, top), smallSteps);
        var lbl = CountPositionsAfter(matrix, new MatrixAddress(right, top), largeSteps);

        var stl = CountPositionsAfter(matrix, new MatrixAddress(right, bottom), smallSteps);
        var ltl = CountPositionsAfter(matrix, new MatrixAddress(right, bottom), largeSteps);

        var filledPlots = oddPoints * odd
                          + evenPoints * even
                          + ct + cr + cb + cl
                          + (str + sbr + sbl + stl) * smallCount
                          + (ltr + lbr + lbl + ltl) * largeCount;

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