using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Aoc.Puzzles.Aoc2024.Aoc202405;

public class Aoc202405Tests
{
    [Test]
    public void Part1()
    {
        const string input = "";

        Sut.Part1(input).Answer.Should().Be("0");
    }

    [Test]
    public void Part2()
    {
        const string input = "";

        Sut.Part2(input).Answer.Should().Be("0");
    }

    private static Aoc202405 Sut => new();
}