using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Codyssi.Puzzles.Codyssi2025.Codyssi202516;

public class Codyssi202516Tests
{
    private const string Input = """
                                 FACE - VALUE 38
                                 ROW 2 - VALUE 71
                                 ROW 1 - VALUE 57
                                 ROW 3 - VALUE 68
                                 COL 1 - VALUE 52
                                 
                                 LURD
                                 """;

    [Test]
    public void Part1_1() => Sut.RunPart1(Input, 3).Should().Be(201474);

    [Test]
    public void Part2() => Sut.Part2(Input).Answer.Should().Be("0");

    [Test]
    public void Part3() => Sut.Part3(Input).Answer.Should().Be("0");

    private static Codyssi202516 Sut => new();
}