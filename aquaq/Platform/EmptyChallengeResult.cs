namespace AquaQ.Platform;

public class EmptyChallengeResult : ChallengeResult
{
    public EmptyChallengeResult()
        : base("No challenge here", ChallengeResultStatus.Empty)
    {
    }
}