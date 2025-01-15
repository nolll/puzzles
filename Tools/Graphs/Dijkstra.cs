namespace Pzl.Tools.Graphs;

public static class Graph
{
    public static Dictionary<string, GraphNode> GetNodes(IEnumerable<GraphEdge> edges)
    {
        var nodes = new Dictionary<string, GraphNode>();

        foreach (var edge in edges)
        {
            if (!nodes.TryGetValue(edge.From, out var fromNode))
            {
                fromNode = new GraphNode(edge.From, []);
                nodes.Add(edge.From, fromNode);
            }
            
            if(!nodes.ContainsKey(edge.To))
                nodes.Add(edge.To, new GraphNode(edge.To, []));
            
            fromNode.Connections.Add(new GraphConnection(edge.To, edge.Cost));
        }

        return nodes;
    }
}

public static class Dijkstra
{
    public static int Cost(List<GraphEdge> edges, string source, string target) => 
        Cost(edges, source, [target]);
    
    public static int Cost(List<GraphEdge> edges, string source, List<string> targets) => 
        Path(Graph.GetNodes(edges), source, targets).cost;

    public static (int cost, List<string> path) Path(List<GraphEdge> edges, string source, string target) => 
        Path(edges, source, [target]);

    public static (int cost, List<string> path) Path(List<GraphEdge> edges, string source, List<string> targets) => 
        Path(Graph.GetNodes(edges), source, targets);

    public static (int cost, List<List<string>> paths) Paths(List<GraphEdge> edges, string source, List<string> targets) => 
        Paths(Graph.GetNodes(edges), source, targets);

    public static int Cost(Dictionary<string, GraphNode> nodes, string source, string target) =>
        Cost(nodes, source, [target]);
    
    public static int Cost(Dictionary<string, GraphNode> nodes, string source, List<string> targets)
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
    
    private static (int cost, List<string> path) Path(Dictionary<string, GraphNode> nodes, string source, List<string> targets)
    {
        var start = nodes[source];
        var visited = nodes.Keys.ToDictionary(k => k, _ => (cost: int.MaxValue, path: new List<string>()));
        visited[source] = (0, [source]);
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
                if (cost >= visitedConnection.cost) 
                    continue;

                visited[connection.Name] = (cost, [..path, connection.Name]);
                queue.Enqueue(nodes[connection.Name]);
            }
        }
        
        return targets.Select(o => visited[o]).MinBy(o => o.cost);
    }
    
    private static (int cost, List<List<string>> paths) Paths(Dictionary<string, GraphNode> nodes, string source, List<string> targets)
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
}