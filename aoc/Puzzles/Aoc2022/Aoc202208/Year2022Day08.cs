using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2022.Aoc202208;

public class Year2022Day08 : AocPuzzle
{
    private TreeHouse? _treeHouse;

    public override string Name => "Treetop Tree House";

    protected override PuzzleResult RunPart1()
    {
        _treeHouse = new TreeHouse(InputFile);
        _treeHouse.Calc();
        var result = _treeHouse.VisibleTreesCount;

        return new PuzzleResult(result, 1538);
    }

    protected override PuzzleResult RunPart2()
    {
        _treeHouse?.Calc();
        var result = _treeHouse?.HighestScenicScore;

        return new PuzzleResult(result, 496125);
    }
}