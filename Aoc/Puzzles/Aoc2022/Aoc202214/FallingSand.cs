using Pzl.Tools.Grids.Grids2d;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2022.Aoc202214;

public class FallingSand
{
    private static class Chars
    {
        public const char Space = '.';
        public const char Sand = 'o';
        public const char Wall = '#';
    }
    
    private readonly Coord _sandSource = new(500, 0);

    public int Part1(string input)
    {
        var grid = BuildGrid(input, 1);

        grid.MoveTo(_sandSource);
        while (grid.ReadValueAt(_sandSource) == Chars.Space)
        {
            var currentSand = _sandSource;

            while (TryMove(grid, currentSand, out var newSand))
            {
                currentSand = newSand;

                if (currentSand.Y == grid.Height - 1)
                    break;
            }

            if (currentSand.Y == grid.Height - 1)
                break;

            grid.WriteValueAt(currentSand, Chars.Sand);
        }

        return grid.Values.Count(o => o == Chars.Sand);
    }

    public int Part2(string input)
    {
        var grid = BuildGrid(input, 2);

        grid.MoveTo(_sandSource);
        while (grid.ReadValueAt(_sandSource) == Chars.Space)
        {
            var currentSand = _sandSource;
            while (TryMove(grid, currentSand, out var newSand))
            {
                currentSand = newSand;
            }

            grid.WriteValueAt(currentSand, Chars.Sand);
        }

        return grid.Values.Count(o => o == Chars.Sand);
    }

    private static Grid<char> BuildGrid(string input, int part)
    {
        var grid = new Grid<char>(1, 1, Chars.Space);
        var lines = StringReader.ReadLines(input, false);

        var coordLists = lines.Select(o => o.Split(" -> "));
        foreach (var coordList in coordLists)
        {
            var coords = new List<Coord>();
            foreach (var coord in coordList)
            {
                var parts = coord.Split(',');
                var x = int.Parse(parts[0]);
                var y = int.Parse(parts[1]);
                coords.Add(new Coord(x, y));
            }

            for (var i = 1; i < coords.Count; i++)
            {
                var a = coords[i - 1];
                var b = coords[i];

                var minX = Math.Min(a.X, b.X);
                var minY = Math.Min(a.Y, b.Y);
                var maxX = Math.Max(a.X, b.X);
                var maxY = Math.Max(a.Y, b.Y);
                
                if (a.X == b.X)
                {
                    var x = a.X;
                    for (var y = minY; y <= maxY; y++)
                    {
                        grid.MoveTo(x, y);
                        grid.WriteValueAt(x, y, Chars.Wall);
                    }
                }
                else
                {
                    var y = a.Y;
                    for (var x = minX; x <= maxX; x++)
                    {
                        grid.MoveTo(x, y);
                        grid.WriteValueAt(x, y, Chars.Wall);
                    }
                }
            }
        }

        if (part == 1)
        {
            grid.ExtendRight();
        }

        if (part == 2)
        {
            grid.ExtendRight(grid.Width);
            grid.ExtendDown(2);
            var sy = grid.Height - 1;
            for (var x = 0; x < grid.Width; x++)
            {
                grid.WriteValueAt(x, sy, Chars.Wall);
            }
        }

        return grid;
    }

    private static bool TryMove(Grid<char> grid, Coord currentSand, out Coord newSand)
    {
        var down = new Coord(currentSand.X, currentSand.Y + 1);
        grid.MoveTo(down);

        if (grid.ReadValueAt(down) == Chars.Space)
        {
            newSand = down;
            return true;
        }

        var downLeft = new Coord(down.X - 1, down.Y);
        grid.MoveTo(downLeft);
        if (grid.ReadValueAt(downLeft) == Chars.Space)
        {
            newSand = downLeft;
            return true;
        }

        var downRight = new Coord(down.X + 1, down.Y);
        grid.MoveTo(downRight);
        if (grid.ReadValueAt(downRight) == Chars.Space)
        {
            newSand = downRight;
            return true;
        }

        newSand = currentSand;
        return false;
    }
}