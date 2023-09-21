namespace AquaQ.Platform;

public class ChallengeWrapper
{
    public int Id { get; }
    public AquaQPuzzle Challenge { get; }

    public ChallengeWrapper(int id, AquaQPuzzle challenge)
    {
        Id = id;
        Challenge = challenge;
    }
}