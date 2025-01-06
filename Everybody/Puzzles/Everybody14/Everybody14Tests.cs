using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Everybody.Puzzles.Everybody14;

public class Everybody14Tests
{
    [Test]
    public void Part1()
    {
        const string input = "U5,R3,D2,L5,U4,R5,D2";

        Sut.Part1(input).Answer.Should().Be("7");
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

    private static Everybody14 Sut => new();
}