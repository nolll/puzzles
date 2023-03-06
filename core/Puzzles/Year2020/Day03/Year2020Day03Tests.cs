using System.Linq;
using NUnit.Framework;

namespace Core.Puzzles.Year2020.Day03;

public class Year2020Day03Tests
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

        Assert.That(treeCount, Is.EqualTo(7));
    }

    [Test]
    public void TreeCount_1_2_IsCorrect()
    {
        var navigator = new TreeNavigator(Input);
        var treeCount = navigator.GetTreeCount(new TreeTrajectory(1, 2));

        Assert.That(treeCount, Is.EqualTo(2));
    }

    [Test]
    public void TreeCountsAreCorrect()
    {
        var navigator = new TreeNavigator(Input);
        var treeCounts = navigator.GetAllTreeCounts().ToList();

        Assert.That(treeCounts[0], Is.EqualTo(2));
        Assert.That(treeCounts[1], Is.EqualTo(7));
        Assert.That(treeCounts[2], Is.EqualTo(3));
        Assert.That(treeCounts[3], Is.EqualTo(4));
        Assert.That(treeCounts[4], Is.EqualTo(2));

        var product = treeCounts.Aggregate((long)1, (a, b) => a * b);
        Assert.That(product, Is.EqualTo(336));
    }
}