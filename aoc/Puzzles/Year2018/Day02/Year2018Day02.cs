using Aoc.Platform;
using common.Puzzles;

namespace Aoc.Puzzles.Year2018.Day02;

public class Year2018Day02 : AocPuzzle
{
    public override string Title => "Inventory Management System";

    public override PuzzleResult RunPart1()
    {
        var boxChecksumPuzzle = new BoxChecksumPuzzle(FileInput);
        return new PuzzleResult(boxChecksumPuzzle.Checksum, 5434);
    }

    public override PuzzleResult RunPart2()
    {
        var similarIdsPuzzle = new SimilarIdsPuzzle(FileInput);
        return new PuzzleResult(similarIdsPuzzle.CommonLetters, "agimdjvlhedpsyoqfzuknpjwt");
    }
}