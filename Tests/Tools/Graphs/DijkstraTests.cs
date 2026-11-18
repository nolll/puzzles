using Pzl.Tools.Graphs;

namespace Tests.Tools.Graphs;

public class DijkstraTests
{
    [Fact]
    public void SmallestCost()
    {
        List<GraphEdge> edges =
        [
            new("A", "B", 8),
            new("B", "A", 8),
            new("B", "C", 50),
            new("B", "D", 5),
            new("C", "B", 50),
            new("C", "E", 6),
            new("D", "B", 5),
            new("D", "E", 10),
            new("E", "C", 6)
        ];

        Dijkstra.BestCost(edges, "A", "C").Should().Be(29);
    }

    [Fact]
    public void Distances()
    {
        List<GraphEdge> edges =
        [
            new("A", "B", 8),
            new("B", "A", 8),
            new("B", "C", 50),
            new("B", "D", 5),
            new("C", "B", 50),
            new("C", "E", 6),
            new("D", "B", 5),
            new("D", "E", 10),
            new("E", "C", 6),
            new("X", "Y", 1)
        ];

        var distances = Dijkstra.AllCosts(edges, "A");

        distances.Should().BeEquivalentTo(new Dictionary<string, int>
        {
            { "A", 0 },
            { "B", 8 },
            { "D", 13 },
            { "E", 23 },
            { "C", 29 }
        });
    }
}