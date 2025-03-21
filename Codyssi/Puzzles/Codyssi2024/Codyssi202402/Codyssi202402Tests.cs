using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Codyssi.Puzzles.Codyssi2024.Codyssi202402;

public class Codyssi202402Tests
{
    private const string Input = """
                                 TRUE
                                 FALSE
                                 TRUE
                                 FALSE
                                 FALSE
                                 FALSE
                                 TRUE
                                 TRUE
                                 """;

    [Test]
    public void Part1() => Sut.Part1(Input).Answer.Should().Be("19");

    [Test]
    public void Part2() => Sut.Part2(Input).Answer.Should().Be("2");

    [Test]
    public void Part3() => Sut.Part3(Input).Answer.Should().Be("7");

    private static Codyssi202402 Sut => new();
}