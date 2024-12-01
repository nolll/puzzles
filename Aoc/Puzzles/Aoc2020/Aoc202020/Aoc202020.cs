using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2020.Aoc202020;

[Name("Jurassic Jigsaw")]
public class Aoc202020 : AocPuzzle
{
    public PuzzleResult RunPart1(string input)
    {
        var puzzle = new ImageJigsawPuzzle(input);
        return new PuzzleResult(puzzle.ProductOfCornerTileIds, "53852ec33c717ff2cc141d5403967cd3");
    }

    public PuzzleResult RunPart2(string input)
    {
        var puzzle = new ImageJigsawPuzzle(input);
        return new PuzzleResult(puzzle.NumberOfHashesThatAreNotPartOfASeaMonster, "064e1e2e30b4fed6bb576ee48cd6c9c1");
    }
}