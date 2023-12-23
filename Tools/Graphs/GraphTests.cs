using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Tools.Graphs;

public class GraphTests
{
    [Test]
    public void SmallestCost()
    {
        var input = new List<Graph.Input>
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

        var result = Graph.GetLowestCost(input, "A", "C");

        result.Should().Be(29);
    }

    [Test]
    public void HighestCost()
    {
        var input = new List<Graph.Input>
        {
            new("A", "B", 1),
            new("B", "C", 1),
            new("C", "D", 1),
            new("D", "E", 1),
            new("A", "E", 1),
            new("E", "A", 0)
        };

        var result = Graph.GetHighestCost(input, "A", "E");

        result.Should().Be(4);
    }
}