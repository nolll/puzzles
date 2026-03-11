namespace Pzl.Aoc.Puzzles.Aoc2022.Aoc202202;

public class Aoc202202Tests
{
    [Fact]
    public void Part1() => Sut.Part1(Input).Should().Be(15);

    [Fact]
    public void Part2() => Sut.Part2(Input).Should().Be(12);

    private static Aoc202202 Sut => new();

    private const string Input = """
                                 A Y
                                 B X
                                 C Z
                                 """;
}