using Pzl.Common;
using Pzl.Tools.Grids.Grids2d;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2023.Aoc202313;

[Name("Point of Incidence")]
public class Aoc202313 : AocPuzzle
{
    public PuzzleResult RunPart1(string input)
    {
        var s = StringReader.ReadStringGroups(input);
        var result = s.Sum(CountReflections);

        return new PuzzleResult(result, "ee9ffa0006ecc43014e2c3a817904396");
    }

    public PuzzleResult RunPart2(string input)
    {
        var s = StringReader.ReadStringGroups(input);
        var result = s.Sum(CountSmudgedReflections);

        return new PuzzleResult(result, "32a6556a3bdfe559c36bdafb480740ef");
    }

    public static int CountReflections(string s)
    {
        var grid = GridBuilder.BuildCharGrid(s);

        return CountReflections(grid, -1);
    }

    private static int CountReflections(Grid<char> grid, int orig)
    {
        var rows = Rows(grid, orig);
        if (rows > 0)
            return rows * 100;

        return Columns(grid, orig);
    }

    public static int CountSmudgedReflections(string s)
    {
        var grid = GridBuilder.BuildCharGrid(s);
        var orig = CountReflections(grid, -1);

        foreach (var coord in grid.Coords)
        {
            var v = grid.ReadValueAt(coord);
            var n = v == '#' ? '.' : '#';
            grid.WriteValueAt(coord, n);
            var c = CountReflections(grid, orig);
            grid.WriteValueAt(coord, v);
            if (c > 0)
            {
                return c;
            }
        }
        
        return 0;
    }

    private static int Columns(Grid<char> grid, int orig)
    {
        var cols = Enumerable.Range(0, grid.Width).Select(x => ReadCol(grid, x)).ToList();
        return FindReflection(cols, orig);
    }

    private static int Rows(Grid<char> grid, int orig)
    {
        var rows = Enumerable.Range(0, grid.Height).Select(y => ReadRow(grid, y)).ToList();
        var origCompare = orig >= 100 ? orig / 100 : 0;
        return FindReflection(rows, origCompare);
    }

    private static int FindReflection(List<string> lines, int orig)
    {
        for (var i = 1; i < lines.Count; i++)
        {
            if (i == orig)
                continue;

            var xDown = i;
            var xUp = i - 1;
            var down = lines[xDown];
            var up = lines[xUp];
            const int xMin = 0;
            var xMax = lines.Count - 1;

            while (down == up)
            {
                if (xUp <= xMin || xDown >= xMax)
                    return i;

                xDown++;
                xUp--;
                down = lines[xDown];
                up = lines[xUp];
            }
        }

        return 0;
    }

    private static string ReadRow(Grid<char> grid, int y) => 
        string.Join("", Enumerable.Range(0, grid.Width).Select(x => grid.ReadValueAt(x, y)));

    private static string ReadCol(Grid<char> grid, int x) =>
        string.Join("", Enumerable.Range(0, grid.Height).Select(y => grid.ReadValueAt(x, y)));
}