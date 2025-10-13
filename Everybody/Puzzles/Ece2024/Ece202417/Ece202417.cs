using Pzl.Common;
using Pzl.Tools.Graphs;
using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Everybody.Puzzles.Ece2024.Ece202417;

// Thanks to GeeksforGeeks for the algorithm:
// https://www.geeksforgeeks.org/kruskals-minimum-spanning-tree-algorithm-greedy-algo-2/ 
[Name("Galactic Geometry")]
public class Ece202417 : EverybodyEventPuzzle
{
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
    
    public PuzzleResult Part3(string input)
    {
        var stars = FindStars(input);
        var edges = GetEdges(stars).Where(o => o.Cost < 6);
        var nodes = Graph.GetNodes(edges);
        var components = Graph.GetConnectedComponents(nodes);
        var starGroups = components.Select(o => o.Keys.Select(MatrixAddress.Parse).ToList());
        var result = starGroups.Select(GetSize).OrderDescending().Take(3).Aggregate((long)1, (a, b) => a * b);
        
        return new PuzzleResult(result, "7906b8b4e0147d5e4d4c422a2042a3d8");
    }
    
    private static long Part1And2(string input) => GetSize(FindStars(input));

    private static IList<MatrixAddress> FindStars(string input) => 
        MatrixBuilder.BuildCharMatrix(input).FindAddresses('*');

    private static long GetSize(IList<MatrixAddress> stars) => 
        Kruskal.MinimumSpanningTree(GetEdges(stars).ToList()) + stars.Count;

    private static IEnumerable<GraphEdge> GetEdges(IList<MatrixAddress> stars)
    {
        foreach (var a in stars)
        {
            foreach (var b in stars)
            {
                if (a.Equals(b))
                    continue;

                var distance = a.ManhattanDistanceTo(b);
                yield return new GraphEdge(a.Id, b.Id, distance);
            }
        }
    }
}