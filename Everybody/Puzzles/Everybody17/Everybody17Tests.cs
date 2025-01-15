using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Everybody.Puzzles.Everybody17;

public class Everybody17Tests
{
    [Test]
    public void Part1()
    {
        const string input = """
                             *...*
                             ..*..
                             .....
                             .....
                             *.*..
                             """;

        Sut.Part1(input).Answer.Should().Be("11");
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

    private static Everybody17 Sut => new();
}