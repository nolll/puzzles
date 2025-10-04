namespace Pzl.Aoc.Puzzles.Aoc2019.Aoc201917;

public class Aoc201917Tests
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

        var intersectionFinder = new ScaffoldIntersectionFinder(input);
        var result = intersectionFinder.GetSumOfAlignmentParameters();

        result.Should().Be(76);
    }
}