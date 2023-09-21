using AquaQ.Platform;

namespace AquaQ.ConsoleTools;

public class ChallengeFilter
{
    private readonly Parameters _parameters;

    public ChallengeFilter(Parameters parameters)
    {
        _parameters = parameters;
    }

    public IList<ChallengeWrapper> Filter(IList<ChallengeWrapper> challenges)
    {
        if (_parameters.RunSlowOnly)
            return challenges.Where(o => o.Challenge.IsSlow).ToList();

        if (_parameters.RunCommentedOnly)
            return challenges.Where(o => !string.IsNullOrEmpty(o.Challenge.Comment)).ToList();

        return challenges;
    }
}