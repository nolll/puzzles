using Aoc.Platform;
using common.Puzzles;

namespace Aoc.Puzzles.Year2018.Day03;

public class Year2018Day03 : AocPuzzle
{
    public override string Name => "No Matter How You Slice It";

    public override PuzzleResult RunPart1()
    {
        var claimsOverlapCountPuzzle = new ClaimsOverlapCountPuzzle(FileInput);
        return new PuzzleResult(claimsOverlapCountPuzzle.OverlapCount, 118_223);
    }

    public override PuzzleResult RunPart2()
    {
        var claimThatDoesNotOverlap = new ClaimThatDoesNotOverlapPuzzle(FileInput);
        return new PuzzleResult(claimThatDoesNotOverlap.ClaimId, 412);
    }
}