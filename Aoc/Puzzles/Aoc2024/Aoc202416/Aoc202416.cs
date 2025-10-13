using Pzl.Common;
using Pzl.Tools.Graphs;
using Pzl.Tools.Grids.Grids2d;
using Pzl.Tools.Numbers;

namespace Pzl.Aoc.Puzzles.Aoc2024.Aoc202416;

[Name("Reindeer Maze")]
public class Aoc202416 : AocPuzzle
{
    private const char EmptySpace = '.';

    public PuzzleResult Part1(string input)
    {
        var matrix = GridBuilder.BuildCharGrid(input);
        var start = matrix.FindAddresses('S').First();
        var end = matrix.FindAddresses('E').First();
        matrix.WriteValueAt(start, EmptySpace);
        matrix.WriteValueAt(end, EmptySpace);
        matrix.MoveTo(start);
        matrix.TurnTo(GridDirection.Right);

        var inputs = BuildGraph(matrix);
        
        var startKey = $"{GridDirection.Right}|{start.Id}";
        List<string> endKeys = [$"{GridDirection.Right}|{end.Id}", $"{GridDirection.Up}|{end.Id}"];
        var shortestPath = Dijkstra.BestPath(inputs, startKey, endKeys);
        
        return new PuzzleResult(shortestPath.Cost, "7f6e0e55c1b9ba30973eeb8218555c3a");
    }

    public PuzzleResult Part2(string input)
    {
        var matrix = GridBuilder.BuildCharGrid(input, '.');
        var start = matrix.FindAddresses('S').First();
        var end = matrix.FindAddresses('E').First();
        matrix.WriteValueAt(start, EmptySpace);
        matrix.WriteValueAt(end, EmptySpace);
        matrix.MoveTo(start);
        matrix.TurnTo(GridDirection.Right);
        
        var visited = FindVisitedCoords(matrix, start, end);
        
        return new PuzzleResult(visited.Count, "6f785a700e3bd5c59db14bf9f8eb6d46");
    }

    private HashSet<Coord> FindVisitedCoords(Grid<char> grid, Coord start, Coord end)
    {
        var startKey = $"{GridDirection.Right}|{start.Id}";
        List<string> endKeys = [$"{GridDirection.Right}|{end.Id}", $"{GridDirection.Up}|{end.Id}"];
        var inputs = BuildGraph(grid);
        var (_, paths) = Dijkstra.BestPaths(inputs, startKey, endKeys);
        
        var usedCoords = paths
            .SelectMany(o => o)
            .Select(Numbers.IntsFromString)
            .Select(o => new Coord(o[0], o[1]))
            .ToHashSet();

        return usedCoords;
    }

    private List<GraphEdge> BuildGraph(Grid<char> grid)
    {
        var edges = new List<GraphEdge>();

        var spaceCoords = grid.FindAddresses(EmptySpace);
        foreach (var coord in spaceCoords)
        {
            foreach (var dir in GridDirection.All)
            {
                grid.MoveTo(coord);
                grid.TurnTo(dir);

                grid.MoveForward();
                if (grid.ReadValue() == EmptySpace)
                {
                    var fromKey = $"{dir.Name}|{coord.Id}";
                    var toKey = $"{grid.Direction.Name}|{grid.Address.Id}";
                    edges.Add(new GraphEdge(fromKey, toKey));
                }
                grid.MoveBackward();
                
                for (var i = 1; i <= 3; i++)
                {
                    grid.TurnRight();
                    if(i % 2 == 0)
                        continue;
                    
                    var fromKey = $"{dir.Name}|{coord.Id}";
                    var toKey = $"{grid.Direction.Name}|{grid.Address.Id}";
                    edges.Add(new GraphEdge(fromKey, toKey, 1000));
                }
            }
        }

        return edges;
    }
}