using Pzl.Aoc.Puzzles.Aoc2022;

namespace Tests.Aoc.Aoc2022;

public class Aoc202208Tests : PuzzleTest<Aoc202208>
{
    [Fact]
    public void Part1() => Sut.Part1(Input).Should().Be(21);

    [Fact]
    public void Part2() => Sut.Part2(Input).Should().Be(8);

    private const string Input = """
                                 30373
                                 25512
                                 65332
                                 33549
                                 35390
                                 """;
}