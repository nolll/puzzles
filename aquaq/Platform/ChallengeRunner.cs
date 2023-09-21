namespace AquaQ.Platform;

public class ChallengeRunner
{
    private readonly int _challengeTimeout;

    public ChallengeRunner(int challengeTimeout)
    {
        _challengeTimeout = challengeTimeout;
    }

    public void Run(IEnumerable<ChallengeWrapper> challenges)
    {
        var enumerable = challenges as ChallengeWrapper[] ?? challenges.ToArray();
        var count = enumerable.Length;

        if (count == 0)
            throw new Exception("No challenges found.");

        if (count == 1)
            new StandaloneSingleChallengeRunner(enumerable.First()).Run();
        else
            new MultiDayChallengeRunner(_challengeTimeout).Run(enumerable);
    }

    public void Run(ChallengeWrapper challenge)
    {
        Run(new List<ChallengeWrapper> { challenge });
    }
}