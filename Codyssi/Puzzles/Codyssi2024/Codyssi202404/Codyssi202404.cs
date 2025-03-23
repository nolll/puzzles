using Pzl.Common;
using Pzl.Tools.Graphs;
using Pzl.Tools.HashSets;
using Pzl.Tools.Lists;
using Pzl.Tools.Queues;
using Pzl.Tools.Strings;

namespace Pzl.Codyssi.Puzzles.Codyssi2024.Codyssi202404;

[Name("")]
public class Codyssi202404 : CodyssiPuzzle
{
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
        var lines = input.Split(LineBreaks.Single);
        var set = new HashSet<string>();
        var edges = new List<GraphEdge>();
        foreach (var line in lines)
        {
            var (a, b) = line.Split(" <-> ");
            edges.Add(new GraphEdge(a, b));
            edges.Add(new GraphEdge(b, a));
        }

        var nodes = Graph.GetNodes(edges);

        var queue = new Queue<(string id, int distance)>();
        queue.Enqueue(("STT", 0));
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
        return new PuzzleResult(0);
    }
}