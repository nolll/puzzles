using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Everybody.Puzzles.Ecs01.Ecs0103;

public class Ecs0103Tests
{
    [Test]
    public void Part1()
    {
        const string input = """
                             x=1 y=2
                             x=2 y=3
                             x=3 y=4
                             x=4 y=4
                             """;

        Sut.Part1(input).Answer.Should().Be("1310");
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

    private static Ecs0103 Sut => new();
}