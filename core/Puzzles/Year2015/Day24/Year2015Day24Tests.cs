using NUnit.Framework;

namespace Core.Puzzles.Year2015.Day24;

public class Year2015Day24Tests
{
    [Test]
    public void QuantumEntanglementOfFirstGroupIsCorrect()
    {
        const string input = @"
1
2
3
4
5
7
8
9
10
11";

        var balancer = new PresentBalancer(input, 3);

        Assert.That(balancer.QuantumEntanglementOfFirstGroup, Is.EqualTo(99));
    }
}