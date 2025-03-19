using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Codyssi.Puzzles.Codyssi01;

public class Codyssi01Tests
{
    [Test]
    public void Part1()
    {
        const string input = """
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

        Sut.Part1(input).Answer.Should().Be("21");
    }

    [Test]
    public void Part2()
    {
        const string input = "";

        Sut.Part2(input).Answer.Should().Be("0");
    }

    [Test]
    public void Part3()
    {
        const string input = "";

        Sut.Part3(input).Answer.Should().Be("0");
    }

    private static Codyssi01 Sut => new();
}