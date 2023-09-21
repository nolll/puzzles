namespace AquaQ.Platform;

public class TimeoutChallengeResult : ChallengeResult
{
    public TimeoutChallengeResult(string message)
        : base(message, ChallengeResultStatus.Timeout)
    {
    }
}