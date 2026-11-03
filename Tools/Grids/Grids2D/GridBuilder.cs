using Pzl.Tools.Strings;

namespace Pzl.Tools.Grids.Grids2d;

public static class GridBuilder
{
    public static Grid<char> BuildCharGrid(string input, char defaultValue = default)
    {
        var rows = input.Split(LineBreaks.Single);
        return BuildCharGrid(new Grid<char>(1, 1, defaultValue), rows);
    }

    private static Grid<char> BuildCharGrid(Grid<char> grid, string[] rows)
    {
        var y = 0;
        foreach (var row in rows)
        {
            var x = 0;
            var chars = row.ToCharArray();
            foreach (var c in chars)
            {
                grid.WriteValueAt(x, y, c);
                x += 1;
            }

            y += 1;
        }

        return grid;
    }

    public static Grid<int> BuildIntGridFromSpaceSeparated(string input, int defaultValue = default)
    {
        var grid = new Grid<int>(1, 1, defaultValue);
        var rows = input.Split(LineBreaks.Single);
        var y = 0;
        foreach (var row in rows)
        {
            var x = 0;
            var numbers = row.Split(' ').Where(o => o.Length > 0).Select(int.Parse);
            foreach (var n in numbers)
            {
                grid.WriteValueAt(x, y, n);
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
        var rows = input.Split(LineBreaks.Single);
        var y = 0;
        foreach (var row in rows)
        {
            var x = 0;
            var numbers = row.Select(o => o.ToString()).Select(int.Parse);
            foreach (var n in numbers)
            {
                grid.WriteValueAt(x, y, n);
                x += 1;
            }

            y += 1;
        }

        return grid;
    }

    private static (int w, int h) GetNonSeparatedSize(string input)
    {
        var rows = input.Trim().Split(LineBreaks.Single);
        return (rows.First().Trim().Length, rows.Length);
    }
}