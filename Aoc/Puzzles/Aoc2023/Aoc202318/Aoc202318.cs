using Pzl.Common;
using Pzl.Tools.CoordinateSystems.CoordinateSystem2D;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2023.Aoc202318;

// Googled and found the shoelace formula after hours of failed attempts
[Name("Lavaduct Lagoon")]
public class Aoc202318(string input) : AocPuzzle
{
    protected override PuzzleResult RunPart1()
    {
        var result = DigPoolPart1(input);

        return new PuzzleResult(result, "61347c48a0a4bc715d0c1c2ea446a36e");
    }

    protected override PuzzleResult RunPart2()
    {
        var result = DigPoolPart2(input);

        return new PuzzleResult(result, "5ad2f7a72c31e629c55fb65dab16d204");
    }

    public static long DigPoolPart1(string s)
    {
        var matrix = new Matrix<char>(1, 1, '.');
        var rows = StringReader.ReadLines(s);
        var lines = new List<Line>();
        var currentCoord = new MatrixAddress(matrix.XMin, matrix.YMin);
        var corners = new List<MatrixAddress> { currentCoord };
        foreach (var row in rows)
        {
            var parts = row.Split(' ').ToArray();
            var dir = ParseDirectionPart1(parts[0][0]);
            var len = int.Parse(parts[1]);

            var nextCoord = new MatrixAddress(currentCoord.X + dir.X * len, currentCoord.Y + dir.Y * len);
            lines.Add(new Line(currentCoord, nextCoord));
            corners.Add(nextCoord);
            currentCoord = nextCoord;
        }

        return Area(corners, lines);
    }

    public static long DigPoolPart2(string s)
    {
        var matrix = new Matrix<char>(1, 1, '.');
        var rows = StringReader.ReadLines(s);
        var currentCoord = new MatrixAddress(matrix.XMin, matrix.YMin);
        var lines = new List<Line>();
        var corners = new List<MatrixAddress> { currentCoord };
        foreach (var row in rows)
        {
            var parts = row.Split(' ').ToArray();
            var hex = parts[2].TrimStart('(').TrimEnd(')').TrimStart('#');
            var dir = ParseDirectionPart2(hex.Last());
            var len = ParseHex(hex[..5]);
            var next = new MatrixAddress(currentCoord.X + dir.X * len, currentCoord.Y + dir.Y * len);
            lines.Add(new Line(currentCoord, next));
            corners.Add(next);
            currentCoord = next;
        }

        return Area(corners, lines);
    }

    private static long Area(List<MatrixAddress> corners, List<Line> lines)
    {
        var area = ShoelaceArea(corners.Select(o => ((long)o.X, (long)o.Y)).ToList());
        var circ = lines.Sum(o => o.From.ManhattanDistanceTo(o.To));

        return area + circ / 2 + 1;
    }

    private static long ShoelaceArea(List<(long X, long Y)> coords)
    {
        var n = coords.Count;
        long a = 0;
        for (var i = 0; i < n - 1; i++)
        {
            a += coords[i].X * coords[i + 1].Y - coords[i + 1].X * coords[i].Y;
        }
        return Math.Abs(a + coords[n - 1].X * coords[0].Y - coords[0].X * coords[n - 1].Y) / 2;
    }

    public static int ParseHex(string hex) => Convert.ToInt32(hex, 16);

    private static MatrixDirection ParseDirectionPart1(char c)
    {
        return c switch
        {
            'U' => MatrixDirection.Up,
            'R' => MatrixDirection.Right,
            'D' => MatrixDirection.Down,
            _ => MatrixDirection.Left
        };
    }

    private static MatrixDirection ParseDirectionPart2(char c)
    {
        return c switch
        {
            '3' => MatrixDirection.Up,
            '0' => MatrixDirection.Right,
            '1' => MatrixDirection.Down,
            _ => MatrixDirection.Left
        };
    }
}

public class Line(MatrixAddress from, MatrixAddress to)
{
    public MatrixAddress From { get; } = from;
    public MatrixAddress To { get; } = to;
}
