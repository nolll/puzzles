using Pzl.Aoc.Puzzles.Aoc2022;

namespace Tests.Aoc.Aoc2022;

public class Aoc202208Tests
{
    [Fact]
    public void Part1()
    {
        var treeHouse = new Aoc202208.TreeHouse(Input);
        treeHouse.Calc();
        var result = treeHouse.VisibleTreesCount;

        result.Should().Be(21);
    }

    [Fact]
    public void Part2()
    {
        var treeHouse = new Aoc202208.TreeHouse(Input);
        treeHouse.Calc();
        var result = treeHouse.HighestScenicScore;

        result.Should().Be(8);
    }

    private const string Input = """
                                 30373
                                 25512
                                 65332
                                 33549
                                 35390
                                 """;
}