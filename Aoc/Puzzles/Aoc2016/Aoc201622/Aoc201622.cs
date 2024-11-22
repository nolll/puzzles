using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2016.Aoc201622;

[Name("Grid Computing")]
public class Aoc201622(string input) : AocPuzzle
{
    protected override PuzzleResult RunPart1()
    {
        var storageGrid = new StorageGrid(input);
        var pairCount = storageGrid.GetViablePairCount();
        return new PuzzleResult(pairCount, "75405bd6fc453111e999ebdc18ba4f78");
    }

    protected override PuzzleResult RunPart2()
    {
        var storageGrid = new StorageGrid(input);
        var moveCount = storageGrid.MoveStorage();
        return new PuzzleResult(moveCount, "112a5875109cbca20cbe3dd1d02fe9fd");
    }
}