using Pzl.Common;
using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Aoc.Puzzles.Aoc2023.Aoc202321;

[Name("Step Counter")]
public class Aoc202321 : AocPuzzle
{
    public PuzzleResult RunPart1(string input)
    {
        return new PuzzleResult(CountPositionsAfter64(input), "c843850a004e76c6cad0745f43786af0");
    }

    public PuzzleResult RunPart2(string input)
    {
        return new PuzzleResult(CountPositionsAfterMany(input), "82eccc3aebc6a8cca12ce692d9765520");
    }

    public static long CountPositionsAfter64(string s, int steps = 64)
    {
        var grid = GridBuilder.BuildCharGrid(s);
        var start = grid.FindAddresses('S').First();
        grid.WriteValueAt(start, '.');
        return CountPositionsAfter(grid, start, steps);
    }

    public static long CountPositionsAfterMany(string s)
    {
        var grid = GridBuilder.BuildCharGrid(s);
        var start = grid.FindAddresses('S').First();
        var center = start.X;
        var (left, top) = new Coord(grid.XMin, grid.YMin);
        var (right, bottom) = new Coord(grid.XMax, grid.YMax);
        var size = grid.Width;
        grid.WriteValueAt(start, '.');
         
        const int stepCount = 26_501_365;
        var gridWidth = stepCount / size - 1;

        long oddMultiplier = gridWidth / 2 * 2 + 1;
        var odd = oddMultiplier * oddMultiplier;

        long evenMultiplier = (gridWidth + 1) / 2 * 2;
        var even = evenMultiplier * evenMultiplier;

        var oddPoints = CountPositionsAfter(grid, start, size);
        var evenPoints = CountPositionsAfter(grid, start, size + 1);

        var smallCount = gridWidth + 1;
        var largeCount = gridWidth;

        var cornerSteps = size - 1;
        var smallSteps = (int)Math.Floor((double)size / 2) - 1;
        var largeSteps = (int)Math.Floor((double)size * 3 / 2) - 1;

        var ct = CountPositionsAfter(grid, new Coord(center, bottom), cornerSteps);
        var cr = CountPositionsAfter(grid, new Coord(left, center), cornerSteps);
        var cb = CountPositionsAfter(grid, new Coord(center, top), cornerSteps);
        var cl = CountPositionsAfter(grid, new Coord(right, center), cornerSteps);

        var str = CountPositionsAfter(grid, new Coord(left, bottom), smallSteps);
        var ltr = CountPositionsAfter(grid, new Coord(left, bottom), largeSteps);

        var sbr = CountPositionsAfter(grid, new Coord(left, top), smallSteps);
        var lbr = CountPositionsAfter(grid, new Coord(left, top), largeSteps);

        var sbl = CountPositionsAfter(grid, new Coord(right, top), smallSteps);
        var lbl = CountPositionsAfter(grid, new Coord(right, top), largeSteps);

        var stl = CountPositionsAfter(grid, new Coord(right, bottom), smallSteps);
        var ltl = CountPositionsAfter(grid, new Coord(right, bottom), largeSteps);

        var filledPlots = oddPoints * odd
                          + evenPoints * even
                          + ct + cr + cb + cl
                          + (str + sbr + sbl + stl) * smallCount
                          + (ltr + lbr + lbl + ltl) * largeCount;

        return filledPlots;
    }

    private static long CountPositionsAfter(Grid<char> grid, Coord start, int steps = 64)
    {
        var lit = new HashSet<Coord> { start };

        for (var i = 0; i < steps; i++)
        {
            var newLit = new HashSet<Coord>();
            foreach (var litCoord in lit)
            {
                var allAdjacent = grid.OrthogonalAdjacentCoordsTo(litCoord);
                foreach (var a in allAdjacent)
                {
                    if (grid.ReadValueAt(a) != '#')
                    {
                        newLit.Add(a);
                    }
                }
            }

            lit = newLit;
        }

        var pm = grid.Clone();
        foreach (var coord in lit)
        {
            pm.WriteValueAt(coord, 'O');
        }

        return lit.Count;
    }
}