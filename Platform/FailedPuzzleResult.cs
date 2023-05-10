namespace Aoc.Platform;

public class FailedPuzzleResult : PuzzleResult
{
    public FailedPuzzleResult(string message)
        : base(message, PuzzleResultStatus.Failed)
    {
    }
}