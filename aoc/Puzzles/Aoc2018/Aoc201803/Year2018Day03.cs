using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2018.Aoc201803;

public class Year2018Day03 : AocPuzzle
{
    public override string Name => "No Matter How You Slice It";

    protected override PuzzleResult RunPart1()
    {
        var claimsOverlapCountPuzzle = new ClaimsOverlapCountPuzzle(InputFile);
        return new PuzzleResult(claimsOverlapCountPuzzle.OverlapCount, 118_223);
    }

    protected override PuzzleResult RunPart2()
    {
        var claimThatDoesNotOverlap = new ClaimThatDoesNotOverlapPuzzle(InputFile);
        return new PuzzleResult(claimThatDoesNotOverlap.ClaimId, 412);
    }
}