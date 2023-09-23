using Common.Puzzles;

namespace Aoc.Puzzles.Year2016.Day22;

public class Year2016Day22 : AocPuzzle
{
    public override string Name => "Grid Computing";

    protected override PuzzleResult RunPart1()
    {
        var storageGrid = new StorageGrid(InputFile);
        var pairCount = storageGrid.GetViablePairCount();
        return new PuzzleResult(pairCount, 950);
    }

    protected override PuzzleResult RunPart2()
    {
        var storageGrid = new StorageGrid(InputFile);
        var moveCount = storageGrid.MoveStorage();
        return new PuzzleResult(moveCount, 256);
    }
}