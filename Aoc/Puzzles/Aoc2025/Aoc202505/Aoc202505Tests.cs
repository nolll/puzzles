namespace Pzl.Aoc.Puzzles.Aoc2025.Aoc202505;

public class Aoc202505Tests
{
    private const string Input = """
                                 3-5
                                 10-14
                                 16-20
                                 12-18

                                 1
                                 5
                                 8
                                 11
                                 17
                                 32
                                 """;

    [Fact]
    public void Part1() => Sut.Part1(Input).Answer.Should().Be("3");

    [Fact]
    public void Part2() => Sut.Part2(Input).Answer.Should().Be("14");

    private static Aoc202505 Sut => new();
}