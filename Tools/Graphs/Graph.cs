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

    public static List<Dictionary<string, GraphNode>> GetConnectedComponents(Dictionary<string, GraphNode> nodes)
    {
        var nodesLeft = nodes.Keys.ToHashSet();
        var groups = new List<Dictionary<string, GraphNode>>();
        
        while (nodesLeft.Count > 0)
        {
            var group = new Dictionary<string, GraphNode>();
            var q = new Queue<string>();
            q.Enqueue(nodesLeft.First());
            while (q.Count > 0)
            {
                var name = q.Dequeue();
                if (!nodesLeft.Contains(name))
                    continue;
                
                group.Add(name, nodes[name]);
                nodesLeft.Remove(name);
                foreach (var connection in nodes[name].Connections)
                {
                    q.Enqueue(connection.Name);
                }
            }
            
            groups.Add(group);
        }

        return groups;
    }
}