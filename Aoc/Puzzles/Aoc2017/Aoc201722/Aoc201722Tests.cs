using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Aoc.Puzzles.Aoc2017.Aoc201722;

public class Aoc201722Tests
{
    private const string Input = """
..#
#..
...
""";

    [TestCase(7, 5)]
    [TestCase(70, 41)]
    [TestCase(10000, 5587)]
    public void InfectionCountIsCorrectForPart1(int iterations, int expected)
    {
        var infection = new VirusInfection(Input);
        var infectionCount = infection.RunPart1(iterations);

        infectionCount.Should().Be(expected);
    }

    [TestCase(100, 26)]
    [TestCase(10_000_000, 2_511_944)]
    public void InfectionCountIsCorrectForPart2(int iterations, int expected)
    {
        var infection = new VirusInfection(Input);
        var infectionCount = infection.RunPart2(iterations);

        infectionCount.Should().Be(expected);
    }
}