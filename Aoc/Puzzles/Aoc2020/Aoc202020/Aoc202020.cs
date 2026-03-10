using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2020.Aoc202020;

[Name("Jurassic Jigsaw")]
public class Aoc202020 : AocPuzzle
{
    [Puzzle("53852ec33c717ff2cc141d5403967cd3")]
    public PuzzleResult Part1(string input)
    {
        var puzzle = new ImageJigsawPuzzle(input);
        return new PuzzleResult(puzzle.ProductOfCornerTileIds);
    }

    [Puzzle("064e1e2e30b4fed6bb576ee48cd6c9c1")]
    public PuzzleResult Part2(string input)
    {
        var puzzle = new ImageJigsawPuzzle(input);
        return new PuzzleResult(puzzle.NumberOfHashesThatAreNotPartOfASeaMonster);
    }
}