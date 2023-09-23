using Aoc.Platform;
using Common.Puzzles;

namespace Aoc.Puzzles.Year2018.Day02;

public class Year2018Day02 : AocPuzzle
{
    public override string Name => "Inventory Management System";

    protected override PuzzleResult RunPart1()
    {
        var boxChecksumPuzzle = new BoxChecksumPuzzle(FileInput);
        return new PuzzleResult(boxChecksumPuzzle.Checksum, 5434);
    }

    protected override PuzzleResult RunPart2()
    {
        var similarIdsPuzzle = new SimilarIdsPuzzle(FileInput);
        return new PuzzleResult(similarIdsPuzzle.CommonLetters, "agimdjvlhedpsyoqfzuknpjwt");
    }
}