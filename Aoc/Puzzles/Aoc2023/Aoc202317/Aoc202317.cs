using Pzl.Common;
using Pzl.Tools.Graphs;
using Pzl.Tools.Grids.Grids2d;

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
        var matrix = GridBuilder.BuildIntGridFromNonSeparated(s);

        var graph = BuildGraph(matrix, minStraightCount, maxStraightCount);
        var sourceCoord = new Coord(matrix.XMin, matrix.XMin);
        var targetCoord = new Coord(matrix.XMax, matrix.YMax);
        
        List<string> sources =
        [
            // start up and left instead of down and right to avoid special case for first move
            $"{sourceCoord.Id}|{GridDirection.Up}|{minStraightCount}",
            $"{sourceCoord.Id}|{GridDirection.Left}|{minStraightCount}"
        ];

        List<string> targets = [];
        for (var i = minStraightCount; i <= maxStraightCount; i++)
        {
            targets.Add($"{targetCoord.Id}|{GridDirection.Right}|{i}");
            targets.Add($"{targetCoord.Id}|{GridDirection.Down}|{i}");
        }

        var counts = sources.Select(source => Dijkstra.BestCost(graph, source, targets)).ToList();

        return counts.Min();
    }

    private static List<GraphEdge> BuildGraph(Grid<int> grid, int minStraightCount, int maxStraightCount)
    {
        var graph = new List<GraphEdge>();
        foreach (var coord in grid.Coords)
        {
            graph.AddRange(GetDirectionGraph(grid, coord, GridDirection.Up, minStraightCount, maxStraightCount));
            graph.AddRange(GetDirectionGraph(grid, coord, GridDirection.Right, minStraightCount, maxStraightCount));
            graph.AddRange(GetDirectionGraph(grid, coord, GridDirection.Down, minStraightCount, maxStraightCount));
            graph.AddRange(GetDirectionGraph(grid, coord, GridDirection.Left, minStraightCount, maxStraightCount));
        }

        return graph;
    }

    private static List<GraphEdge> GetDirectionGraph(Grid<int> grid, Coord coord, GridDirection forward, int minStraightCount, int maxStraightCount)
    {
        grid.MoveTo(coord);
        grid.TurnTo(forward);
        grid.TurnLeft();
        var left = grid.Direction;
        grid.TurnTo(forward);
        grid.TurnRight();
        var right = grid.Direction;
        grid.TurnTo(forward); 
        var leftCoord = new Coord(coord.X + left.X, coord.Y + left.Y);
        var leftCheckCoord = new Coord(coord.X + left.X * minStraightCount, coord.Y + left.Y * minStraightCount);
        var rightCoord = new Coord(coord.X + right.X, coord.Y + right.Y);
        var rightCheckCoord = new Coord(coord.X + right.X * minStraightCount, coord.Y + right.Y * minStraightCount);
        var forwardCoord = new Coord(coord.X + forward.X, coord.Y + forward.Y);
        var graph = new List<GraphEdge>();

        for (var i = 1; i <= maxStraightCount; i++)
        {
            var fromId = $"{coord.Id}|{forward}|{i}";
            if (i >= minStraightCount && !grid.IsOutOfRange(leftCheckCoord))
                graph.Add(new GraphEdge(fromId, $"{leftCoord.Id}|{left}|1", grid.ReadValueAt(leftCoord)));
            if (i >= minStraightCount && !grid.IsOutOfRange(rightCheckCoord))
                graph.Add(new GraphEdge(fromId, $"{rightCoord.Id}|{right}|1", grid.ReadValueAt(rightCoord)));
            if (i < maxStraightCount && !grid.IsOutOfRange(forwardCoord))
                graph.Add(new GraphEdge(fromId, $"{forwardCoord.Id}|{forward}|{i + 1}", grid.ReadValueAt(forwardCoord)));
        }

        return graph;
    }
}