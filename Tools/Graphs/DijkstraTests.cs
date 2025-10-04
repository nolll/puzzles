namespace Pzl.Tools.Graphs;

public class DijkstraTests
{
    [Fact]
    public void SmallestCost()
    {
        var edges = new List<GraphEdge>
        {
            new("A", "B", 8),
            new("B", "A", 8),
            new("B", "C", 50),
            new("B", "D", 5),
            new("C", "B", 50),
            new("C", "E", 6),
            new("D", "B", 5),
            new("D", "E", 10),
            new("E", "C", 6)
        };

        var result = Dijkstra.BestCost(edges, "A", "C");

        result.Should().Be(29);
    }
}