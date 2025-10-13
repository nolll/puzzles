using Pzl.Tools.Strings;

namespace Pzl.Tools.Grids.Grids2d;

public static class GridBuilder
{
    public static Grid<char> BuildCharGrid(string input, char defaultValue = default)
    {
        var rows = StringReader.ReadLines(input.Trim()).Select(o => o.Trim()).ToArray();
        return BuildCharGrid(new Grid<char>(1, 1, defaultValue), rows);
    }

    public static Grid<char> BuildCharGridWithoutTrim(string input, char defaultValue = default)
    {
        var rows = StringReader.ReadLines(input).ToArray();
        return BuildCharGridWithoutTrim(new Grid<char>(1, 1, defaultValue), rows);
    }

    private static Grid<char> BuildCharGrid(Grid<char> grid, string[] rows)
    {
        var y = 0;
        foreach (var row in rows)
        {
            var x = 0;
            var chars = row.Trim().ToCharArray();
            foreach (var c in chars)
            {
                grid.MoveTo(x, y);
                grid.WriteValue(c);
                x += 1;
            }

            y += 1;
        }

        return grid;
    }

    private static Grid<char> BuildCharGridWithoutTrim(Grid<char> grid, string[] rows)
    {
        var y = 0;
        foreach (var row in rows)
        {
            var x = 0;
            var chars = row.ToCharArray();
            foreach (var c in chars)
            {
                grid.MoveTo(x, y);
                grid.WriteValue(c);
                x += 1;
            }

            y += 1;
        }

        return grid;
    }

    public static Grid<int> BuildIntGridFromSpaceSeparated(string input, int defaultValue = default)
    {
        var grid = new Grid<int>(1, 1, defaultValue);
        var rows = StringReader.ReadLines(input.Trim());
        var y = 0;
        foreach (var row in rows)
        {
            var x = 0;
            var numbers = row.Trim().Split(' ').Where(o => o.Length > 0).Select(int.Parse);
            foreach (var n in numbers)
            {
                grid.MoveTo(x, y);
                grid.WriteValue(n);
                x += 1;
            }

            y += 1;
        }

        return grid;
    }

    public static Grid<int> BuildIntGridFromNonSeparated(string input, int defaultValue = default)
    {
        var (w, h) = GetNonSeparatedSize(input);
        return BuildIntGridFromNonSeparated(new Grid<int>(w, h, defaultValue), input);
    }

    private static Grid<int> BuildIntGridFromNonSeparated(Grid<int> grid, string input)
    {
        var rows = StringReader.ReadLines(input.Trim());
        var y = 0;
        foreach (var row in rows)
        {
            var x = 0;
            var numbers = row.Trim().ToCharArray().Select(o => o.ToString()).Select(int.Parse);
            foreach (var n in numbers)
            {
                grid.MoveTo(x, y);
                grid.WriteValue(n);
                x += 1;
            }

            y += 1;
        }

        return grid;
    }

    private static (int w, int h) GetNonSeparatedSize(string input)
    {
        var rows = StringReader.ReadLines(input.Trim());
        var w = rows.First().Trim().Length;
        var h = rows.Count();
        return (w, h);
    }
}