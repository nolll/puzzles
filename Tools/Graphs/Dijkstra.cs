namespace Pzl.Tools.Graphs;

public static class Dijkstra
{
    public static int BestCost(List<GraphEdge> edges, string source, string target) => 
        BestCost(edges, source, [target]);
    
    public static int BestCost(List<GraphEdge> edges, string source, List<string> targets) => 
        BestCost(Graph.GetNodes(edges), source, targets);

    public static List<string> BestPath(IEnumerable<GraphEdge> edges, string source, string target) => 
        BestPath(edges, source, [target]);

    public static List<string> BestPath(IEnumerable<GraphEdge> edges, string source, List<string> targets) => 
        BestPath(Graph.GetNodes(edges), source, targets);

    public static List<List<string>> BestPaths(List<GraphEdge> edges, string source, List<string> targets) => 
        BestPaths(Graph.GetNodes(edges), source, targets).paths;

    public static int BestCost(Dictionary<string, GraphNode> nodes, string source, string target) =>
        BestCost(nodes, source, [target]);

    private static int BestCost(Dictionary<string, GraphNode> nodes, string source, List<string> targets)
    {
        var (costs, _) = Search(nodes, source);
        return targets.Min(o => costs[o]);
    }

    private static List<string> BestPath(Dictionary<string, GraphNode> nodes, string source, List<string> targets)
    {
        var (costs, parents) = Search(nodes, source);
        var best = targets.MinBy(o => costs[o]);
        if (best is null || costs[best] == int.MaxValue)
            return [];

        var path = new List<string>();
        for (var name = best; name != source; name = parents[name])
            path.Add(name);
        path.Add(source);
        path.Reverse();

        return path;
    }

    private static (Dictionary<string, int> costs, Dictionary<string, string> parents) Search(Dictionary<string, GraphNode> nodes, string source)
    {
        var costs = nodes.Keys.ToDictionary(k => k, _ => int.MaxValue);
        costs[source] = 0;
        var parents = new Dictionary<string, string>();
        var queue = new PriorityQueue<GraphNode, int>();
        queue.Enqueue(nodes[source], 0);

        while (queue.TryDequeue(out var node, out var priority))
        {
            if (priority > costs[node.Name])
                continue;

            var steps = costs[node.Name];
            foreach (var connection in node.Connections)
            {
                if (!costs.TryGetValue(connection.Name, out var visitedConnection))
                    continue;

                var cost = steps + connection.Cost;
                if (cost >= visitedConnection) 
                    continue;

                costs[connection.Name] = cost;
                parents[connection.Name] = node.Name;
                queue.Enqueue(nodes[connection.Name], cost);
            }
        }

        return (costs, parents);
    }
    
    private static (int cost, List<List<string>> paths) BestPaths(Dictionary<string, GraphNode> nodes, string source, List<string> targets)
    {
        var start = nodes[source];
        var visited = nodes.Keys.ToDictionary(k => k, _ => (cost: int.MaxValue, paths: new List<List<string>>()));
        visited[source] = (0, [[source]]);
        var queue = new PriorityQueue<GraphNode, int>();
        queue.Enqueue(start, 0);

        while (queue.Count > 0)
        {
            var node = queue.Dequeue();
            var (steps, paths) = visited[node.Name];
            foreach (var connection in node.Connections)
            {
                if (!visited.TryGetValue(connection.Name, out var visitedConnection))
                    continue;

                var cost = steps + connection.Cost;
                if (cost > visitedConnection.cost) 
                    continue;

                var newPaths = cost == visitedConnection.cost
                    ? visitedConnection.paths.ToList()
                    : [];
                
                newPaths.AddRange(paths.Select(path => (List<string>) [..path, connection.Name]));
                visited[connection.Name] = (cost, newPaths);
                if(cost < visitedConnection.cost)
                    queue.Enqueue(nodes[connection.Name], cost);
            }
        }
        
        return targets.Select(o => visited[o]).MinBy(o => o.cost);
    }
}