using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Aoc.Puzzles.Aoc2023.Aoc202309;

public class Aoc202309Tests
{
    [Test]
    public void Part1()
    {
        const string input = """
                             0 3 6 9 12 15
                             1 3 6 10 15 21
                             10 13 16 21 30 45
                             """;

        var result = Aoc202309.Part1(input);

        result.Should().Be(114);
    }

    [Test]
    public void Part2()
    {
        const string input = """
                             0 3 6 9 12 15
                             1 3 6 10 15 21
                             10 13 16 21 30 45
                             """;

        var result = Aoc202309.Part2(input);

        result.Should().Be(2);
    }
}