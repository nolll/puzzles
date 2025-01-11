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
        const string input = """
                             1,2,3
                             
                             ^_^ -.- ^,-
                             >.- ^_^ >.<
                             -_- -.- >.<
                                 -.^ ^_^
                                 >.>
                             """;

        Sut.Part2(input).Answer.Should().Be("0");
    }

    [TestCase(">.--.-^_^", 1)]
    [TestCase("-_->.>>.<", 1)]
    [TestCase("^_^^_^>.<", 2)]
    [TestCase("^_^^_^^_^", 5)]
    public void Scoring(string input, int expected) => Sut.Score(input).Should().Be(expected);

    [Test]
    public void Part3()
    {
        const string input = "";

        Sut.Part3(input).Answer.Should().Be("0");
    }

    private static Everybody16 Sut => new();
}