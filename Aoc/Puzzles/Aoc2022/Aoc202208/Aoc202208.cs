using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2022.Aoc202208;

[Name("Treetop Tree House")]
public class Aoc202208 : AocPuzzle
{
    private TreeHouse? _treeHouse;

    [Puzzle("db3773cdd4aa7c677d0d7b5276a6f31c")]
    public PuzzleResult Part1(string input)
    {
        _treeHouse = new TreeHouse(input);
        _treeHouse.Calc();
        var result = _treeHouse.VisibleTreesCount;

        return new PuzzleResult(result);
    }

    [Puzzle("20def27ee2db6df6b7e178884edb9c87")]
    public PuzzleResult Part2(string input)
    {
        _treeHouse?.Calc();
        var result = _treeHouse?.HighestScenicScore;

        return new PuzzleResult(result);
    }
}