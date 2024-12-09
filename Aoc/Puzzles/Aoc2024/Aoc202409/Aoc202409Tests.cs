using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Aoc.Puzzles.Aoc2024.Aoc202409;

public class Aoc202409Tests
{
    private const string Input = "2333133121414131402";

    [Test]
    public void Part1()
    {
        Sut.Part1(Input).Answer.Should().Be("1928");
    }

    [Test]
    public void Part2()
    {
        Sut.Part2(Input).Answer.Should().Be("2858");
    }

    private static Aoc202409 Sut => new();
}