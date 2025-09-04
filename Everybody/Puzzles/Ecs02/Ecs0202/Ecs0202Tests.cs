using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Everybody.Puzzles.Ecs02.Ecs0202;

public class Ecs0202Tests
{
    [Test]
    public void Part1()
    {
        const string input = "GRBGGGBBBRRRRRRRR";

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

    private static Ecs0202 Sut => new();
}