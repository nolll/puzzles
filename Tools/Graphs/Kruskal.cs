namespace Pzl.Tools.Graphs;

public static class Kruskal
{
    public static long MinimumSpanningTree(List<GraphEdge> edges)
    {
        var i = 0;
        var e = 0;

        var nodes = Graph.GetNodes(edges);
        var result = edges.OrderBy(o => o.Cost).ToArray();
        var subsets = nodes.Keys.ToDictionary(nodekey => nodekey, nodekey => new Subset(nodekey, 0));
        
        // Number of edges to be taken is equal to V-1
        while (e < nodes.Count - 1) {

            // Pick the smallest edge. And increment
            // the index for next iteration
            var nextEdge = result[i++];

            var x = Find(subsets, nextEdge.From);
            var y = Find(subsets, nextEdge.To);

            // If including this edge doesn't cause cycle,
            // include it in result and increment the index
            // of result for next edge
            if (x != y) {
                result[e++] = nextEdge;
                Union(subsets, x, y);
            }
        }
        
        var minimumCost = 0L;
        for (i = 0; i < e; ++i) {
            minimumCost += result[i].Cost;
        }

        return minimumCost;
    }
    
    // A utility function to find set of an element i
    // (uses path compression technique)
    private static string Find(Dictionary<string, Subset> subsets, string id)
    {
        // Find root and make root as
        // parent of i (path compression)
        if (subsets[id].Parent != id)
            subsets[id].Parent = Find(subsets, subsets[id].Parent);

        return subsets[id].Parent;
    }
    
    // A function that does union of
    // two sets of x and y (uses union by rank)
    private static void Union(Dictionary<string, Subset> subsets, string x, string y)
    {
        var xroot = Find(subsets, x);
        var yroot = Find(subsets, y);

        // Attach smaller rank tree under root of
        // high rank tree (Union by Rank)
        if (subsets[xroot].Rank < subsets[yroot].Rank)
            subsets[xroot].Parent = yroot;
        else if (subsets[xroot].Rank > subsets[yroot].Rank)
            subsets[yroot].Parent = xroot;

        // If ranks are same, then make one as root
        // and increment its rank by one
        else {
            subsets[yroot].Parent = xroot;
            subsets[xroot].Rank++;
        }
    }
    
    // A class to represent
    // a subset for union-find
    private class Subset(string parent, int rank)
    {
        public string Parent { get; set; } = parent;
        public int Rank { get; set; } = rank;
    }
}