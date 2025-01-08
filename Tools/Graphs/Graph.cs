namespace Pzl.Tools.Graphs;

public static class Graph
{
    public static int GetLowestCost(List<Input> inputs, string source, string target) => 
        GetLowestCost(inputs, source, [target]);
    
    public static int GetLowestCost(List<Input> inputs, string source, List<string> targets) => 
        GetLowestCost(GetNodes(inputs), source, targets);

    public static (int cost, List<string> path) GetShortestPath(List<Input> inputs, string source, string target) => 
        GetShortestPath(inputs, source, [target]);

    public static (int cost, List<string> path) GetShortestPath(List<Input> inputs, string source, List<string> targets) => 
        GetShortestPath(GetNodes(inputs), source, targets);

    public static (int cost, List<List<string>> paths) GetShortestPaths(List<Input> inputs, string source, List<string> targets) => 
        GetShortestPaths(GetNodes(inputs), source, targets);

    public static Dictionary<string, Node> GetNodes(List<Input> inputs)
    {
        var nodes = new Dictionary<string, Node>();

        foreach (var input in inputs)
        {
            if (!nodes.TryGetValue(input.From, out var fromNode))
            {
                fromNode = new Node(input.From, []);
                nodes.Add(input.From, fromNode);
            }
            
            if(!nodes.ContainsKey(input.To))
                nodes.Add(input.To, new Node(input.To, []));
            
            fromNode.Connections.Add(new Connection(input.To, input.Cost));
        }

        return nodes;
    }
    
    public static int GetLowestCost(Dictionary<string, Node> nodes, string source, List<string> targets)
    {
        var start = nodes[source];
        var visited = nodes.Keys.ToDictionary(k => k, _ => int.MaxValue);
        visited[source] = 0;
        var queue = new Queue<Node>();
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
    
    private static (int cost, List<string> path) GetShortestPath(Dictionary<string, Node> nodes, string source, List<string> targets)
    {
        var start = nodes[source];
        var visited = nodes.Keys.ToDictionary(k => k, _ => (cost: int.MaxValue, path: new List<string>()));
        visited[source] = (0, [source]);
        var queue = new Queue<Node>();
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
    
    private static (int cost, List<List<string>> paths) GetShortestPaths(Dictionary<string, Node> nodes, string source, List<string> targets)
    {
        var start = nodes[source];
        var visited = nodes.Keys.ToDictionary(k => k, _ => (cost: int.MaxValue, paths: new List<List<string>>()));
        visited[source] = (0, [new List<string>{source}]);
        var queue = new PriorityQueue<Node, int>();
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

    public record Input(string From, string To, int Cost = 1);
    public record Node(string Name, List<Connection> Connections);
    public record Connection(string Name, int Cost);
}