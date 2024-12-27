using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2023.Aoc202325;

[Name("Snowverload")]
public class Aoc202325 : AocPuzzle
{
    // Thanks to HyperNeutrino again
    public PuzzleResult Part1(string input)
    {
        var components = ParseComponents(input);

        var edges = new Dictionary<(string, string), int>();
        
        foreach (var start in components.Keys.ToList())
        {
            var queue = new Queue<string>();
            queue.Enqueue(start);
            var seen = new HashSet<string>();
            seen.Add(start);
            var prev = new Dictionary<string, string>();

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                foreach (var next in components[node])
                {
                    if (!seen.Add(next)) 
                        continue;

                    queue.Enqueue(next);
                    prev[next] = node;
                }
            }

            foreach (var node in components.Keys.ToList())
            {
                var cnode = node;
                while (cnode != start)
                {
                    var next = prev[cnode];
                    var edge = string.Compare(next, cnode, StringComparison.Ordinal) < 0
                        ? (next, cnode)
                        : (cnode, next);
                    edges.TryAdd(edge, 0);
                    edges[edge] += 1;
                    cnode = next;
                }
            }
        }

        var edgesToRemove = edges.OrderByDescending(o => o.Value)
            .Select(o => o.Key).Take(3);
        
        foreach (var pair in edgesToRemove)
        {
            components[pair.Item1].Remove(pair.Item2);
            components[pair.Item2].Remove(pair.Item1);
        }

        var first = components.Keys.First();
        var q = new Queue<string>();
        q.Enqueue(first);
        var group = new HashSet<string>();
        group.Add(first);
        while (q.Count > 0)
        {
            var node = q.Dequeue();
            foreach (var other in components[node])
            {
                if (!group.Add(other)) 
                    continue;

                q.Enqueue(other);
            }
        }

        var a = group.Count;
        var b = components.Count - a;
        var result = a * b;

        return new PuzzleResult(result, "fe62765fd563deae239d0e76689b31d7");
    }

    private static Dictionary<string, List<string>> ParseComponents(string s)
    {
        var lines = StringReader.ReadLines(s);
        var components = new Dictionary<string, List<string>>();

        foreach (var line in lines)
        {
            var parts = line.Split(": ");
            var compName = parts[0];
            if (!components.ContainsKey(compName))
            {
                components.Add(compName, []);
            }

            var connectedNames = parts[1].Split(' ');
            foreach (var connectedName in connectedNames)
            {
                if (!components.ContainsKey(connectedName))
                {
                    components.Add(connectedName, []);
                }

                components[connectedName].Add(compName);
                components[compName].Add(connectedName);
            }
        }

        return components;
    }
}