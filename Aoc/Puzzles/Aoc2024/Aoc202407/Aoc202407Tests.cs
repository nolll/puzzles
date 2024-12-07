using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Aoc.Puzzles.Aoc2024.Aoc202407;

public class Aoc202407Tests
{
    private const string Input = """
                                 190: 10 19
                                 3267: 81 40 27
                                 83: 17 5
                                 156: 15 6
                                 7290: 6 8 6 15
                                 161011: 16 10 13
                                 192: 17 8 14
                                 21037: 9 7 18 13
                                 292: 11 6 16 20
                                 """;

    [Test]
    public void Part1()
    {
        Sut.Part1(Input).Answer.Should().Be("3749");
    }

    [Test]
    public void Part2()
    {
        Sut.Part2(Input).Answer.Should().Be("11387");
    }

    private static Aoc202407 Sut => new();
}