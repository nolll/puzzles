using Pzl.Everybody.Puzzles.Ece2025.Ece202503;

namespace Pzl.Everybody.Puzzles.Ece2025.Ece202504;

public class Ece202504Tests
{
    [Fact]
    public void Part1()
    {
        const string input = """
                             102
                             75
                             50
                             35
                             13
                             """;

        Sut.Part1(input).Answer.Should().Be("15888");
    }

    [Fact]
    public void Part2()
    {
        const string input = """
                             102
                             75
                             50
                             35
                             13
                             """;

        Sut.Part2(input).Answer.Should().Be("1274509803922");
    }

    [Fact]
    public void Part3()
    {
        const string input = """
                             5
                             7|21
                             18|36
                             27|27
                             10|50
                             10|50
                             11
                             """;

        Sut.Part3(input).Answer.Should().Be("6818");
    }

    private static Ece202504 Sut => new();
}