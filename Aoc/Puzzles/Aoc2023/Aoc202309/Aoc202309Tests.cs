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

    [TestCase("0 3 6 9 12 15", 18)]
    [TestCase("1 3 6 10 15 21", 28)]
    [TestCase("10 13 16 21 30 45", 68)]
    [TestCase("-1 -2 -3 -4 -5 -6", -7)]
    public void NextNumber(string input, long expected)
    {
        var result = Aoc202309.FindNextNumber(input);

        result.Should().Be(expected);
    }

    [TestCase("0 3 6 9 12 15", -3)]
    [TestCase("1 3 6 10 15 21", 0)]
    [TestCase("10 13 16 21 30 45", 5)]
    [TestCase("-1 -2 -3 -4 -5 -6", 0)]
    public void PrevNumber(string input, long expected)
    {
        var result = Aoc202309.FindPrevNumber(input);

        result.Should().Be(expected);
    }
}