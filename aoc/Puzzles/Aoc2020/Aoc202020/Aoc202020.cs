using Puzzles.common.Puzzles;

namespace Puzzles.aoc.Puzzles.Aoc2020.Aoc202020;

public class Aoc202020 : AocPuzzle
{
    public override string Name => "Jurassic Jigsaw";

    protected override PuzzleResult RunPart1()
    {
        var puzzle = new ImageJigsawPuzzle(InputFile);
        return new PuzzleResult(puzzle.ProductOfCornerTileIds, "53852ec33c717ff2cc141d5403967cd3");
    }

    protected override PuzzleResult RunPart2()
    {
        var puzzle = new ImageJigsawPuzzle(InputFile);
        return new PuzzleResult(puzzle.NumberOfHashesThatAreNotPartOfASeaMonster, "064e1e2e30b4fed6bb576ee48cd6c9c1");
    }
}