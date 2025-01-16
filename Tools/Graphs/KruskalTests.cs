using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Tools.Graphs;

public class KruskalTests
{
    [Test]
    public void MinimumSpanningTree()
    {
        GraphEdge[] edges =
        [
            new("0,0", "4,0", 4),
            new("0,0", "2,1", 3),
            new("0,0", "0,4", 4),
            new("0,0", "2,4", 6),
            new("4,0", "0,0", 4),
            new("4,0", "2,1", 3),
            new("4,0", "0,4", 8),
            new("4,0", "2,4", 6),
            new("2,1", "0,0", 3),
            new("2,1", "4,0", 3),
            new("2,1", "0,4", 5),
            new("2,1", "2,4", 3),
            new("0,4", "0,0", 4),
            new("0,4", "4,0", 8),
            new("0,4", "2,1", 5),
            new("0,4", "2,4", 2),
            new("2,4", "0,0", 6),
            new("2,4", "4,0", 6),
            new("2,4", "2,1", 3),
            new("2,4", "0,4", 2)
        ];

        Kruskal.MinimumSpanningTree(edges.ToList()).Should().Be(11);
    }
}