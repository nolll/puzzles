namespace Common.Puzzles;

public class VerifiedPuzzleResult
{
    public PuzzleResult Answer { get; }
    public PuzzleResultStatus Status { get; }

    public VerifiedPuzzleResult(PuzzleResult answer, PuzzleResultStatus status)
    {
        Answer = answer;
        Status = status;
    }

    public static VerifiedPuzzleResult Empty => new(PuzzleResult.Empty, PuzzleResultStatus.Empty);
    public static VerifiedPuzzleResult Failed => new(PuzzleResult.Failed, PuzzleResultStatus.Failed);
}