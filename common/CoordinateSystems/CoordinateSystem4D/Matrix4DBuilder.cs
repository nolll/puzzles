namespace Puzzles.Common.CoordinateSystems.CoordinateSystem4D;

public static class Matrix4DBuilder
{
    public static Matrix4D<char> BuildCharMatrix(string input, char defaultValue = default)
    {
        var matrix = new Matrix4D<char>(1, 1, 1, 1, defaultValue);
        var rows = input.Trim().Split('\n');
        const int w = 0;
        const int z = 0;
        var y = 0;
        foreach (var row in rows)
        {
            var x = 0;
            var chars = row.Trim().ToCharArray();
            foreach (var c in chars)
            {
                matrix.MoveTo(x, y, z, w);
                matrix.WriteValue(c);
                x += 1;
            }

            y += 1;
        }

        return matrix;
    }
}