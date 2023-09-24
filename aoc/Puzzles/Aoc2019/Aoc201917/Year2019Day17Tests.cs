using NUnit.Framework;

namespace Aoc.Puzzles.Aoc2019.Aoc201917;

public class Year2019Day17Tests
{
    [Test]
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

        Assert.That(result, Is.EqualTo(76));
    }
}