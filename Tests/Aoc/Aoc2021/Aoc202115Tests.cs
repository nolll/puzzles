using Pzl.Aoc.Puzzles.Aoc2021;

namespace Tests.Aoc.Aoc2021;

public class Aoc202115Tests : PuzzleTest<Aoc202115>
{
    [Fact]
    public void Part1() => Sut.Part1(Input).Should().Be(40);

    [Fact]
    public void Part2() => Sut.Part2(Input).Should().Be(315);

    private const string Input = """
                                 1163751742
                                 1381373672
                                 2136511328
                                 3694931569
                                 7463417111
                                 1319128137
                                 1359912421
                                 3125421639
                                 1293138521
                                 2311944581
                                 """;
}