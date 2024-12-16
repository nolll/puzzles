namespace Pzl.Tools.Graphs;

public static class Graph
{
    public static int GetLowestCost(List<Input> inputs, string source, string target) => 
        GetLowestCost(inputs, source, [target], 1);

    public static int GetLowestCost(List<Input> inputs, string source, List<string> targets) =>
        GetLowestCost(inputs, source, targets, 1);

    public static int GetHighestCost(List<Input> inputs, string source, string target) =>
        GetLowestCost(inputs, source, [target], -1);
    
    public static int GetHighestCost(List<Input> inputs, string source, List<string> targets) => 
        GetLowestCost(inputs, source, targets, -1);
    
    public static (int cost, List<string> path) GetShortestPath(List<Input> inputs, string source, string target) => 
        GetShortestPath(inputs, source, [target]);

    private static int GetLowestCost(List<Input> inputs, string source, List<string> targets, int costModifier) => 
        GetLowestCost(GetNodes(inputs, source, costModifier), source, targets) * costModifier;

    public static (int cost, List<string> path) GetShortestPath(List<Input> inputs, string source, List<string> targets) => 
        GetShortestPath(GetNodes(inputs, source), source, targets);

    public static (int cost, List<List<string>> path) GetShortestPaths(List<Input> inputs, string source, List<string> targets) => 
        GetShortestPaths(GetNodes(inputs, source), source, targets);

    private static Dictionary<string, Node> GetNodes(List<Input> inputs, string source, int costModifier = 1)
    {
        var nodes = new Dictionary<string, Node>();

        foreach (var input in inputs)
        {
            if (!nodes.TryGetValue(input.From, out var node))
            {
                node = new Node(input.From, new List<Connection>());
                nodes.Add(input.From, node);
            }

            if (input.To != source)
                node.Connections.Add(new Connection(input.To, input.Cost * costModifier));
        }

        return nodes;
    }
    
    private static int GetLowestCost(Dictionary<string, Node> nodes, string source, List<string> targets)
    {
        var start = nodes[source];
        var visited = nodes.Keys.ToDictionary(k => k, _ => int.MaxValue);
        visited[source] = 0;
        var queue = new PriorityQueue<Node, int>();
        queue.Enqueue(start, 0);

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
                queue.Enqueue(nodes[connection.Name], cost);
            }
        }

        return targets.Min(o => visited[o]);
    }
    
    private static (int cost, List<string> path) GetShortestPath(Dictionary<string, Node> nodes, string source, List<string> targets)
    {
        var start = nodes[source];
        var visited = nodes.Keys.ToDictionary(k => k, _ => (cost: int.MaxValue, path: new List<string>()));
        visited[source] = (0, [source]);
        var queue = new PriorityQueue<Node, int>();
        queue.Enqueue(start, 0);

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
                queue.Enqueue(nodes[connection.Name], cost);
            }
        }
        
        return targets.Select(o => visited[o]).MinBy(o => o.cost);
    }
    
    private static (int cost, List<List<string>> path) GetShortestPaths(Dictionary<string, Node> nodes, string source, List<string> targets)
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
    private record Node(string Name, List<Connection> Connections);
    private record Connection(string Name, int Cost);
}