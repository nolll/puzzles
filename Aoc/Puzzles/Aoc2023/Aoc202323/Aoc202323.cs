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

            var north = GetCoord(current, MatrixDirection.Up);
            var east = GetCoord(current, MatrixDirection.Right);
            var south = GetCoord(current, MatrixDirection.Down);
            var west = GetCoord(current, MatrixDirection.Left);

            if (!matrix.IsOutOfRange(north) && matrix.ReadValueAt(north) is '.' or '^')
            {
                graph.Add(new Graph.Input(current.Id, north.Id, -1));
                queue.Enqueue(north);
            }

            if (!matrix.IsOutOfRange(east) && matrix.ReadValueAt(east) is '.' or '>')
            {
                graph.Add(new Graph.Input(current.Id, east.Id, -1));
                queue.Enqueue(east);
            }

            if (!matrix.IsOutOfRange(south) && matrix.ReadValueAt(south) is '.' or 'v')
            {
                graph.Add(new Graph.Input(current.Id, south.Id, -1));
                queue.Enqueue(south);
            }

            if (!matrix.IsOutOfRange(west) && matrix.ReadValueAt(west) is '.' or '<')
            {
                graph.Add(new Graph.Input(current.Id, west.Id, -1));
                queue.Enqueue(west);
            }
        }

        graph.Add(new Graph.Input(target.Id, start.Id, 0));

        var result = -Graph.GetLowestCost(graph, start.Id, target.Id);

        return result;
    }

    private static MatrixAddress GetCoord(MatrixAddress coord, MatrixDirection direction) => 
        new(coord.X + direction.X, coord.Y + direction.Y);
}