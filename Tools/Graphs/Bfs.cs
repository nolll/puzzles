using Pzl.Tools.Grids.Grids2d;
using Pzl.Tools.Strings;

namespace Pzl.Tools.Graphs;

public static class Bfs
{
    public static int BestCost(List<GraphEdge> edges, string from, string to) => BestCost(Graph.GetNeighbors(edges), from, to);
    public static List<string> BestPath(List<GraphEdge> edges, string from, string to) => BestPath(Graph.GetNeighbors(edges), from, to);

    public static int BestCost(Dictionary<string, HashSet<string>> neighbors, string from, string to)
    {
        if (from == to)
            return 0;

        var queue = new Queue<(string, int)>([(from, 0)]);
        var seen = new HashSet<string>([from]);

        while (queue.Count > 0)
        {
            var (current, cost) = queue.Dequeue();
            if (!neighbors.TryGetValue(current, out var next))
                continue;

            foreach (var neighbor in next)
            {
                if (!seen.Add(neighbor))
                    continue;

                if (neighbor == to)
                    return cost + 1;

                queue.Enqueue((neighbor, cost + 1));
            }
        }

        return -1;
    }

    public static Dictionary<string, int> Distances(Dictionary<string, HashSet<string>> neighbors, string from)
    {
        var distances = new Dictionary<string, int> { { from, 0 } };
        var queue = new Queue<string>([from]);

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();
            if (!neighbors.TryGetValue(current, out var next))
                continue;

            var cost = distances[current] + 1;
            foreach (var neighbor in next)
            {
                if (distances.TryAdd(neighbor, cost))
                    queue.Enqueue(neighbor);
            }
        }

        return distances;
    }

    public static List<string> BestPath(Dictionary<string, HashSet<string>> neighbors, string from, string to)
    {
        var queue = new Queue<string>([from]);
        var cameFrom = new Dictionary<string, string?> { { from, null } };

        while (queue.Count > 0 && !cameFrom.ContainsKey(to))
        {
            var current = queue.Dequeue();
            if (!neighbors.TryGetValue(current, out var next))
                continue;

            foreach (var neighbor in next)
            {
                if (cameFrom.TryAdd(neighbor, current))
                    queue.Enqueue(neighbor);
            }
        }

        if (!cameFrom.ContainsKey(to))
            return [];

        var path = new List<string>();
        var curr = to;
        while (curr is not null)
        {
            path.Add(curr);
            curr = cameFrom.GetValueOrDefault(curr);
        }

        return [.. path.Reversed()];
    }
    
    public static List<Coord> BestPath(Dictionary<Coord, HashSet<Coord>> neighbors, Coord from, Coord to)
    {
        var queue = new Queue<Coord>([from]);
        var cameFrom = new Dictionary<Coord, Coord?> { { from, null } };

        while (queue.Count > 0 && !cameFrom.ContainsKey(to))
        {
            var current = queue.Dequeue();
            if (!neighbors.TryGetValue(current, out var next))
                continue;

            foreach (var neighbor in next)
            {
                if (cameFrom.TryAdd(neighbor, current))
                    queue.Enqueue(neighbor);
            }
        }

        if (!cameFrom.ContainsKey(to))
            return [];

        var path = new List<Coord>();
        var curr = to;
        while (curr is not null)
        {
            path.Add(curr);
            curr = cameFrom.GetValueOrDefault(curr);
        }

        return [.. path.Reversed()];
    }
}