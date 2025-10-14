namespace Pzl.Tools.Graphs;

public static class Dijkstra
{
    public static int BestCost(List<GraphEdge> edges, string source, string target) => 
        BestCost(edges, source, [target]);
    
    public static int BestCost(List<GraphEdge> edges, string source, List<string> targets) => 
        BestCost(Graph.GetNodes(edges), source, targets);

    public static Result BestPath(IEnumerable<GraphEdge> edges, string source, string target) => 
        BestPath(edges, source, [target]);

    public static Result BestPath(IEnumerable<GraphEdge> edges, string source, List<string> targets) => 
        BestPath(Graph.GetNodes(edges), source, targets);

    public static (int cost, List<List<string>> paths) BestPaths(List<GraphEdge> edges, string source, List<string> targets) => 
        BestPaths(Graph.GetNodes(edges), source, targets);

    public static int BestCost(Dictionary<string, GraphNode> nodes, string source, string target) =>
        BestCost(nodes, source, [target]);

    private static int BestCost(Dictionary<string, GraphNode> nodes, string source, List<string> targets)
    {
        var start = nodes[source];
        var visited = nodes.Keys.ToDictionary(k => k, _ => int.MaxValue);
        visited[source] = 0;
        var queue = new Queue<GraphNode>();
        queue.Enqueue(start);

        while (queue.Count > 0)
        {
            var node = queue.Dequeue();
            var steps = visited[node.Name];
            foreach (var connection in node.Connections)
            {
                if (!visited.TryGetValue(connection.Name, out var visitedConnection))
                    continue;

                var cost = steps + connection.Cost;
                if (cost >= visitedConnection) 
                    continue;

                visited[connection.Name] = cost;
                queue.Enqueue(nodes[connection.Name]);
            }
        }

        return targets.Min(o => visited[o]);
    }
    
    private static Result BestPath(Dictionary<string, GraphNode> nodes, string source, List<string> targets)
    {
        var start = nodes[source];
        var visited = nodes.Keys.ToDictionary(k => k, _ => new Result(int.MaxValue, []));
        visited[source] = new Result(0, [source]);
        var queue = new Queue<GraphNode>();
        queue.Enqueue(start);

        while (queue.Count > 0)
        {
            var node = queue.Dequeue();
            var (steps, path) = visited[node.Name];
            foreach (var connection in node.Connections)
            {
                if (!visited.TryGetValue(connection.Name, out var visitedConnection))
                    continue;

                var cost = steps + connection.Cost;
                if (cost >= visitedConnection.Cost) 
                    continue;

                visited[connection.Name] = new Result(cost, [..path, connection.Name]);
                queue.Enqueue(nodes[connection.Name]);
            }
        }
        
        return targets.Select(o => visited[o]).MinBy(o => o.Cost) ?? new Result(0, []);
    }
    
    private static (int cost, List<List<string>> paths) BestPaths(Dictionary<string, GraphNode> nodes, string source, List<string> targets)
    {
        var start = nodes[source];
        var visited = nodes.Keys.ToDictionary(k => k, _ => (cost: int.MaxValue, paths: new List<List<string>>()));
        visited[source] = (0, [new List<string>{source}]);
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

    public record Result(int Cost, List<string> Path);
}