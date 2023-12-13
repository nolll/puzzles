using Pzl.Common;
using Pzl.Tools.CoordinateSystems.CoordinateSystem2D;
using Pzl.Tools.Strings;
using Spectre.Console;

namespace Pzl.Aoc.Puzzles.Aoc2023.Aoc202313;

[Name("Point of Incidence")]
public class Aoc202313(string input) : AocPuzzle
{
    protected override PuzzleResult RunPart1()
    {
        var s = StringReader.ReadStringGroups(input);
        var result = s.Sum(CountReflections);

        return new PuzzleResult(result, "ee9ffa0006ecc43014e2c3a817904396");
    }

    protected override PuzzleResult RunPart2()
    {
        var s = StringReader.ReadStringGroups(input);
        var result = s.Sum(CountSmudgedReflections);

        return new PuzzleResult(result);
    }

    public static int CountReflections(string s)
    {
        var matrix = MatrixBuilder.BuildCharMatrix(s);

        return CountReflections(matrix);
    }

    public static int CountReflections(Matrix<char> matrix)
    {
        var rows = Rows(matrix);
        if (rows > 0)
            return rows * 100;

        return Columns(matrix);
    }

    public static int CountRowReflections(Matrix<char> matrix) => Rows(matrix) * 100;
    public static int CountColReflections(Matrix<char> matrix) => Columns(matrix);

    public static int CountSmudgedReflections(string s)
    {
        var matrix = MatrixBuilder.BuildCharMatrix(s);
        var orig = CountReflections(matrix);

        foreach (var coord in matrix.Coords)
        {
            var v = matrix.ReadValueAt(coord);
            var n = v == '#' ? '.' : '#';
            matrix.WriteValueAt(coord, n);
            var c = CountReflections(matrix);
            matrix.WriteValueAt(coord, v);
            if (c > 0 && c != orig)
            {
                //Console.WriteLine($"{orig} => {c}");
                return c;
            }
        }
        
        return 0;
    }

    //public static int CountSmudgedReflections(string s)
    //{
    //    var matrix = MatrixBuilder.BuildCharMatrix(s);
    //    var orig = CountReflections(matrix);
    //    var origRows = CountRowReflections(matrix);

    //    foreach (var coord in matrix.Coords)
    //    {
    //        var v = matrix.ReadValueAt(coord);
    //        var n = v == '#' ? '.' : '#';
    //        matrix.WriteValueAt(coord, n);
    //        var rows = CountRowReflections(matrix);
    //        matrix.WriteValueAt(coord, v);
    //        if (rows > 0 && rows != origRows && rows != orig)
    //            return rows;
    //    }

    //    var origCols = CountColReflections(matrix);
    //    foreach (var coord in matrix.Coords)
    //    {
    //        var v = matrix.ReadValueAt(coord);
    //        var n = v == '#' ? '.' : '#';
    //        matrix.WriteValueAt(coord, n);
    //        var cols = CountColReflections(matrix);
    //        matrix.WriteValueAt(coord, v);
    //        if (cols > 0 && cols != origCols && cols != orig)
    //            return cols;
    //    }

    //    return 0;
    //}

    private static int Columns(Matrix<char> matrix)
    {
        var cols = Enumerable.Range(0, matrix.XMax + 1).Select(o => ReadCol(matrix, o)).ToList();
        return FindReflection(cols);
    }

    private static int Rows(Matrix<char> matrix)
    {
        var rows = Enumerable.Range(0, matrix.YMax + 1).Select(o => ReadRow(matrix, o)).ToList();
        return FindReflection(rows);
    }

    private static int FindReflection(List<string> lines)
    {
        for (var i = 1; i < lines.Count; i++)
        {
            var xDown = i;
            var xUp = i - 1;
            var down = lines[xDown];
            var up = lines[xUp];

            while (down == up)
            {
                if (xUp <= 0 || xDown >= lines.Count - 1)
                {
                    return i;
                }

                xDown++;
                xUp--;
                down = lines[xDown];
                up = lines[xUp];
            }
        }

        return 0;
    }

    private static string ReadRow(Matrix<char> matrix, int y)
    {
        var currentCol = "";
        for (var x = 0; x <= matrix.XMax; x++)
        {
            currentCol += matrix.ReadValueAt(x, y);
        }

        return currentCol;
    }

    private static string ReadCol(Matrix<char> matrix, int x)
    {
        var currentRow = "";
        for (var y = 0; y <= matrix.YMax; y++)
        {
            currentRow += matrix.ReadValueAt(x, y);
        }

        return currentRow;
    }
}