namespace Pzl.Everybody.Puzzles.Ece2025.Ece202511;

public class Ece202511Tests
{
    [Fact]
    public void Part1()
    {
        const string input = """
                             9
                             1
                             1
                             4
                             9
                             6
                             """;

        Sut.Part1(input).Answer.Should().Be("109");
    }

    [Fact]
    public void Part2_1()
    {
        const string input = """
                             9
                             1
                             1
                             4
                             9
                             6
                             """;

        Sut.Part2(input).Answer.Should().Be("11");
    }

    [Fact]
    public void Part2_2()
    {
        const string input = """
                             805
                             706
                             179
                             48
                             158
                             150
                             232
                             885
                             598
                             524
                             423
                             """;

        Sut.Part2(input).Answer.Should().Be("1579");
    }

    [Fact]
    public void Part3()
    {
        const string input = "";

        Sut.Part3(input).Answer.Should().Be("0");
    }

    private static Ece202511 Sut => new();
}