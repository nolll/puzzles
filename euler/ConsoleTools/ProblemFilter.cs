using Euler.Platform;

namespace Euler.ConsoleTools;

public class ProblemFilter
{
    private readonly Parameters _parameters;

    public ProblemFilter(Parameters parameters)
    {
        _parameters = parameters;
    }

    public IList<ProblemWrapper> Filter(IList<ProblemWrapper> problems)
    {
        if (_parameters.RunSlowOnly)
            return problems.Where(o => o.Problem.IsSlow).ToList();

        if (_parameters.RunCommentedOnly)
            return problems.Where(o => !string.IsNullOrEmpty(o.Problem.Comment)).ToList();

        return problems;
    }
}