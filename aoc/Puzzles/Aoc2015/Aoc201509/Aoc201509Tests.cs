using NUnit.Framework;

namespace Aoc.Puzzles.Aoc2015.Aoc201509;

public class Aoc201509Tests
{
    [Test]
    public void CalculateShortestAndLongestRoute()
    {
        const string input = """
London to Dublin = 464
London to Belfast = 518
Dublin to Belfast = 141
""";

        var calculator = new RouteCalculator(input.Trim());

        Assert.That(calculator.ShortestDistance, Is.EqualTo(605));
        Assert.That(calculator.LongestDistance, Is.EqualTo(982));
    }
}