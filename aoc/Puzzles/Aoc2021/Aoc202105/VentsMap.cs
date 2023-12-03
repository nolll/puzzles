using Puzzles.Common.CoordinateSystems.CoordinateSystem2D;
using Puzzles.Common.Strings;

namespace Puzzles.Aoc.Puzzles.Aoc2021.Aoc202105;

public class VentsMap
{
    public int Run(string input, bool perpendicularOnly)
    {
        var rows = StringReader.ReadLines(input);
        var lines = ParseLines(rows);
        if (perpendicularOnly)
            lines = lines.Where(o => o.IsPerpendicular).ToList();
        var width = lines.Max(o => Math.Max(o.Start.X, o.End.X));
        var height = lines.Max(o => Math.Max(o.Start.Y, o.End.Y));
        var matrix = new Matrix<int>(width, height);

        matrix = MapLines(matrix, lines);
        var c = matrix.Values.Count(o => o >= 2);

        return c;
    }

    private static Matrix<int> MapLines(Matrix<int> matrix, List<Line2d> lines)
    {
        foreach (var line in lines)
        {
            foreach (var pos in line.Positions)
            {
                matrix.WriteValueAt(pos.X, pos.Y, matrix.ReadValueAt(pos.X, pos.Y) + 1);
            }
        }

        return matrix;
    }

    private static List<Line2d> ParseLines(IEnumerable<string> rows)
    {
        return rows.Select(ParseLine).ToList();
    }

    private static Line2d ParseLine(string s)
    {
        var positions = s.Split(" -> ").Select(ParsePosition).ToList();
        return new Line2d(positions[0], positions[1]);
    }

    private static Position2d ParsePosition(string s)
    {
        var parts = s.Split(',').Select(int.Parse).ToArray();
        return new Position2d(parts[0], parts[1]);
    }
}