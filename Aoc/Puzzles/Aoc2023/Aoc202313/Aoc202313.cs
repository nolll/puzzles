using Pzl.Common;
using Pzl.Tools.CoordinateSystems.CoordinateSystem2D;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2023.Aoc202313;

[Name("Point of Incidence")]
public class Aoc202313 : AocPuzzle
{
    protected override PuzzleResult RunPart1(string input)
    {
        var s = StringReader.ReadStringGroups(input);
        var result = s.Sum(CountReflections);

        return new PuzzleResult(result, "ee9ffa0006ecc43014e2c3a817904396");
    }

    protected override PuzzleResult RunPart2(string input)
    {
        var s = StringReader.ReadStringGroups(input);
        var result = s.Sum(CountSmudgedReflections);

        return new PuzzleResult(result, "32a6556a3bdfe559c36bdafb480740ef");
    }

    public static int CountReflections(string s)
    {
        var matrix = MatrixBuilder.BuildCharMatrix(s);

        return CountReflections(matrix, -1);
    }

    private static int CountReflections(Matrix<char> matrix, int orig)
    {
        var rows = Rows(matrix, orig);
        if (rows > 0)
            return rows * 100;

        return Columns(matrix, orig);
    }

    public static int CountSmudgedReflections(string s)
    {
        var matrix = MatrixBuilder.BuildCharMatrix(s);
        var orig = CountReflections(matrix, -1);

        foreach (var coord in matrix.Coords)
        {
            var v = matrix.ReadValueAt(coord);
            var n = v == '#' ? '.' : '#';
            matrix.WriteValueAt(coord, n);
            var c = CountReflections(matrix, orig);
            matrix.WriteValueAt(coord, v);
            if (c > 0)
            {
                return c;
            }
        }
        
        return 0;
    }

    private static int Columns(Matrix<char> matrix, int orig)
    {
        var cols = Enumerable.Range(0, matrix.Width).Select(x => ReadCol(matrix, x)).ToList();
        return FindReflection(cols, orig);
    }

    private static int Rows(Matrix<char> matrix, int orig)
    {
        var rows = Enumerable.Range(0, matrix.Height).Select(y => ReadRow(matrix, y)).ToList();
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

    private static string ReadRow(Matrix<char> matrix, int y) => 
        string.Join("", Enumerable.Range(0, matrix.Width).Select(x => matrix.ReadValueAt(x, y)));

    private static string ReadCol(Matrix<char> matrix, int x) =>
        string.Join("", Enumerable.Range(0, matrix.Height).Select(y => matrix.ReadValueAt(x, y)));
}