using Core.Platform;

namespace Core.Puzzles.Year2020.Day20;

public class Year2020Day20 : Puzzle
{
    public override PuzzleResult RunPart1()
    {
        var puzzle = new ImageJigsawPuzzle(FileInput);
        return new PuzzleResult(puzzle.ProductOfCornerTileIds, 8_425_574_315_321);
    }

    public override PuzzleResult RunPart2()
    {
        var puzzle = new ImageJigsawPuzzle(FileInput);
        return new PuzzleResult(puzzle.NumberOfHashesThatAreNotPartOfASeaMonster, 1841);
    }
}