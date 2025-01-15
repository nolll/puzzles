using Pzl.Common;
using Pzl.Tools.CoordinateSystems.CoordinateSystem2D;
using Pzl.Tools.Graphs;

namespace Pzl.Everybody.Puzzles.Everybody17;

[Name("Galactic Geometry")]
public class Everybody17 : EverybodyPuzzle
{
    // Thanks to GeeksforGeeks for the algorithm:
    // https://www.geeksforgeeks.org/kruskals-minimum-spanning-tree-algorithm-greedy-algo-2/ 
    
    public PuzzleResult Part1(string input)
    {
        var result = Part1And2(input);
        return new PuzzleResult(result, "97b6801bcd6671e60725568f976b6480");
    }

    public PuzzleResult Part2(string input)
    {
        var result = Part1And2(input);
        return new PuzzleResult(result, "2484ccfa9b3e6b666a7ad01d6204724f");
    }

    private int Part1And2(string input)
    {
        var grid = MatrixBuilder.BuildCharMatrix(input);
        var stars = grid.FindAddresses('*');

        var edges = new List<GraphEdge>();
        foreach (var a in stars)
        {
            foreach (var b in stars)
            {
                if (a.Equals(b))
                    continue;

                var distance = a.ManhattanDistanceTo(b);
                edges.Add(new GraphEdge(a.Id, b.Id, distance));
            }
        }
        
        var spanningTree = Kruskal.MinimumSpanningTree(edges);
        var result = spanningTree + stars.Count;
        
        return result;
    }

    public PuzzleResult Part3(string input)
    {
        return new PuzzleResult(0);
    }
}