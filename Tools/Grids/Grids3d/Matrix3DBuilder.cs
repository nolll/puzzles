namespace Pzl.Tools.Grids.Grids3d;

public static class Matrix3DBuilder
{
    public static Matrix3D<char> BuildCharMatrix(string input, char defaultValue = default)
    {
        var matrix = new Matrix3D<char>(1, 1, 1, defaultValue);
        var rows = input.Trim().Split('\n');
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