using Pzl.Common;
using Pzl.Tools.Graphs;
using Pzl.Tools.HashSets;
using Pzl.Tools.Lists;
using Pzl.Tools.Strings;

namespace Pzl.Codyssi.Puzzles.Codyssi2024.Codyssi202404;

[Name("Traversing the Country")]
public class Codyssi202404 : CodyssiPuzzle
{
    private const string StartLocation = "STT";

    public PuzzleResult Part1(string input)
    {
        var lines = input.Split(LineBreaks.Single);
        var set = new HashSet<string>();
        foreach (var line in lines)
        {
            set.AddRange(line.Split(" <-> "));
        }
        return new PuzzleResult(set.Count, "48687e590201772c8544f0344efbceda");
    }

    public PuzzleResult Part2(string input)
    {
        var set = new HashSet<string>();
        var edges = BuildGraph(input);
        var nodes = Graph.GetNodes(edges);

        var queue = new Queue<(string id, int distance)>();
        queue.Enqueue((StartLocation, 0));
        while(queue.Count > 0)
        {
            var item = queue.Dequeue();
            if (item.distance > 3)
                continue;
            set.Add(item.id);
            var node = nodes[item.id];
            foreach (var connection in node.Connections)
            {
                queue.Enqueue((connection.Name, item.distance + 1));
            }
        }
        
        return new PuzzleResult(set.Count, "c14e646bf6a935788f1de3ed40cdbf6b");
    }
    
    public PuzzleResult Part3(string input)
    {
        var edges = BuildGraph(input).ToList();
        var nodes = Graph.GetNodes(edges);
        var total = nodes.Keys.Sum(name => Dijkstra.BestCost(edges, StartLocation, name));

        return new PuzzleResult(total, "ef1be406fe88e18c982f118992d26f58");
    }

    private static IEnumerable<GraphEdge> BuildGraph(string input)
    {
        var lines = input.Split(LineBreaks.Single);
        foreach (var line in lines)
        {
            var (a, b) = line.Split(" <-> ");
            yield return new GraphEdge(a, b);
            yield return new GraphEdge(b, a);
        }
    }
}