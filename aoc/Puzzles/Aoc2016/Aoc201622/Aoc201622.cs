using Puzzles.common.Puzzles;

namespace Puzzles.aoc.Puzzles.Aoc2016.Aoc201622;

public class Aoc201622 : AocPuzzle
{
    public override string Name => "Grid Computing";

    protected override PuzzleResult RunPart1()
    {
        var storageGrid = new StorageGrid(InputFile);
        var pairCount = storageGrid.GetViablePairCount();
        return new PuzzleResult(pairCount, "75405bd6fc453111e999ebdc18ba4f78");
    }

    protected override PuzzleResult RunPart2()
    {
        var storageGrid = new StorageGrid(InputFile);
        var moveCount = storageGrid.MoveStorage();
        return new PuzzleResult(moveCount, "112a5875109cbca20cbe3dd1d02fe9fd");
    }
}