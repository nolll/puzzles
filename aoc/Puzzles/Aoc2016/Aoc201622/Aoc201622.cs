using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2016.Aoc201622;

public class Aoc201622 : AocPuzzle
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