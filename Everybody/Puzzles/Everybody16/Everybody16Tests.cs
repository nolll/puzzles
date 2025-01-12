using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Everybody.Puzzles.Everybody16;

public class Everybody16Tests
{
    private const string Input = """
                                 1,2,3

                                 ^_^ -.- ^,-
                                 >.- ^_^ >.<
                                 -_- -.- >.<
                                     -.^ ^_^
                                     >.>
                                 """;

    [Test]
    public void Part1() => Sut.Part1(Input).Answer.Should().Be(">.- -.- ^,-");

    [TestCase(1, 1)]
    [TestCase(2, 2)]
    [TestCase(3, 4)]
    [TestCase(4, 5)]
    [TestCase(5, 7)]
    [TestCase(6, 7)]
    [TestCase(7, 9)]
    [TestCase(8, 11)]
    [TestCase(9, 14)]
    [TestCase(10, 15)]
    [TestCase(11, 17)]
    [TestCase(12, 18)]
    [TestCase(13, 20)]
    [TestCase(14, 21)]
    [TestCase(15, 21)]
    [TestCase(16, 23)]
    [TestCase(17, 23)]
    [TestCase(18, 25)]
    [TestCase(19, 25)]
    [TestCase(20, 28)]
    [TestCase(21, 30)]
    [TestCase(22, 32)]
    [TestCase(23, 32)]
    [TestCase(24, 34)]
    [TestCase(25, 35)]
    [TestCase(26, 37)]
    [TestCase(27, 38)]
    [TestCase(28, 39)]
    [TestCase(29, 41)]
    [TestCase(30, 41)]
    [TestCase(100, 138)]
    [TestCase(1000, 1383)]
    [TestCase(10000, 13833)]
    [TestCase(100000, 138333)]
    [TestCase(1000000, 1383333)]
    [TestCase(10000000, 13833333)]
    [TestCase(100000000, 138333333)]
    [TestCase(1000000000, 1383333333)]
    [TestCase(10000000000, 13833333333)]
    [TestCase(100000000000, 138333333333)]
    [TestCase(202420242024, 280014668134)]
    public void Part2(long target, long expected) => Sut.Part2(Input, target).Should().Be(expected);

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