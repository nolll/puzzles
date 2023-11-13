namespace Puzzles.aoc.Puzzles.Aoc2018.Aoc201803;

public class OverlappingClaimNotFoundException : Exception
{
    public OverlappingClaimNotFoundException()
        : base("No overlapping claim was found")
    {
    }
}