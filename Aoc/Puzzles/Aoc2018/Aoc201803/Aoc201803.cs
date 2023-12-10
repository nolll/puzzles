using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2018.Aoc201803;

[Name("No Matter How You Slice It")]
public class Aoc201803 : AocPuzzle
{
    protected override PuzzleResult RunPart1()
    {
        var claimsOverlapCountPuzzle = new ClaimsOverlapCountPuzzle(InputFile);
        return new PuzzleResult(claimsOverlapCountPuzzle.OverlapCount, "06a186fe1ad0ea2861a42fd9809e491e");
    }

    protected override PuzzleResult RunPart2()
    {
        var claimThatDoesNotOverlap = new ClaimThatDoesNotOverlapPuzzle(InputFile);
        return new PuzzleResult(claimThatDoesNotOverlap.ClaimId, "442af765a98dc2465a7db5a4e92167a4");
    }
}