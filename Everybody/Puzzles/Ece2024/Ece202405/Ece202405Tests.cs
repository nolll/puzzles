namespace Pzl.Everybody.Puzzles.Ece2024.Ece202405;

public class Ece202405Tests
{
    private const string Part1Input = """
                                      2 3 4 5
                                      3 4 5 2
                                      4 5 2 3
                                      5 2 3 4
                                      """;

    private const string Part2And3Input = """
                                          2 3 4 5
                                          6 7 8 9
                                          """;

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
    public void Part1(int rounds, string expected) => Sut.SolvePart1(Part1Input, rounds).Should().Be(expected);

    [Fact]
    public void Part2() => Sut.SolvePart2(Part2And3Input, 2024).Should().Be(50877075);

    [Fact]
    public void Part3() => Sut.Part3(Part2And3Input).Should().Be(6584);

    private static Ece202405 Sut => new();
}