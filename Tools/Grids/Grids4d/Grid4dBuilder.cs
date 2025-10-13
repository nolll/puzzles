using Pzl.Tools.Strings;

namespace Pzl.Tools.Grids.Grids4d;

public static class Grid4dBuilder
{
    public static Grid4d<char> BuildCharGrid(string input, char defaultValue = default)
    {
        var grid = new Grid4d<char>(1, 1, 1, 1, defaultValue);
        var rows = input.Trim().Split(LineBreaks.Single);
        const int w = 0;
        const int z = 0;
        var y = 0;
        foreach (var row in rows)
        {
            var x = 0;
            var chars = row.Trim().ToCharArray();
            foreach (var c in chars)
            {
                grid.MoveTo(x, y, z, w);
                grid.WriteValue(c);
                x += 1;
            }

            y += 1;
        }

        return grid;
    }
}