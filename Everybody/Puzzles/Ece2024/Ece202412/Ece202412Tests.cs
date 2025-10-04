using FluentAssertions;

namespace Pzl.Everybody.Puzzles.Ece2024.Ece202412;

public class Ece202412Tests
{
    [Fact]
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

    [Fact]
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

    [Fact]
    public void Part3()
    {
        const string input = """
                             6 5
                             6 7
                             10 5
                             """;

        Sut.Part3(input).Answer.Should().Be("11");
    }

    private static Ece202412 Sut => new();
}