using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Everybody.Puzzles.Everybody13;

public class Everybody13Tests
{
    [Test]
    public void Part1()
    {
        const string input = """
                             #######
                             #6769##
                             S50505E
                             #97434#
                             #######
                             """;

        Sut.Part1(input).Answer.Should().Be("28");
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

    private static Everybody13 Sut => new();
}