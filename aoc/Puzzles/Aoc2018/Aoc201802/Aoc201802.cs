using Puzzles.common.Puzzles;

namespace Puzzles.aoc.Puzzles.Aoc2018.Aoc201802;

public class Aoc201802 : AocPuzzle
{
    public override string Name => "Inventory Management System";

    protected override PuzzleResult RunPart1()
    {
        var boxChecksumPuzzle = new BoxChecksumPuzzle(InputFile);
        return new PuzzleResult(boxChecksumPuzzle.Checksum, "e7ee8e8967be0ed8c2fe23ef3e7d765e");
    }

    protected override PuzzleResult RunPart2()
    {
        var similarIdsPuzzle = new SimilarIdsPuzzle(InputFile);
        return new PuzzleResult(similarIdsPuzzle.CommonLetters, "dec3acac891412bfec2fff6435645abd");
    }
}