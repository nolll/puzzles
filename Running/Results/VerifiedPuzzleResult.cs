using Pzl.Common;

namespace Pzl.Client.Running.Results;

public class VerifiedPuzzleResult
{
    public PuzzleResult Answer { get; }
    public string Hash { get; }
    public PuzzleResultStatus Status { get; }

    public VerifiedPuzzleResult(PuzzleResult answer, string hash, PuzzleResultStatus status)
    {
        Answer = answer;
        Hash = hash;
        Status = status;
    }

    public static VerifiedPuzzleResult Empty => new(PuzzleResult.Empty, string.Empty, PuzzleResultStatus.Missing);
    public static VerifiedPuzzleResult Failed => new(PuzzleResult.Failed, string.Empty, PuzzleResultStatus.Failed);
}