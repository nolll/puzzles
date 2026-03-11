namespace Pzl.Aoc.Puzzles.Aoc2024.Aoc202401;

public class Aoc202401Tests
{
    private const string Input = """
                                 3   4
                                 4   3
                                 2   5
                                 1   3
                                 3   9
                                 3   3
                                 """;

    [Fact]
    public void Part1() => Sut.Part1(Input).Should().Be(11);

    [Fact]
    public void Part2() => Sut.Part2(Input).Should().Be(31);

    private static Aoc202401 Sut => new();
}