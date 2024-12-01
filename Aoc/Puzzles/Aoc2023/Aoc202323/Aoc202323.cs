using Pzl.Common;
using Pzl.Tools.CoordinateSystems.CoordinateSystem2D;

namespace Pzl.Aoc.Puzzles.Aoc2023.Aoc202323;

[Name("A Long Walk")]
[IsSlow]
public class Aoc202323 : AocPuzzle
{
    private static readonly Dictionary<MatrixDirection, char> ValidSlopes = new()
    {
        { MatrixDirection.Up, '^' },
        { MatrixDirection.Right, '>' },
        { MatrixDirection.Down, 'v' },
        { MatrixDirection.Left, '<' }
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
        var matrix = MatrixBuilder.BuildCharMatrix(s);
        var start = new MatrixAddress(matrix.XMin + 1, matrix.YMin);
        var target = new MatrixAddress(matrix.XMax - 1, matrix.YMax);

        var graphCoords = FindGraphCoords(matrix, start, target).ToList();
        var graph = BuildGraph(matrix, graphCoords, canClimbSlopes);

        return FindLongestRoute(graph, [], start.Id, target.Id);
    }

    private static IEnumerable<MatrixAddress> FindGraphCoords(Matrix<char> matrix, MatrixAddress start, MatrixAddress target)
    {
        yield return start;
        yield return target;

        foreach (var current in matrix.Coords)
        {
            if (matrix.ReadValueAt(current) == '#')
                continue;

            var neighbors = matrix.OrthogonalAdjacentCoordsTo(current)
                .Where(o => matrix.ReadValueAt(o) != '#');
            if (neighbors.Count() > 2)
            {
                yield return current;
            }
        }
    }

    private static Dictionary<string, Dictionary<string, int>> BuildGraph(
        Matrix<char> matrix,
        List<MatrixAddress> graphCoords, 
        bool canClimbSlopes)
    {
        var graph = new Dictionary<string, Dictionary<string, int>>();
        foreach (var startCoord in graphCoords)
        {
            var queue = new Queue<(MatrixAddress, int)>();
            queue.Enqueue((startCoord, 0));
            var seen = new HashSet<MatrixAddress> { startCoord };
            graph.Add(startCoord.Id, new());

            while (queue.Count > 0)
            {
                var (current, distance) = queue.Dequeue();
                if (distance != 0 && graphCoords.Contains(current))
                {
                    graph[startCoord.Id].Add(current.Id, distance);
                    continue;
                }

                var neigbors = GetNeighbors(matrix, current, canClimbSlopes).Where(o => !seen.Contains(o));
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

    private static List<MatrixAddress> GetNeighbors(Matrix<char> matrix, MatrixAddress coord, bool canClimbSlopes)
    {
        var adjacent = new List<MatrixAddress>();
        var north = GetCoord(coord, MatrixDirection.Up);
        var east = GetCoord(coord, MatrixDirection.Right);
        var south = GetCoord(coord, MatrixDirection.Down);
        var west = GetCoord(coord, MatrixDirection.Left);

        if (CanGoDirection(matrix, north, canClimbSlopes, MatrixDirection.Up)) adjacent.Add(north);
        if (CanGoDirection(matrix, east, canClimbSlopes, MatrixDirection.Right)) adjacent.Add(east);
        if (CanGoDirection(matrix, south, canClimbSlopes, MatrixDirection.Down)) adjacent.Add(south);
        if (CanGoDirection(matrix, west, canClimbSlopes, MatrixDirection.Left)) adjacent.Add(west);

        return adjacent;
    }

    private static bool CanGoDirection(Matrix<char> matrix, MatrixAddress coord, bool canClimbSlopes, MatrixDirection direction)
    {
        if (matrix.IsOutOfRange(coord))
            return false;

        var value = matrix.ReadValueAt(coord);
        if (canClimbSlopes && value is not '#')
            return true;

        return value == '.' || value == ValidSlopes[direction];
    }

    private static MatrixAddress GetCoord(MatrixAddress coord, MatrixDirection direction) => 
        new(coord.X + direction.X, coord.Y + direction.Y);
}