using NUnit.Framework;

namespace Aoc.Puzzles.Aoc2022.Aoc202208;

public class Aoc202208Tests
{
    [Test]
    public void Part1()
    {
        var treeHouse = new TreeHouse(Input);
        treeHouse.Calc();
        var result = treeHouse.VisibleTreesCount;

        Assert.That(result, Is.EqualTo(21));
    }

    [Test]
    public void Part2()
    {
        var treeHouse = new TreeHouse(Input);
        treeHouse.Calc();
        var result = treeHouse.HighestScenicScore;

        Assert.That(result, Is.EqualTo(8));
    }

    private const string Input = """
30373
25512
65332
33549
35390
""";
}