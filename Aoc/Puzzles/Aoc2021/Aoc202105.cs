using Pzl.Common;
using Pzl.Tools.Grids.Grids2d;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2021;

[Name("Hydrothermal Venture")]
public class Aoc202105 : AocPuzzle
{
    [Puzzle("72e2846f2036e57e75a10d9d0b5a99ad")]
    public int Part1(string input) => Solve(input, true);

    [Puzzle("e07b568228a7ed5a9bc9276d343e6973")]
    public int Part2(string input) => Solve(input, false);

    private static int Solve(string input, bool orthogonalOnly)
    {
        var rows = input.Split(LineBreaks.Single);
        var lines = ParseLines(rows);
        if (orthogonalOnly)
            lines = [.. lines.Where(o => o.IsOrthogonal)];

        return MapLines(lines).Values.Count(o => o >= 2);
    }

    private static Grid<int> MapLines(List<Line> lines)
    {
        var width = lines.Max(o => Math.Max(o.Start.X, o.End.X));
        var height = lines.Max(o => Math.Max(o.Start.Y, o.End.Y));
        var grid = new Grid<int>(width, height);
        
        foreach (var pos in lines.SelectMany(line => line.Positions)) 
            grid.WriteValueAt(pos.X, pos.Y, grid.ReadValueAt(pos.X, pos.Y) + 1);

        return grid;
    }

    private static List<Line> ParseLines(IEnumerable<string> rows) => rows.Select(ParseLine).ToList();

    private static Line ParseLine(string s)
    {
        var (a, b) = s.Split(" -> ").Select(ParsePosition).ToArray();
        return new Line(a, b);
    }

    private static Coord ParsePosition(string s)
    {
        var (a, b) = s.Split(',').Select(int.Parse).ToArray();
        return new Coord(a, b);
    }

    private class Line
    {
        public Coord Start { get; }
        public Coord End { get; }
        public List<Coord> Positions { get; }
        public bool IsOrthogonal { get; }

        public Line(Coord a, Coord b)
        {
            var list = new List<Coord> { a, b };
            list = [.. list.OrderBy(o => o.X).ThenBy(o => o.Y)];

            Start = list.First();
            End = list.Last();

            var isHorizontal = a.Y == b.Y;
            var isVertical = a.X == b.X;
            IsOrthogonal = isHorizontal || isVertical;

            Positions = [.. GetPositions()];
        }

        private IEnumerable<Coord> GetPositions()
        {
            var x = Start.X;
            var y = Start.Y;
            var xDiff = End.X - Start.X;
            var yDiff = End.Y - Start.Y;
            var xDelta = xDiff != 0 ? xDiff / Math.Abs(xDiff) : 0;
            var yDelta = yDiff != 0 ? yDiff / Math.Abs(yDiff) : 0;
            var xMin = Math.Min(Start.X, End.X);
            var yMin = Math.Min(Start.Y, End.Y);
            var xMax = Math.Max(Start.X, End.X);
            var yMax = Math.Max(Start.Y, End.Y);

            if (xDiff == 0 && yDiff == 0)
                yield return new Coord(Start.X, Start.Y);

            while (x >= xMin && x <= xMax && y >= yMin && y <= yMax)
            {
                yield return new Coord(x, y);
                x += xDelta;
                y += yDelta;
            }
        }
    }
}