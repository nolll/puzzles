using Pzl.Aoc.Puzzles.Aoc2020;

namespace Tests.Aoc.Aoc2020;

public class Aoc202003Tests : PuzzleTest<Aoc202003>
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

    [Fact]
    public void TreeCount_3_1_IsCorrect()
    {
        var navigator = new Aoc202003.TreeNavigator(Input);
        var treeCount = navigator.GetTreeCount(new Aoc202003.TreeTrajectory(3, 1));

        treeCount.Should().Be(7);
    }

    [Fact]
    public void TreeCount_1_2_IsCorrect()
    {
        var navigator = new Aoc202003.TreeNavigator(Input);
        var treeCount = navigator.GetTreeCount(new Aoc202003.TreeTrajectory(1, 2));

        treeCount.Should().Be(2);
    }

    [Fact]
    public void TreeCountsAreCorrect()
    {
        var navigator = new Aoc202003.TreeNavigator(Input);
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