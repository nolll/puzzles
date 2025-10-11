using Pzl.Common;
using Pzl.Tools.CoordinateSystems.CoordinateSystem2D;
using Pzl.Tools.Graphs;
using Pzl.Tools.Numbers;

namespace Pzl.Aoc.Puzzles.Aoc2024.Aoc202416;

[Name("Reindeer Maze")]
public class Aoc202416 : AocPuzzle
{
    private const char EmptySpace = '.';

    public PuzzleResult Part1(string input)
    {
        var matrix = MatrixBuilder.BuildCharMatrix(input);
        var start = matrix.FindAddresses('S').First();
        var end = matrix.FindAddresses('E').First();
        matrix.WriteValueAt(start, EmptySpace);
        matrix.WriteValueAt(end, EmptySpace);
        matrix.MoveTo(start);
        matrix.TurnTo(MatrixDirection.Right);

        var inputs = BuildGraph(matrix);
        
        var startKey = $"{MatrixDirection.Right}|{start.Id}";
        List<string> endKeys = [$"{MatrixDirection.Right}|{end.Id}", $"{MatrixDirection.Up}|{end.Id}"];
        var shortestPath = Dijkstra.BestPath(inputs, startKey, endKeys);
        
        return new PuzzleResult(shortestPath.Cost, "7f6e0e55c1b9ba30973eeb8218555c3a");
    }

    public PuzzleResult Part2(string input)
    {
        var matrix = MatrixBuilder.BuildCharMatrix(input, '.');
        var start = matrix.FindAddresses('S').First();
        var end = matrix.FindAddresses('E').First();
        matrix.WriteValueAt(start, EmptySpace);
        matrix.WriteValueAt(end, EmptySpace);
        matrix.MoveTo(start);
        matrix.TurnTo(MatrixDirection.Right);
        
        var visited = FindVisitedCoords(matrix, start, end);
        
        return new PuzzleResult(visited.Count, "6f785a700e3bd5c59db14bf9f8eb6d46");
    }

    private HashSet<MatrixAddress> FindVisitedCoords(Matrix<char> matrix, MatrixAddress start, MatrixAddress end)
    {
        var startKey = $"{MatrixDirection.Right}|{start.Id}";
        List<string> endKeys = [$"{MatrixDirection.Right}|{end.Id}", $"{MatrixDirection.Up}|{end.Id}"];
        var inputs = BuildGraph(matrix);
        var (_, paths) = Dijkstra.BestPaths(inputs, startKey, endKeys);
        
        var usedCoords = paths
            .SelectMany(o => o)
            .Select(Numbers.IntsFromString)
            .Select(o => new MatrixAddress(o[0], o[1]))
            .ToHashSet();

        return usedCoords;
    }

    private List<GraphEdge> BuildGraph(Matrix<char> matrix)
    {
        var edges = new List<GraphEdge>();

        var spaceCoords = matrix.FindAddresses(EmptySpace);
        foreach (var coord in spaceCoords)
        {
            foreach (var dir in MatrixDirection.All)
            {
                matrix.MoveTo(coord);
                matrix.TurnTo(dir);

                matrix.MoveForward();
                if (matrix.ReadValue() == EmptySpace)
                {
                    var fromKey = $"{dir.Name}|{coord.Id}";
                    var toKey = $"{matrix.Direction.Name}|{matrix.Address.Id}";
                    edges.Add(new GraphEdge(fromKey, toKey));
                }
                matrix.MoveBackward();
                
                for (var i = 1; i <= 3; i++)
                {
                    matrix.TurnRight();
                    if(i % 2 == 0)
                        continue;
                    
                    var fromKey = $"{dir.Name}|{coord.Id}";
                    var toKey = $"{matrix.Direction.Name}|{matrix.Address.Id}";
                    edges.Add(new GraphEdge(fromKey, toKey, 1000));
                }
            }
        }

        return edges;
    }
}