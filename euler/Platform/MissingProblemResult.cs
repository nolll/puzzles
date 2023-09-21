namespace Euler.Platform;

public class MissingProblemResult : ProblemResult
{
    public MissingProblemResult(string message)
        : base(message, ProblemResultStatus.Missing)
    {
    }
}