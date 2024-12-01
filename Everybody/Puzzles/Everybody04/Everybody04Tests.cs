using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Everybody.Puzzles.Everybody04;

public class Everybody04Tests
{
    [Test]
    public void Part1And2()
    {
        const string input = """
                             3
                             4
                             7
                             8
                             """;

        Sut.RunPart1(input).Answer.Should().Be("10");
    }
    
    [Test]
    public void Part3()
    {
        const string input = """
                             2
                             4
                             5
                             6
                             8
                             """;

        Sut.RunPart3(input).Answer.Should().Be("8");
    }

    private static Everybody04 Sut => new();
}