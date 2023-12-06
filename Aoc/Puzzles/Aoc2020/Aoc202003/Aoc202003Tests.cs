using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Aoc.Puzzles.Aoc2020.Aoc202003;

public class Aoc202003Tests
{
    private const string Input = """
..##.......
#...#...#..
.#....#..#.
..#.#...#.#
.#...##..#.
..#.##.....
.#.#.#....#
.#........#
#.##...#...
#...##....#
.#..#...#.#
""";

    [Test]
    public void TreeCount_3_1_IsCorrect()
    {
        var navigator = new TreeNavigator(Input);
        var treeCount = navigator.GetTreeCount(new TreeTrajectory(3, 1));

        treeCount.Should().Be(7);
    }

    [Test]
    public void TreeCount_1_2_IsCorrect()
    {
        var navigator = new TreeNavigator(Input);
        var treeCount = navigator.GetTreeCount(new TreeTrajectory(1, 2));

        treeCount.Should().Be(2);
    }

    [Test]
    public void TreeCountsAreCorrect()
    {
        var navigator = new TreeNavigator(Input);
        var treeCounts = navigator.GetAllTreeCounts().ToList();

        treeCounts[0].Should().Be(2);
        treeCounts[1].Should().Be(7);
        treeCounts[2].Should().Be(3);
        treeCounts[3].Should().Be(4);
        treeCounts[4].Should().Be(2);

        var product = treeCounts.Aggregate((long)1, (a, b) => a * b);
        product.Should().Be(336);
    }
}