namespace Euler.Platform;

public class ProblemRunner
{
    private readonly int _problemTimeout;

    public ProblemRunner(int problemTimeout)
    {
        _problemTimeout = problemTimeout;
    }

    public void Run(IEnumerable<ProblemWrapper> problems)
    {
        var enumerable = problems as ProblemWrapper[] ?? problems.ToArray();
        var count = enumerable.Length;

        if (count == 0)
            throw new Exception("No problems found.");

        if (count == 1)
            new StandaloneSingleProblemRunner(enumerable.First()).Run();
        else
            new MultiDayProblemRunner(_problemTimeout).Run(enumerable);
    }

    public void Run(ProblemWrapper problem)
    {
        Run(new List<ProblemWrapper> { problem });
    }
}