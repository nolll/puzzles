using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2022.Aoc202208;

[Name("Treetop Tree House")]
public class Aoc202208 : AocPuzzle
{
    [Puzzle("db3773cdd4aa7c677d0d7b5276a6f31c")]
    public int Part1(string input)
    {
        var treeHouse = new TreeHouse(input);
        treeHouse.Calc();
        return treeHouse.VisibleTreesCount;
    }

    [Puzzle("20def27ee2db6df6b7e178884edb9c87")]
    public int? Part2(string input)
    {
        var treeHouse = new TreeHouse(input);
        treeHouse.Calc();
        return treeHouse?.HighestScenicScore;
    }
}