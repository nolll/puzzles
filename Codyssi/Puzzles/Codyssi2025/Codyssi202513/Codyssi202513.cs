using Pzl.Common;
using Pzl.Tools.Graphs;
using Pzl.Tools.HashSets;
using Pzl.Tools.Lists;
using Pzl.Tools.Strings;

namespace Pzl.Codyssi.Puzzles.Codyssi2025.Codyssi202513;

[Name("Laestrygonian Guards")]
public class Codyssi202513 : CodyssiPuzzle
{
    public PuzzleResult Part1(string input)
    {
        var p = RunPart1And2(input, 1);
        return new PuzzleResult(p, "4b6f984898442eee284f3fe1ae2050c9");
    }

    public PuzzleResult Part2(string input)
    {
        var p = RunPart1And2(input);
        return new PuzzleResult(p, "04afa91a62dd50ed3b96b0d436d91135");
    }
    
    public PuzzleResult Part3(string input)
    {
        var (edges, _) = Parse(input);
        var nodes = Graph.GetNodes(edges);
        var paths = new List<(string, int)>();
        foreach (var node in nodes.Values) 
            paths.AddRange(FindPaths(nodes, node, node.Name, 0));

        var costs = paths.Select(o => o.Item2).Max();
        
        return new PuzzleResult(costs, "00f6f13fa8e4c7e8a5e7e790d285ab85");
    }

    private IEnumerable<(string, int)> FindPaths(Dictionary<string, GraphNode> nodes, GraphNode node, string used, int cost)
    {
        var paths = new List<(string, int)>();
        foreach (var connection in node.Connections)
        {
            var newUsed = $"{used},{connection.Name}";
            var newCost = cost + connection.Cost;
            if (used.StartsWith(connection.Name))
                paths.Add((newUsed, newCost));
            else if (!used.Contains(connection.Name)) 
                paths.AddRange(FindPaths(nodes, nodes[connection.Name], newUsed, newCost));
        }

        return paths;
    }

    private int RunPart1And2(string input, int? customPathLength = null)
    {
        var (edges, targets) = Parse(input, customPathLength);
        var costs = targets.Select(o => Dijkstra.BestCost(edges, "STT", o)).OrderDescending();
        var top3 = costs.Take(3);
        return top3.Aggregate(1, (current, c) => current * c);
    }

    private (List<GraphEdge> edges, HashSet<string> targets) Parse(string input, int? customPathLength = null)
    {
        var lines = input.Split(LineBreaks.Single);
        var edges = new List<GraphEdge>();
        var targets = new HashSet<string>();
        foreach (var line in lines)
        {
            var (from, _, to, _, pl) = line.Split(' ');
            var pathLength = customPathLength ?? int.Parse(pl);
            edges.Add(new GraphEdge(from, to, pathLength));
            targets.AddRange([from, to]);
        }

        return (edges, targets);
    }
}