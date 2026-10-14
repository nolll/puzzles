using Pzl.Aoc.Puzzles.Aoc2019;

namespace Tests.Aoc.Aoc2019;

public class Aoc201917Tests : PuzzleTest<Aoc201917>
{
    private const string Input = """
                                 ..#..........
                                 ..#..........
                                 #######...###
                                 #.#...#...#.#
                                 #############
                                 ..#...#...#..
                                 ..#####...^..
                                 """;

    [Fact]
    public void IntersectionsFound() => Sut.GetSumOfAlignmentParameters(Input).Should().Be(76);
}