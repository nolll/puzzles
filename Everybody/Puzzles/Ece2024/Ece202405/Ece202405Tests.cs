using FluentAssertions;

namespace Pzl.Everybody.Puzzles.Ece2024.Ece202405;

public class Ece202405Tests
{
    [Theory]
    [InlineData(1, "3345")]
    [InlineData(2, "3245")]
    [InlineData(3, "3255")]
    [InlineData(4, "3252")]
    [InlineData(5, "4252")]
    [InlineData(6, "4452")]
    [InlineData(7, "4422")]
    [InlineData(8, "4423")]
    [InlineData(9, "2423")]
    [InlineData(10, "2323")]
    public void Part1(int rounds, string expected)
    {
        const string input = """
                             2 3 4 5
                             3 4 5 2
                             4 5 2 3
                             5 2 3 4
                             """;

        Sut.RunPart1(input, rounds).Should().Be(expected);
    }
    
    [Fact]
    public void Part2()
    {
        const string input = """
                             2 3 4 5
                             6 7 8 9
                             """;

        Sut.RunPart2(input, 2024).Should().Be(50877075);
    }
    
    [Fact]
    public void Part3()
    {
        const string input = """
                             2 3 4 5
                             6 7 8 9
                             """;

        Sut.RunPart3(input).Answer.Should().Be("6584");
    }

    private static Ece202405 Sut => new();
}