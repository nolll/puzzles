using Pzl.Common;
using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Aoc.Puzzles.Aoc2023.Aoc202323;

[Name("A Long Walk")]
public class Aoc202323 : AocPuzzle
{
    private static readonly Dictionary<GridDirection, char> ValidSlopes = new()
    {
        { GridDirection.Up, '^' },
        { GridDirection.Right, '>' },
        { GridDirection.Down, 'v' },
        { GridDirection.Left, '<' }
    };

    public PuzzleResult RunPart1(string input)
    {
        return new PuzzleResult(LongestHike(input, false), "854218011528db376afeffbf53800ecd");
    }

    public PuzzleResult RunPart2(string input)
    {
        return new PuzzleResult(LongestHike(input, true), "22bcf9382d0e8177c5c6ef52f07fd7b9");
    }

    public static int LongestHike(string s, bool canClimbSlopes)
    {
        var matrix = GridBuilder.BuildCharGrid(s);
        var start = new Coord(matrix.XMin + 1, matrix.YMin);
        var target = new Coord(matrix.XMax - 1, matrix.YMax);

        var graphCoords = FindGraphCoords(matrix, start, target).ToList();
        var graph = BuildGraph(matrix, graphCoords, canClimbSlopes);

        return FindLongestRoute(graph, [], start.Id, target.Id);
    }

    private static IEnumerable<Coord> FindGraphCoords(Grid<char> grid, Coord start, Coord target)
    {
        yield return start;
        yield return target;

        foreach (var current in grid.Coords)
        {
            if (grid.ReadValueAt(current) == '#')
                continue;

            var neighbors = grid.OrthogonalAdjacentCoordsTo(current)
                .Where(o => grid.ReadValueAt(o) != '#');
            if (neighbors.Count() > 2)
            {
                yield return current;
            }
        }
    }

    private static Dictionary<string, Dictionary<string, int>> BuildGraph(
        Grid<char> grid,
        List<Coord> graphCoords, 
        bool canClimbSlopes)
    {
        var graph = new Dictionary<string, Dictionary<string, int>>();
        foreach (var startCoord in graphCoords)
        {
            var queue = new Queue<(Coord, int)>();
            queue.Enqueue((startCoord, 0));
            var seen = new HashSet<Coord> { startCoord };
            graph.Add(startCoord.Id, new());

            while (queue.Count > 0)
            {
                var (current, distance) = queue.Dequeue();
                if (distance != 0 && graphCoords.Contains(current))
                {
                    graph[startCoord.Id].Add(current.Id, distance);
                    continue;
                }

                var neigbors = GetNeighbors(grid, current, canClimbSlopes).Where(o => !seen.Contains(o));
                foreach (var neighbor in neigbors)
                {
                    queue.Enqueue((neighbor, distance + 1));
                    seen.Add(neighbor);
                }
            }
        }

        return graph;
    }

    private static int FindLongestRoute(
        Dictionary<string, Dictionary<string, int>> graph, 
        HashSet<string> seen,
        string current, 
        string target)
    {
        if (current == target)
            return 0;

        var max = int.MinValue;
        var connections = graph[current];
        var newSeen = seen.ToHashSet();
        newSeen.Add(current);
        foreach (var connection in connections.Keys)
        {
            if(newSeen.Contains(connection))
                continue;

            max = Math.Max(max, FindLongestRoute(graph, newSeen, connection, target) + graph[current][connection]);
        }

        return max;
    }

    private static List<Coord> GetNeighbors(Grid<char> grid, Coord coord, bool canClimbSlopes)
    {
        var adjacent = new List<Coord>();
        var north = GetCoord(coord, GridDirection.Up);
        var east = GetCoord(coord, GridDirection.Right);
        var south = GetCoord(coord, GridDirection.Down);
        var west = GetCoord(coord, GridDirection.Left);

        if (CanGoDirection(grid, north, canClimbSlopes, GridDirection.Up)) adjacent.Add(north);
        if (CanGoDirection(grid, east, canClimbSlopes, GridDirection.Right)) adjacent.Add(east);
        if (CanGoDirection(grid, south, canClimbSlopes, GridDirection.Down)) adjacent.Add(south);
        if (CanGoDirection(grid, west, canClimbSlopes, GridDirection.Left)) adjacent.Add(west);

        return adjacent;
    }

    private static bool CanGoDirection(Grid<char> grid, Coord coord, bool canClimbSlopes, GridDirection direction)
    {
        if (grid.IsOutOfRange(coord))
            return false;

        var value = grid.ReadValueAt(coord);
        if (canClimbSlopes && value is not '#')
            return true;

        return value == '.' || value == ValidSlopes[direction];
    }

    private static Coord GetCoord(Coord coord, GridDirection direction) => 
        new(coord.X + direction.X, coord.Y + direction.Y);
}