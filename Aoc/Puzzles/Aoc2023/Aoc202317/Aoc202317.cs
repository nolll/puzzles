using Pzl.Common;
using Pzl.Tools.CoordinateSystems.CoordinateSystem2D;
using Pzl.Tools.Graphs;

namespace Pzl.Aoc.Puzzles.Aoc2023.Aoc202317;

[Name("Clumsy Crucible")]
public class Aoc202317 : AocPuzzle
{
    public PuzzleResult RunPart1(string input)
    {
        var result = LeastHeatPart1(input);

        return new PuzzleResult(result, "cf7fd7c685bf666303ab74ad1d2252e2");
    }

    public PuzzleResult RunPart2(string input)
    {
        var result = LeastHeatPart2(input);

        return new PuzzleResult(result, "fe2a6d3aee0dee95dae6c0880d11d812");
    }

    public static int LeastHeatPart1(string s) => LeastHeat(s, 1, 3);
    public static int LeastHeatPart2(string s) => LeastHeat(s, 4, 10);

    private static int LeastHeat(string s, int minStraightCount, int maxStraightCount)
    {
        var matrix = MatrixBuilder.BuildIntMatrixFromNonSeparated(s);

        var graph = BuildGraph(matrix, minStraightCount, maxStraightCount);
        var sourceCoord = new MatrixAddress(matrix.XMin, matrix.XMin);
        var targetCoord = new MatrixAddress(matrix.XMax, matrix.YMax);
        
        List<string> sources =
        [
            // start up and left instead of down and right to avoid special case for first move
            $"{sourceCoord.Id}|{MatrixDirection.Up}|{minStraightCount}",
            $"{sourceCoord.Id}|{MatrixDirection.Left}|{minStraightCount}"
        ];

        List<string> targets = [];
        for (var i = minStraightCount; i <= maxStraightCount; i++)
        {
            targets.Add($"{targetCoord.Id}|{MatrixDirection.Right}|{i}");
            targets.Add($"{targetCoord.Id}|{MatrixDirection.Down}|{i}");
        }

        var counts = sources.Select(source => Dijkstra.Cost(graph, source, targets)).ToList();

        return counts.Min();
    }

    private static List<GraphEdge> BuildGraph(Matrix<int> matrix, int minStraightCount, int maxStraightCount)
    {
        var graph = new List<GraphEdge>();
        foreach (var coord in matrix.Coords)
        {
            graph.AddRange(GetDirectionGraph(matrix, coord, MatrixDirection.Up, minStraightCount, maxStraightCount));
            graph.AddRange(GetDirectionGraph(matrix, coord, MatrixDirection.Right, minStraightCount, maxStraightCount));
            graph.AddRange(GetDirectionGraph(matrix, coord, MatrixDirection.Down, minStraightCount, maxStraightCount));
            graph.AddRange(GetDirectionGraph(matrix, coord, MatrixDirection.Left, minStraightCount, maxStraightCount));
        }

        return graph;
    }

    private static List<GraphEdge> GetDirectionGraph(Matrix<int> matrix, MatrixAddress coord, MatrixDirection forward, int minStraightCount, int maxStraightCount)
    {
        matrix.MoveTo(coord);
        matrix.TurnTo(forward);
        matrix.TurnLeft();
        var left = matrix.Direction;
        matrix.TurnTo(forward);
        matrix.TurnRight();
        var right = matrix.Direction;
        matrix.TurnTo(forward); 
        var leftCoord = new MatrixAddress(coord.X + left.X, coord.Y + left.Y);
        var leftCheckCoord = new MatrixAddress(coord.X + left.X * minStraightCount, coord.Y + left.Y * minStraightCount);
        var rightCoord = new MatrixAddress(coord.X + right.X, coord.Y + right.Y);
        var rightCheckCoord = new MatrixAddress(coord.X + right.X * minStraightCount, coord.Y + right.Y * minStraightCount);
        var forwardCoord = new MatrixAddress(coord.X + forward.X, coord.Y + forward.Y);
        var graph = new List<GraphEdge>();

        for (var i = 1; i <= maxStraightCount; i++)
        {
            var fromId = $"{coord.Id}|{forward}|{i}";
            if (i >= minStraightCount && !matrix.IsOutOfRange(leftCheckCoord))
                graph.Add(new GraphEdge(fromId, $"{leftCoord.Id}|{left}|1", matrix.ReadValueAt(leftCoord)));
            if (i >= minStraightCount && !matrix.IsOutOfRange(rightCheckCoord))
                graph.Add(new GraphEdge(fromId, $"{rightCoord.Id}|{right}|1", matrix.ReadValueAt(rightCoord)));
            if (i < maxStraightCount && !matrix.IsOutOfRange(forwardCoord))
                graph.Add(new GraphEdge(fromId, $"{forwardCoord.Id}|{forward}|{i + 1}", matrix.ReadValueAt(forwardCoord)));
        }

        return graph;
    }
}