using Pzl.Common;

namespace Pzl.Client.Running.Results;

public class VerifiedPuzzleResult(PuzzleResult answer, string hash, ResultStatus status)
{
    public PuzzleResult Answer { get; } = answer;
    public string Hash { get; } = hash;
    public ResultStatus Status { get; } = status;

    public static VerifiedPuzzleResult Empty => new(PuzzleResult.Empty, string.Empty, ResultStatus.Missing);
    public static VerifiedPuzzleResult Failed => new(PuzzleResult.Failed, string.Empty, ResultStatus.Failed);
}