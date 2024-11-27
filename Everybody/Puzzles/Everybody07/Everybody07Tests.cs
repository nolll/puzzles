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

        Everybody07.Part1(input).Should().Be("BDCA");
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

        Everybody07.Part2(track, input).Should().Be("DCBA");
    }
}