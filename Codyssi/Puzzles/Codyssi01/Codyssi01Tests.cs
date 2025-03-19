using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Codyssi.Puzzles.Codyssi01;

public class Codyssi01Tests
{
    private const string Input = """
                                 8
                                 1
                                 5
                                 5
                                 7
                                 6
                                 5
                                 4
                                 3
                                 1
                                 -++-++-++
                                 """;

    [Test]
    public void Part1()
    {
        Sut.Part1(Input).Answer.Should().Be("21");
    }

    [Test]
    public void Part2()
    {
        Sut.Part2(Input).Answer.Should().Be("23");
    }

    [Test]
    public void Part3()
    {
        const string input = "";

        Sut.Part3(input).Answer.Should().Be("0");
    }

    private static Codyssi01 Sut => new();
}