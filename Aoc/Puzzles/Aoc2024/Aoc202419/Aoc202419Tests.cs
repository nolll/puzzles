using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Aoc.Puzzles.Aoc2024.Aoc202419;

public class Aoc202419Tests
{
    private const string Input = """
                                 r, wr, b, g, bwu, rb, gb, br

                                 brwrr
                                 bggr
                                 gbbr
                                 rrbgbr
                                 ubwu
                                 bwurrg
                                 brgr
                                 bbrgwb
                                 """;

    [Test]
    public void Part1()
    {
        Sut.Part1(Input).Answer.Should().Be("6");
    }

    [Test]
    public void Part2()
    {
        Sut.Part2(Input).Answer.Should().Be("16");
    }

    private static Aoc202419 Sut => new();
}