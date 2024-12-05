using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Aoc.Puzzles.Aoc2024.Aoc202405;

public class Aoc202405Tests
{
    private const string Input = """
                                 47|53
                                 97|13
                                 97|61
                                 97|47
                                 75|29
                                 61|13
                                 75|53
                                 29|13
                                 97|29
                                 53|29
                                 61|53
                                 97|53
                                 61|29
                                 47|13
                                 75|47
                                 97|75
                                 47|61
                                 75|61
                                 47|29
                                 75|13
                                 53|13

                                 75,47,61,53,29
                                 97,61,53,29,13
                                 75,29,13
                                 75,97,47,61,53
                                 61,13,29
                                 97,13,75,29,47
                                 """;

    [Test]
    public void Part1()
    {
        Sut.Part1(Input).Answer.Should().Be("143");
    }

    [Test]
    public void Part2()
    {
        Sut.Part2(Input).Answer.Should().Be("123");
    }

    private static Aoc202405 Sut => new();
}