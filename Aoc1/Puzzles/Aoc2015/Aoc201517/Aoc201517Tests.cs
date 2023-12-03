using FluentAssertions;
using NUnit.Framework;

namespace Puzzles.Aoc.Puzzles.Aoc2015.Aoc201517;

public class Aoc201517Tests
{
    [Test]
    public void NumberOfCombinationsIsCorrect()
    {
        const string input = """
20
15
10
5
5
""";

        var containers = new EggnogContainers(input.Trim());
        var combinations = containers.GetCombinations(25);

        combinations.Count.Should().Be(4);
    }
}