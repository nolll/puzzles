namespace Pzl.Aoc.Puzzles.Aoc2025.Aoc202503;

public class Aoc202503Tests
{
    private const string Input = """
                                 987654321111111
                                 811111111111119
                                 234234234234278
                                 818181911112111
                                 """;

    [Fact]
    public void Part1() => Sut.Part1(Input).Answer.Should().Be("357");

    [Fact]
    public void Part2() => Sut.Part2(Input).Answer.Should().Be("3121910778619");

    private static Aoc202503 Sut => new();
}