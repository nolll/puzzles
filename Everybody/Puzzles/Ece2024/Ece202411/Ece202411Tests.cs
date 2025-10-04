using FluentAssertions;

namespace Pzl.Everybody.Puzzles.Ece2024.Ece202411;

public class Ece202411Tests
{
    [Theory]
    [InlineData(1, 2)]
    [InlineData(2, 3)]
    [InlineData(3, 5)]
    [InlineData(4, 8)]
    public void Part1And2(int days, int expected)
    {
        const string input = """
                             A:B,C
                             B:C,A
                             C:A
                             """;

        Sut.Solve(input, "A", days).Should().Be(expected);
    }

    [Fact]
    public void Part3()
    {
        const string input = """
                             A:B,C
                             B:C,A,A
                             C:A
                             """;

        Sut.Part3(input).Answer.Should().Be("268815");
    }

    private static Ece202411 Sut => new();
}