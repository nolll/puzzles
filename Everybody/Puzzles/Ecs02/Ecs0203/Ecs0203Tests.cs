using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Everybody.Puzzles.Ecs02.Ecs0203;

public class Ecs0203Tests
{
    [Test]
    public void Part1()
    {
        const string input = """
                             1: faces=[1,2,3,4,5,6] seed=7
                             2: faces=[-1,1,-1,1,-1] seed=13
                             3: faces=[9,8,7,8,9] seed=17
                             """;

        Sut.Part1(input).Answer.Should().Be("844");
    }

    [Test]
    public void Part2()
    {
        const string input = """
                             1: faces=[1,2,3,4,5,6,7,8,9] seed=13
                             2: faces=[1,2,3,4,5,6,7,8,9] seed=29
                             3: faces=[1,2,3,4,5,6,7,8,9] seed=37
                             4: faces=[1,2,3,4,5,6,7,8,9] seed=43
                             
                             51257284
                             """;

        Sut.Part2(input).Answer.Should().Be("1,3,4,2");
    }

    [Test]
    public void Part3()
    {
        const string input = "";

        Sut.Part3(input).Answer.Should().Be("0");
    }

    private static Ecs0203 Sut => new();
}