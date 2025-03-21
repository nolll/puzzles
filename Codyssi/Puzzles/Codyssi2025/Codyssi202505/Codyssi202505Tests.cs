using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Codyssi.Puzzles.Codyssi2025.Codyssi202505;

public class Codyssi202505Tests
{
    private const string Input = """
                                 (-16, -191)
                                 (92, 186)
                                 (157, -75)
                                 (39, -132)
                                 (-42, 139)
                                 (-74, -150)
                                 (200, 197)
                                 (-106, 105)
                                 """;

    [Test]
    public void Part1() => Sut.Part1(Input).Answer.Should().Be("226");

    [Test]
    public void Part2() => Sut.Part2(Input).Answer.Should().Be("114");

    [Test]
    public void Part3() => Sut.Part3(Input).Answer.Should().Be("1384");

    private static Codyssi202505 Sut => new();
}