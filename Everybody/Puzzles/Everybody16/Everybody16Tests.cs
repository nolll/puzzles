using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Everybody.Puzzles.Everybody16;

public class Everybody16Tests
{
    [Test]
    public void Part1()
    {
        const string input = """
                             1,2,3
                             
                             ^_^ -.- ^,-
                             >.- ^_^ >.<
                             -_- -.- >.<
                                 -.^ ^_^
                                 >.>
                             """;

        Sut.Part1(input).Answer.Should().Be(">.- -.- ^,-");
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

    private static Everybody16 Sut => new();
}