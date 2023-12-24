using System.Diagnostics.CodeAnalysis;
using Pzl.Common;
using Pzl.Tools.CoordinateSystems.CoordinateSystem2D;
using Pzl.Tools.Graphs;

namespace Pzl.Aoc.Puzzles.Aoc2023.Aoc202323;

[Name("A Long Walk")]
public class Aoc202323(string input) : AocPuzzle
{
    protected override PuzzleResult RunPart1()
    {
        return PuzzleResult.Empty;
    }

    protected override PuzzleResult RunPart2()
    {
        return PuzzleResult.Empty;
    }

    public static int LongestHike(string s)
    {
        var matrix = MatrixBuilder.BuildCharMatrix(s);
        var start = new MatrixAddress(matrix.XMin + 1, matrix.YMin);
        var target = new MatrixAddress(matrix.XMax - 1, matrix.YMax);

        var queue = new Queue<MatrixAddress>();
        queue.Enqueue(start);
        var seen = new HashSet<MatrixAddress>();
        var graph = new List<Graph.Input>();

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();
            seen.Add(current);

            var neighbors = GetNeighbors(matrix, current).Where(o => !seen.Contains(o));
            var inputs = neighbors.Select(o => new Graph.Input(current.Id, o.Id, -1));
            graph.AddRange(inputs);
        }

        graph.Add(new Graph.Input(target.Id, start.Id, 0));

        var result = -Graph.GetLowestCost(graph, start.Id, target.Id);
        //var result2 = PathFinder.LongestPathTo(matrix, start, target, GetNeighbors);

        return result;
    }

    private static List<MatrixAddress> GetNeighbors(Matrix<char> matrix, MatrixAddress coord)
    {
        var adjacent = new List<MatrixAddress>();
        var north = GetCoord(coord, MatrixDirection.Up);
        var east = GetCoord(coord, MatrixDirection.Right);
        var south = GetCoord(coord, MatrixDirection.Down);
        var west = GetCoord(coord, MatrixDirection.Left);

        if (!matrix.IsOutOfRange(north) && matrix.ReadValueAt(north) is '.' or '^')
        {
            adjacent.Add(north);
        }

        if (!matrix.IsOutOfRange(east) && matrix.ReadValueAt(east) is '.' or '>')
        {
            adjacent.Add(east);
        }

        if (!matrix.IsOutOfRange(south) && matrix.ReadValueAt(south) is '.' or 'v')
        {
            adjacent.Add(south);
        }

        if (!matrix.IsOutOfRange(west) && matrix.ReadValueAt(west) is '.' or '<')
        {
            adjacent.Add(west);
        }

        return adjacent;
    }

    private static MatrixAddress GetCoord(MatrixAddress coord, MatrixDirection direction) => 
        new(coord.X + direction.X, coord.Y + direction.Y);
}