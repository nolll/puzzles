using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Codyssi.Puzzles.Codyssi2024.Codyssi202404;

public class Codyssi202404Tests
{
    private const string Input = """
                                 ADB <-> XYZ
                                 STT <-> NYC
                                 PLD <-> XYZ
                                 ADB <-> NYC
                                 JLI <-> NYC
                                 PTO <-> ADB
                                 """;

    [Test]
    public void Part1() => Sut.Part1(Input).Answer.Should().Be("7");

    [Test]
    public void Part2() => Sut.Part2(Input).Answer.Should().Be("6");

    [Test]
    public void Part3() => Sut.Part3(Input).Answer.Should().Be("15");

    private static Codyssi202404 Sut => new();
}