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
    public void Part2And3()
    {
        const string input = "GGBR";

        Ecs0202.Part2And3(input, 5).Should().Be(14);
    }

    private static Ecs0202 Sut => new();
}