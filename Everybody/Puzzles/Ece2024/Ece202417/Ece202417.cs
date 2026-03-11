using Pzl.Common;
using Pzl.Tools.Graphs;
using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Everybody.Puzzles.Ece2024.Ece202417;

// Thanks to GeeksforGeeks for the algorithm:
// https://www.geeksforgeeks.org/kruskals-minimum-spanning-tree-algorithm-greedy-algo-2/ 
[Name("Galactic Geometry")]
public class Ece202417 : EverybodyEventPuzzle
{
    [Puzzle("97b6801bcd6671e60725568f976b6480")]
    public long Part1(string input) => Part1And2(input);
    
    [Puzzle("2484ccfa9b3e6b666a7ad01d6204724f")]
    public long Part2(string input) => Part1And2(input);

    [Puzzle("7906b8b4e0147d5e4d4c422a2042a3d8")]
    public long Part3(string input)
    {
        var stars = FindStars(input);
        var edges = GetEdges(stars).Where(o => o.Cost < 6);
        var nodes = Graph.GetNodes(edges);
        var components = Graph.GetConnectedComponents(nodes);
        var starGroups = components.Select(o => o.Keys.Select(Coord.Parse).ToList());
        var result = starGroups.Select(GetSize).OrderDescending().Take(3).Aggregate((long)1, (a, b) => a * b);
        
        return result;
    }
    
    private static long Part1And2(string input) => GetSize(FindStars(input));

    private static IList<Coord> FindStars(string input) => 
        GridBuilder.BuildCharGrid(input).FindAddresses('*');

    private static long GetSize(IList<Coord> stars) => 
        Kruskal.MinimumSpanningTree(GetEdges(stars).ToList()) + stars.Count;

    private static IEnumerable<GraphEdge> GetEdges(IList<Coord> stars)
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