namespace AquaQ.Platform;

public class ChallengeWrapper
{
    public int Id { get; }
    public Challenge Challenge { get; }

    public ChallengeWrapper(int id, Challenge challenge)
    {
        Id = id;
        Challenge = challenge;
    }
}