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
    public void Part2()
    {
        const string input = "";

        Sut.Part2(input).Answer.Should().Be("0");
    }

    [Fact]
    public void Part3()
    {
        const string input = "";

        Sut.Part3(input).Answer.Should().Be("0");
    }

    private static Ece202511 Sut => new();
}