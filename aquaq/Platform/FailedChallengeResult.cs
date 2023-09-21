namespace AquaQ.Platform;

public class FailedChallengeResult : ChallengeResult
{
    public FailedChallengeResult(string message)
        : base(message, ChallengeResultStatus.Failed)
    {
    }
}