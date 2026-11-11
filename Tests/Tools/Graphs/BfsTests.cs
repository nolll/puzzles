using Pzl.Tools.Graphs;

namespace Tests.Tools.Graphs;

public class BfsTests
{
    [Fact]
    public void ShortestPath()
    {
        List<GraphEdge> edges =
        [
            new("A", "B"),
            new("B", "A"),
            new("B", "C"),
            new("B", "D"),
            new("C", "B"),
            new("C", "E"),
            new("D", "B"),
            new("D", "E"),
            new("E", "C")
        ];

        Bfs.BestPath(edges, "A", "C").Should().BeEquivalentTo("A", "B", "C");
    }
    
    [Fact]
    public void SmallestCost()
    {
        List<GraphEdge> edges =
        [
            new("A", "B"),
            new("B", "A"),
            new("B", "C"),
            new("B", "D"),
            new("C", "B"),
            new("C", "E"),
            new("D", "B"),
            new("D", "E"),
            new("E", "C")
        ];

        Bfs.BestCost(edges, "A", "C").Should().Be(2);
    }
}