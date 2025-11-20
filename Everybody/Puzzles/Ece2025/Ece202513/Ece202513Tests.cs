namespace Pzl.Everybody.Puzzles.Ece2025.Ece202513;

public class Ece202513Tests
{
    [Fact]
    public void Part1()
    {
        const string input = """
                             72
                             58
                             47
                             61
                             67
                             """;

        Sut.Part1(input).Answer.Should().Be("67");
    }

    [Fact]
    public void Part2()
    {
        const string input = """
                             10-15
                             12-13
                             20-21
                             19-23
                             30-37
                             """;

        Sut.Part2(input).Answer.Should().Be("30");
    }

    private static Ece202513 Sut => new();
}