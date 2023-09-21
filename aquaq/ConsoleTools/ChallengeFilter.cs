using AquaQ.Platform;
using common.Puzzles;

namespace AquaQ.ConsoleTools;

public class ChallengeFilter
{
    private readonly Parameters _parameters;

    public ChallengeFilter(Parameters parameters)
    {
        _parameters = parameters;
    }

    public IList<PuzzleWrapper> Filter(IList<PuzzleWrapper> challenges)
    {
        if (_parameters.RunSlowOnly)
            return challenges.Where(o => o.Puzzle.IsSlow).ToList();

        if (_parameters.RunCommentedOnly)
            return challenges.Where(o => !string.IsNullOrEmpty(o.Puzzle.Comment)).ToList();

        return challenges;
    }
}