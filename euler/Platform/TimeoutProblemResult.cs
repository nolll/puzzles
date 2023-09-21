namespace Euler.Platform;

public class TimeoutProblemResult : ProblemResult
{
    public TimeoutProblemResult(string message)
        : base(message, ProblemResultStatus.Timeout)
    {
    }
}