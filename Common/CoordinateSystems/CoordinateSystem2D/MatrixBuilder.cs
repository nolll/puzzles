using Puzzles.Common.Strings;
using StringReader = Puzzles.Common.Strings.StringReader;

namespace Puzzles.Common.CoordinateSystems.CoordinateSystem2D;

public static class MatrixBuilder
{
    public static Matrix<char> BuildCharMatrix(string input, char defaultValue = default)
    {
        var rows = StringReader.ReadLines(input.Trim()).Select(o => o.Trim()).ToArray();
        return BuildCharMatrix(new Matrix<char>(1, 1, defaultValue), rows);
    }

    public static Matrix<char> BuildCharMatrixWithoutTrim(string input, char defaultValue = default)
    {
        var rows = StringReader.ReadLines(input).ToArray();
        return BuildCharMatrixWithoutTrim(new Matrix<char>(1, 1, defaultValue), rows);
    }

    private static Matrix<char> BuildCharMatrix(Matrix<char> matrix, string[] rows)
    {
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

    private static Matrix<char> BuildCharMatrixWithoutTrim(Matrix<char> matrix, string[] rows)
    {
        var y = 0;
        foreach (var row in rows)
        {
            var x = 0;
            var chars = row.ToCharArray();
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
        var rows = StringReader.ReadLines(input.Trim());
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

    public static Matrix<int> BuildIntMatrixFromNonSeparated(string input, int defaultValue = default)
    {
        var (w, h) = GetNonSeparatedSize(input);
        return BuildIntMatrixFromNonSeparated(new Matrix<int>(w, h, defaultValue), input);
    }

    private static Matrix<int> BuildIntMatrixFromNonSeparated(Matrix<int> matrix, string input)
    {
        var rows = StringReader.ReadLines(input.Trim());
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
        var rows = StringReader.ReadLines(input.Trim());
        var w = rows.First().Trim().Length;
        var h = rows.Count();
        return (w, h);
    }
}