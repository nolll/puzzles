using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Codyssi.Puzzles.Codyssi2025.Codyssi202511;

public class Codyssi202511Tests
{
    private const string Input = """
                                 32IED4E6L4 22
                                 1111300022221031003013 4
                                 1C1117A3BA88 13
                                 1100010000010010010001111000000010001100101 2
                                 7AJ5G2AB4F 22
                                 k6IHxTD 61
                                 """;

    [Test]
    public void Part1() => Sut.Part1(Input).Answer.Should().Be("9047685997827");

    [Test]
    public void Part2() => Sut.Part2(Input).Answer.Should().Be("4iWAbo%6");

    [Test]
    public void Part3() => Sut.Part3(Input).Answer.Should().Be("2366");

    private static Codyssi202511 Sut => new();
}