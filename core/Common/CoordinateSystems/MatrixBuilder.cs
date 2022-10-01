using System.Linq;

namespace Core.Common.CoordinateSystems;

public static class MatrixBuilder
{
    public static IMatrix<char> BuildStaticCharMatrix(string input, char defaultValue = default)
    {
        return BuildCharMatrix(new StaticMatrix<char>(1, 1, defaultValue), input);
    }

    public static IMatrix<char> BuildCharMatrix(string input, char defaultValue = default)
    {
        return BuildCharMatrix(new Matrix<char>(1, 1, defaultValue), input);
    }

    private static IMatrix<char> BuildCharMatrix(IMatrix<char> matrix, string input)
    {
        var rows = input.Trim().Split('\n');
        var y = 0;
        foreach (var row in rows)
        {
            var x = 0;
            var chars = row.Trim().ToCharArray();
            foreach (var c in chars)
            {
                matrix.MoveTo(x, y);
                matrix.WriteValue(c);
                x += 1;
            }

            y += 1;
        }

        return matrix;
    }

    public static Matrix<int> BuildIntMatrixFromSpaceSeparated(string input, int defaultValue = default)
    {
        var matrix = new Matrix<int>(1, 1, defaultValue);
        var rows = input.Trim().Split('\n');
        var y = 0;
        foreach (var row in rows)
        {
            var x = 0;
            var numbers = row.Trim().Split(' ').Where(o => o.Length > 0).Select(int.Parse);
            foreach (var n in numbers)
            {
                matrix.MoveTo(x, y);
                matrix.WriteValue(n);
                x += 1;
            }

            y += 1;
        }

        return matrix;
    }

    public static IMatrix<int> BuildStaticIntMatrixFromNonSeparated(string input, int defaultValue = default)
    {
        var (w, h) = GetNonSeparatedSize(input);
        return BuildIntMatrixFromNonSeparated(new StaticMatrix<int>(w, h, defaultValue), input);
    }

    public static IMatrix<int> BuildIntMatrixFromNonSeparated(string input, int defaultValue = default)
    {
        var (w, h) = GetNonSeparatedSize(input);
        return BuildIntMatrixFromNonSeparated(new Matrix<int>(w, h, defaultValue), input);
    }

    private static IMatrix<int> BuildIntMatrixFromNonSeparated(IMatrix<int> matrix, string input)
    {
        var rows = input.Trim().Split('\n');
        var y = 0;
        foreach (var row in rows)
        {
            var x = 0;
            var numbers = row.Trim().ToCharArray().Select(o => o.ToString()).Select(int.Parse);
            foreach (var n in numbers)
            {
                matrix.MoveTo(x, y);
                matrix.WriteValue(n);
                x += 1;
            }

            y += 1;
        }

        return matrix;
    }

    private static (int w, int h) GetNonSeparatedSize(string input)
    {
        var rows = input.Trim().Split('\n');
        var w = rows.First().Trim().Length;
        var h = rows.Count();
        return (w, h);
    }
}