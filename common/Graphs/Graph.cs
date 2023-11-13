namespace Puzzles.common.Graphs;

public static class Graph
{
    public static int GetLowestCost(List<Input> inputs, string source, string target)
        => GetLowestCost(inputs, source, target, 1);

    public static int GetHighestCost(List<Input> inputs, string source, string target)
        => GetLowestCost(inputs, source, target, -1);

    private static int GetLowestCost(List<Input> inputs, string source, string target, int costModifier)
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

        return GetLowestCost(nodes, source, target) * costModifier;
    }
    
    private static int GetLowestCost(Dictionary<string, Node> nodes, string source, string target)
    {
        var start = nodes[source];
        var visited = nodes.Keys.ToDictionary(k => k, _ => int.MaxValue);
        visited[source] = 0;
        var queue = new Queue<Node>(new List<Node> { start });

        while (queue.Any())
        {
            var node = queue.Dequeue();
            var steps = visited[node.Name];
            foreach (var connection in node.Connections)
            {
                var visitedConnection = visited[connection.Name];
                var cost = steps + connection.Cost;
                if (cost >= visitedConnection) 
                    continue;
                visited[connection.Name] = cost;
                queue.Enqueue(nodes[connection.Name]);
            }
        }

        return visited[target];
    }

    public record Input(string From, string To, int Cost = 1);
    private record Node(string Name, List<Connection> Connections);
    private record Connection(string Name, int Cost);
}