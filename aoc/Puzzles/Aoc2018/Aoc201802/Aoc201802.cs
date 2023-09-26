using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2018.Aoc201802;

public class Aoc201802 : AocPuzzle
{
    public override string Name => "Inventory Management System";

    protected override PuzzleResult RunPart1()
    {
        var boxChecksumPuzzle = new BoxChecksumPuzzle(InputFile);
        return new PuzzleResult(boxChecksumPuzzle.Checksum, 5434);
    }

    protected override PuzzleResult RunPart2()
    {
        var similarIdsPuzzle = new SimilarIdsPuzzle(InputFile);
        return new PuzzleResult(similarIdsPuzzle.CommonLetters, "agimdjvlhedpsyoqfzuknpjwt");
    }
}