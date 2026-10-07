using Pzl.Aoc.Puzzles.Aoc2024;

namespace Tests.Aoc.Aoc2024;

public class Aoc202401Tests : PuzzleTest<Aoc202401>
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
}