using Pzl.Aoc.Puzzles.Aoc2021;

namespace Tests.Aoc.Aoc2021;

public class Aoc202111Tests : PuzzleTest<Aoc202111>
{
    [Fact]
    public void Part1() => Sut.Solve(Input, 100).Should().Be(1656);

    [Fact]
    public void Part2() => Sut.Solve(Input).Should().Be(195);

    private const string Input = """
                                 5483143223
                                 2745854711
                                 5264556173
                                 6141336146
                                 6357385478
                                 4167524645
                                 2176841721
                                 6882881134
                                 4846848554
                                 5283751526
                                 """;
}