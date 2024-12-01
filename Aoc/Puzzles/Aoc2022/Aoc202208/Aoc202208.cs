using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2022.Aoc202208;

[Name("Treetop Tree House")]
public class Aoc202208 : AocPuzzle
{
    private TreeHouse? _treeHouse;

    protected override PuzzleResult RunPart1(string input)
    {
        _treeHouse = new TreeHouse(input);
        _treeHouse.Calc();
        var result = _treeHouse.VisibleTreesCount;

        return new PuzzleResult(result, "db3773cdd4aa7c677d0d7b5276a6f31c");
    }

    protected override PuzzleResult RunPart2(string input)
    {
        _treeHouse?.Calc();
        var result = _treeHouse?.HighestScenicScore;

        return new PuzzleResult(result, "20def27ee2db6df6b7e178884edb9c87");
    }
}