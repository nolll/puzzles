using Pzl.Common;

namespace Pzl.Client.Running.Results;

public class VerifiedPuzzleResult
{
    public PuzzleResult Answer { get; }
    public string Hash { get; }
    public ResultStatus Status { get; }

    public VerifiedPuzzleResult(PuzzleResult answer, string hash, ResultStatus status)
    {
        Answer = answer;
        Hash = hash;
        Status = status;
    }

    public static VerifiedPuzzleResult Empty => new(PuzzleResult.Empty, string.Empty, ResultStatus.Missing);
    public static VerifiedPuzzleResult Failed => new(PuzzleResult.Failed, string.Empty, ResultStatus.Failed);
}