using common.Puzzles;
using Euler.Platform;

namespace Euler.ConsoleTools;

public class ProblemFilter
{
    private readonly Parameters _parameters;

    public ProblemFilter(Parameters parameters)
    {
        _parameters = parameters;
    }

    public IList<PuzzleWrapper> Filter(IList<PuzzleWrapper> problems)
    {
        if (_parameters.RunSlowOnly)
            return problems.Where(o => o.Puzzle.IsSlow).ToList();

        if (_parameters.RunCommentedOnly)
            return problems.Where(o => !string.IsNullOrEmpty(o.Puzzle.Comment)).ToList();

        return problems;
    }
}