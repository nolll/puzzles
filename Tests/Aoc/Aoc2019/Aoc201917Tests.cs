using Pzl.Aoc.Puzzles.Aoc2019;

namespace Tests.Aoc.Aoc2019;

public class Aoc201917Tests : PuzzleTest<Aoc201917>
{
    [Fact]
    public void IntersectionsFound()
    {
        const string input = """
                             ..#..........
                             ..#..........
                             #######...###
                             #.#...#...#.#
                             #############
                             ..#...#...#..
                             ..#####...^..
                             """;

        var intersectionFinder = new Aoc201917.ScaffoldIntersectionFinder(input);
        var result = intersectionFinder.GetSumOfAlignmentParameters();

        result.Should().Be(76);
    }
}