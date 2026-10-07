using Pzl.Aoc.Puzzles.Aoc2022;

namespace Tests.Aoc.Aoc2022;

public class Aoc202202Tests : PuzzleTest<Aoc202202>
{
    [Fact]
    public void Part1() => Sut.Part1(Input).Should().Be(15);

    [Fact]
    public void Part2() => Sut.Part2(Input).Should().Be(12);

    private const string Input = """
                                 A Y
                                 B X
                                 C Z
                                 """;
}