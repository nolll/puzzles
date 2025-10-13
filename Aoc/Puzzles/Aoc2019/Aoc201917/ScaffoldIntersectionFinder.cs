using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Aoc.Puzzles.Aoc2019.Aoc201917;

public class ScaffoldIntersectionFinder
{
    private readonly Grid<char> _grid;

    public ScaffoldIntersectionFinder(string input)
    {
        _grid = BuildGrid(input);
    }

    public int GetSumOfAlignmentParameters()
    {
        var intersections = GetIntersections().ToList();
        var sum = intersections.Sum(o => o.X * o.Y);
        return sum;
    }

    private IEnumerable<Coord> GetIntersections()
    {
        return _grid.Coords.Where(coord => IsIntersection(coord.X, coord.Y)).ToList();
    }

    private char? GetValueAt(Coord coord)
    {
        if (_grid.IsOutOfRange(coord))
            return null;
        return _grid.ReadValueAt(coord);
    }

    private bool IsIntersection(int x, int y)
    {
        var v = GetValueAt(new Coord(x, y));
        if (v == '.')
            return false;

        v = GetValueAt(new Coord(x, y - 1));
        if (v == '.')
            return false;

        v = GetValueAt(new Coord(x + 1, y));
        if (v == '.')
            return false;

        v = GetValueAt(new Coord(x, y + 1));
        if (v == '.')
            return false;

        v = GetValueAt(new Coord(x - 1, y));
        if (v == '.')
            return false;

        return true;
    }

    private Grid<char> BuildGrid(string map)
    {
        var grid = new Grid<char>();
        var rows = map.Trim().Split('\n');
        var y = 0;
        foreach (var row in rows)
        {
            var x = 0;
            var chars = row.Trim().ToCharArray();
            foreach (var c in chars)
            {
                grid.MoveTo(x, y);
                grid.WriteValue(c);
                x += 1;
            }

            y += 1;
        }

        return grid;
    }
}