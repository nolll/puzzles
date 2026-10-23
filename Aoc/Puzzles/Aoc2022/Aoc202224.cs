using System.Collections.Immutable;
using System.Diagnostics;
using System.Text;
using Pzl.Common;
using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Aoc.Puzzles.Aoc2022;

[Name("Blizzard Basin")]
public class Aoc202224 : AocPuzzle
{
    [Puzzle("2cfc10140c99d8efac8a77765769479d")]
    public int Part1(string input)
    {
        var (cache, blizzards, enter, exit) = Init(input);
        return CountSteps(blizzards, cache, enter, exit);
    }

    [Puzzle("f055d2b6a8b11466406da741a5dd4b83")]
    public int Part2(string input)
    {
        var (cache, blizzards, enter, exit) = Init(input);
        var leg1 = CountSteps(blizzards, cache, enter, exit);
        var leg2 = CountSteps(blizzards, cache, exit, enter, leg1);
        return CountSteps(blizzards, cache, enter, exit, leg2);
    }

    private const char Up = '^';
    private const char Right = '>';
    private const char Down = 'v';

    private (Dictionary<Coord, IList<Coord>>, List<ImmutableHashSet<Coord>>, Coord, Coord) Init(string input)
    {
        var enter = new Coord();
        var exit = new Coord();
        var neighborCache = new Dictionary<Coord, IList<Coord>>();
        var uniqueBlizzards = new List<ImmutableHashSet<Coord>>();
        var grid = GridBuilder.BuildCharGrid(input);
        var blizzards = new List<Blizzard>();
        var walls = new List<Coord>();
        foreach (var coord in grid.Coords)
        {
            var value = grid.ReadValueAt(coord);
            if (grid.IsAtTopEdge(coord) && value == '.')
            {
                enter = coord;
            }
            else if (grid.IsAtBottomEdge(coord) && value == '.')
            {
                exit = coord;
            }
            else if (value is not '#' && value is not '.')
            {
                blizzards.Add(new Blizzard(value, coord));
                grid.WriteValueAt(coord, '.');
            }
            else if (value == '#')
            {
                walls.Add(coord);
            }

            neighborCache.Add(coord, [.. grid.OrthogonalAdjacentCoordsTo(coord)]);
        }

        var prints = new HashSet<string>();
        while (true)
        {
            var print = PrintGrid(grid, blizzards);
            if (!prints.Add(print))
                break;

            uniqueBlizzards.Add([.. blizzards.Select(o => o.Coord), .. walls]);
            blizzards = MoveBlizzards(grid, blizzards);
        }

        return (neighborCache, uniqueBlizzards, enter, exit);
    }

    private int CountSteps(List<ImmutableHashSet<Coord>> blizzards, Dictionary<Coord, IList<Coord>> cache, Coord from, Coord to, int offset = 0)
    {
        var uniqueCount = blizzards.Count;
        var seen = new HashSet<(Coord, int)>();
        var queue = new List<BlizzardCoordCount> { new(from, offset) };
        var index = 0;

        while (index < queue.Count)
        {
            var current = queue[index];
            var nextCount = current.Count + 1;
            var nextState = nextCount % uniqueCount;
            var blizzardSet = blizzards[nextState];

            var adjacentCoords = cache[current.Coord]
                .Where(neighbor => !blizzardSet.Contains(neighbor) && !seen.Contains((neighbor, nextState)))
                .ToList();
            var newCoordCounts = adjacentCoords.Select(o => new BlizzardCoordCount(o, nextCount)).ToList();
            if (!blizzardSet.Contains(current.Coord) && !seen.Contains((current.Coord, nextState)))
                newCoordCounts.Add(new BlizzardCoordCount(current.Coord, nextCount));

            foreach (var coordCount in newCoordCounts)
            {
                queue.Add(coordCount);
                seen.Add((coordCount.Coord, nextState));
            }

            if (newCoordCounts.Any(o => o.Coord.X == to.X && o.Coord.Y == to.Y))
                break;

            index++;
        }

        return queue.FirstOrDefault(o => o.Coord.X == to.X && o.Coord.Y == to.Y)?.Count ?? 0;
    }

    private List<Blizzard> MoveBlizzards(Grid<char> grid, List<Blizzard> blizzards) =>
        blizzards.Select(blizzard => blizzard with { Coord = GetNewCoord(grid, blizzard) }).ToList();

    private static Coord GetNewCoord(Grid<char> grid, Blizzard blizzard) => blizzard.Direction switch
    {
        Up => GetNewCoordUp(grid, blizzard.Coord),
        Right => GetNewCoordRight(grid, blizzard.Coord),
        Down => GetNewCoordDown(grid, blizzard.Coord),
        _ => GetNewCoordLeft(grid, blizzard.Coord)
    };

    private static Coord GetNewCoordUp(Grid<char> g, Coord coord) => coord.Y == g.YMin + 1 ? new Coord(coord.X, g.YMax - 1) : coord.Up();
    private static Coord GetNewCoordRight(Grid<char> g, Coord coord) => coord.X == g.XMax - 1 ? new Coord(1, coord.Y) : coord.Right();
    private static Coord GetNewCoordDown(Grid<char> g, Coord coord) => coord.Y == g.YMax - 1 ? new Coord(coord.X, 1) : coord.Down();
    private static Coord GetNewCoordLeft(Grid<char> g, Coord coord) => coord.X == g.XMin + 1 ? new Coord(g.XMax - 1, coord.Y) : coord.Left();

    private static string PrintGrid(Grid<char> grid, List<Blizzard> blizzards)
    {
        var sb = new StringBuilder();
        foreach (var blizzard in blizzards)
        {
            var v = grid.ReadValueAt(blizzard.Coord);
            var pv = GetPrintValue(v);
            sb.Append(blizzard.Coord.Id);
            sb.Append(pv);
        }
        
        return sb.ToString();
    }

    private static char GetPrintValue(char v)
    {
        if (v == '.')
            return v;

        if (char.IsDigit(v))
            return (char)(v + 1);

        return '2';
    }

    private record Blizzard(char Direction, Coord Coord);

    [DebuggerDisplay("{X},{Y},{Count}")]
    private record BlizzardCoordCount(Coord Coord, int Count)
    {
        public int X => Coord.X;
        public int Y => Coord.Y;
    }
}