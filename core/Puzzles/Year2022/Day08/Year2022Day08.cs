using Core.Platform;

namespace Core.Puzzles.Year2022.Day08;

public class Year2022Day08 : Puzzle
{
    private TreeHouse _treeHouse;

    public override string Title => "Treetop Tree House";

    public override PuzzleResult RunPart1()
    {
        _treeHouse = new TreeHouse(FileInput);
        _treeHouse.Calc();
        var result = _treeHouse.VisibleTreesCount;

        return new PuzzleResult(result, 1538);
    }

    public override PuzzleResult RunPart2()
    {
        _treeHouse.Calc();
        var result = _treeHouse.HighestScenicScore;

        return new PuzzleResult(result, 496125);
    }
}