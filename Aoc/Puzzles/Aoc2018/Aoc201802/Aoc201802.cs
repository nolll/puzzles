using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2018.Aoc201802;

[Name("Inventory Management System")]
public class Aoc201802 : AocPuzzle
{
    public PuzzleResult RunPart1(string input)
    {
        var boxChecksumPuzzle = new BoxChecksumPuzzle(input);
        return new PuzzleResult(boxChecksumPuzzle.Checksum, "e7ee8e8967be0ed8c2fe23ef3e7d765e");
    }

    public PuzzleResult RunPart2(string input)
    {
        var similarIdsPuzzle = new SimilarIdsPuzzle(input);
        return new PuzzleResult(similarIdsPuzzle.CommonLetters, "dec3acac891412bfec2fff6435645abd");
    }
}