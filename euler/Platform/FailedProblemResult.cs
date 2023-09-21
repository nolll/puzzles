namespace Euler.Platform;

public class FailedProblemResult : ProblemResult
{
    public FailedProblemResult(string message)
        : base(message, ProblemResultStatus.Failed)
    {
    }
}