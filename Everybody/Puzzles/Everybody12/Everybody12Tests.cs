using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Everybody.Puzzles.Everybody12;

public class Everybody12Tests
{
    [Test]
    public void Part1()
    {
        const string input = """
                             .............
                             .C...........
                             .B......T....
                             .A......T.T..
                             =============
                             """;

        Sut.Part1(input).Answer.Should().Be("13");
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

    private static Everybody12 Sut => new();
}