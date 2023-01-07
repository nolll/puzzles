using Core.Platform;

namespace Core.Puzzles.Year2016.Day22;

public class Year2016Day22 : Puzzle
{
    public override string Title => "Grid Computing";

    public override PuzzleResult RunPart1()
    {
        var storageGrid = new StorageGrid(FileInput);
        var pairCount = storageGrid.GetViablePairCount();
        return new PuzzleResult(pairCount, 950);
    }

    public override PuzzleResult RunPart2()
    {
        var storageGrid = new StorageGrid(FileInput);
        var moveCount = storageGrid.MoveStorage();
        return new PuzzleResult(moveCount, 256);
    }
}