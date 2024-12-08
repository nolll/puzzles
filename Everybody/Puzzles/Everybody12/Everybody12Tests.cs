using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Everybody.Puzzles.Everybody12;

public class Everybody12Tests
{
    [Test]
    public void Part1()
    {
        const string input = """
                             .............
                             .C...........
                             .B......T....
                             .A......T.T..
                             =============
                             """;

        Sut.Part2(input).Answer.Should().Be("13");
    }

    [Test]
    public void Part2()
    {
        const string input = """
                             .............
                             .C...........
                             .B......H....
                             .A......T.H..
                             =============
                             """;

        Sut.Part2(input).Answer.Should().Be("22");
    }

    [Test]
    public void Part3()
    {
        const string input = """
                             6 5
                             6 7
                             10 5
                             """;

        Sut.Part3(input).Answer.Should().Be("11");
    }

    private static Everybody12 Sut => new();
}