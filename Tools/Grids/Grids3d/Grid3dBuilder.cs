using Pzl.Tools.Strings;

namespace Pzl.Tools.Grids.Grids3d;

public static class Grid3dBuilder
{
    public static Grid3d<char> BuildCharMatrix(string input, char defaultValue = default)
    {
        var matrix = new Grid3d<char>(1, 1, 1, defaultValue);
        var rows = input.Trim().Split(LineBreaks.Single);
        const int z = 0;
        var y = 0;
        foreach (var row in rows)
        {
            var x = 0;
            var chars = row.Trim().ToCharArray();
            foreach (var c in chars)
            {
                matrix.MoveTo(x, y, z);
                matrix.WriteValue(c);
                x += 1;
            }

            y += 1;
        }

        return matrix;
    }
}