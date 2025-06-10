using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Everybody.Puzzles.Ece2024.Ece202407;

public class Ece202407Tests
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
    
    private static Ece202407 Sut => new();
}