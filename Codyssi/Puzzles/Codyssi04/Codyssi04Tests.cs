using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Codyssi.Puzzles.Codyssi04;

public class Codyssi04Tests
{
    private const string Input = """
                                 NNBUSSSSSDSSZZZZMMMMMMMM
                                 PWAAASYBRRREEEEEEE
                                 FBBOFFFKDDDDDDDDD
                                 VJAANCPKKLZSSSSSSSSS
                                 NNNNNNBBVVVVVVVVV
                                 """;

    [Test]
    public void Part1() => Sut.Part1(Input).Answer.Should().Be("1247");

    [Test]
    public void Part2() => Sut.Part2(Input).Answer.Should().Be("219");

    [Test]
    public void Part3() => Sut.Part3(Input).Answer.Should().Be("539");

    private static Codyssi04 Sut => new();
}