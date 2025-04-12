using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Codyssi.Puzzles.Codyssi2024.Codyssi202401;

public class Codyssi202401Tests
{
    private const string Input = """
                                 912372
                                 283723
                                 294281
                                 592382
                                 721395
                                 91238
                                 """;

    [Test]
    public void Part1() => Sut.Part1(Input).Answer.Should().Be("2895391");

    [Test]
    public void Part2() => Sut.Part2(Input, 2).Answer.Should().Be("1261624");

    [Test]
    public void Part3() => Sut.Part3(Input).Answer.Should().Be("960705");

    private static Codyssi202401 Sut => new();
}