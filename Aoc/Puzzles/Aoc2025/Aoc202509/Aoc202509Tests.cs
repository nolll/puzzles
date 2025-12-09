namespace Pzl.Aoc.Puzzles.Aoc2025.Aoc202509;

public class Aoc202509Tests
{
    private const string Input = """
                                 7,1
                                 11,1
                                 11,7
                                 9,7
                                 9,5
                                 2,5
                                 2,3
                                 7,3
                                 """;

    [Fact]
    public void Part1() => Sut.Part1(Input).Answer.Should().Be("50");

    [Fact]
    public void Part2() => Sut.Part2(Input).Answer.Should().Be("24");

    private static Aoc202509 Sut => new();
}