namespace AquaQ.Platform;

public class MissingChallengeResult : ChallengeResult
{
    public MissingChallengeResult(string message)
        : base(message, ChallengeResultStatus.Missing)
    {
    }
}