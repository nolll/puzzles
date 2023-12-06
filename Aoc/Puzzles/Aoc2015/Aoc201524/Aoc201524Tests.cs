using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Aoc.Puzzles.Aoc2015.Aoc201524;

public class Aoc201524Tests
{
    [Test]
    public void QuantumEntanglementOfFirstGroupIsCorrect()
    {
        const string input = """
1
2
3
4
5
7
8
9
10
11
""";

        var balancer = new PresentBalancer(input.Trim(), 3);

        balancer.QuantumEntanglementOfFirstGroup.Should().Be(99);
    }
}