using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Codyssi.Puzzles.Codyssi03;

public class Codyssi03Tests
{
    private const string Input = """
                                 8-9 9-10
                                 7-8 8-10
                                 9-10 5-10
                                 3-10 9-10
                                 4-8 7-9
                                 9-10 2-7
                                 """;

    [Test]
    public void Part1() => Sut.Part1(Input).Answer.Should().Be("43");

    [Test]
    public void Part2() => Sut.Part2(Input).Answer.Should().Be("35");

    [Test]
    public void Part3() => Sut.Part3(Input).Answer.Should().Be("9");

    private static Codyssi03 Sut => new();
}