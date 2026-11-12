using Pzl.Tools.Strings;

namespace Pzl.Tools.Graphs;

public static class Bfs
{
    public static int BestCost(List<GraphEdge> edges, string from, string to) => BestCost(Graph.GetNeighbors(edges), from, to);
    public static List<string> BestPath(List<GraphEdge> edges, string from, string to) => BestPath(Graph.GetNeighbors(edges), from, to);

    public static int BestCost(Dictionary<string, HashSet<string>> neighbors, string from, string to)
    {
        var queue = new Queue<(string, int)>([(from, 0)]);
        var seen = new HashSet<string>([from]);

        while (queue.Count > 0)
        {
            var (current, cost) = queue.Dequeue();
            if (current == to)
                return cost;

            foreach (var neighbor in neighbors.GetValueOrDefault(current, []))
            {
                if (seen.Add(neighbor))
                    queue.Enqueue((neighbor, cost + 1));
            }
        }

        return -1;
    }

    public static List<string> BestPath(Dictionary<string, HashSet<string>> neighbors, string from, string to)
    {
        var queue = new Queue<string>([from]);
        var cameFrom = new Dictionary<string, string?> { { from, null } };

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();
            if (current == to)
                break;

            foreach (var neighbor in neighbors.GetValueOrDefault(current, []))
            {
                if (cameFrom.TryAdd(neighbor, current))
                    queue.Enqueue(neighbor);
            }
        }

        var path = new List<string>();
        var curr = to;
        while (curr is not null)
        {
            path.Add(curr);
            curr = cameFrom.GetValueOrDefault(curr);
        }

        return [.. path.Reversed()];
    }
}