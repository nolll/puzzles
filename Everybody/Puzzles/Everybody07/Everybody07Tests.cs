using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Everybody.Puzzles.Everybody07;

public class Everybody07Tests
{
    [Test]
    public void Part1()
    {
        const string input = """
                             A:+,-,=,=
                             B:+,=,-,+
                             C:=,-,+,+
                             D:=,=,=,+
                             """;

        Sut.RunPart1(input).Answer.Should().Be("BDCA");
    }
    
    [Test]
    public void Part2()
    {
        const string track = """
                             S+===
                             -   +
                             =+=-+
                             """;
        
        const string input = """
                             A:+,-,=,=
                             B:+,=,-,+
                             C:=,-,+,+
                             D:=,=,=,+
                             """;

        Sut.Part2(track, input).Should().Be("DCBA");
    }
    
    private static Everybody07 Sut => new();
}