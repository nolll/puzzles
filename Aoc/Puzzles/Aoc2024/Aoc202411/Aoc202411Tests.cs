using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Aoc.Puzzles.Aoc2024.Aoc202411;

public class Aoc202411Tests
{
    private const string Input = "125 17";

    [Test]
    public void Part1() => Sut.Part1(Input).Answer.Should().Be("55312");

    [Test]
    public void Part2() => Sut.Part2(Input).Answer.Should().Be("65601038650482");

    private static Aoc202411 Sut => new();
}