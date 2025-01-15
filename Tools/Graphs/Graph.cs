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