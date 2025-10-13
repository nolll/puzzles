using Pzl.Tools.Grids.Grids2d;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2021.Aoc202105;

public class VentsMap
{
    public int Run(string input, bool orthogonalOnly)
    {
        var rows = StringReader.ReadLines(input);
        var lines = ParseLines(rows);
        if (orthogonalOnly)
            lines = lines.Where(o => o.IsOrthogonal).ToList();
        var width = lines.Max(o => Math.Max(o.Start.X, o.End.X));
        var height = lines.Max(o => Math.Max(o.Start.Y, o.End.Y));
        var grid = new Grid<int>(width, height);

        grid = MapLines(grid, lines);
        var c = grid.Values.Count(o => o >= 2);

        return c;
    }

    private static Grid<int> MapLines(Grid<int> grid, List<Line2d> lines)
    {
        foreach (var line in lines)
        {
            foreach (var pos in line.Positions)
            {
                grid.WriteValueAt(pos.X, pos.Y, grid.ReadValueAt(pos.X, pos.Y) + 1);
            }
        }

        return grid;
    }

    private static List<Line2d> ParseLines(IEnumerable<string> rows) => rows.Select(ParseLine).ToList();

    private static Line2d ParseLine(string s)
    {
        var (a, b) = s.Split(" -> ").Select(ParsePosition).ToArray();
        return new Line2d(a, b);
    }

    private static Position2d ParsePosition(string s)
    {
        var (a, b) = s.Split(',').Select(int.Parse).ToArray();
        return new Position2d(a, b);
    }
}