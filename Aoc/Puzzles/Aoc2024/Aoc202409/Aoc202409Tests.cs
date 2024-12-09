using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Aoc.Puzzles.Aoc2024.Aoc202409;

public class Aoc202409Tests
{
    [Test]
    public void Part1()
    {
        const string input = "2333133121414131402";

        Sut.Part1(input).Answer.Should().Be("1928");
    }

    [Test]
    public void Part2()
    {
        const string input = "";

        Sut.Part2(input).Answer.Should().Be("0");
    }

    private static Aoc202409 Sut => new();
}