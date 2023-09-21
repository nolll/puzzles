namespace Euler.Platform;

public class TimedProblemResult : ProblemResult
{
    public TimeSpan TimeTaken { get; }

    public TimedProblemResult(ProblemResult result, TimeSpan timeTaken)
        : base(result.Answer, result.CorrectAnswer, result.Status)
    {
        TimeTaken = timeTaken;
    }
}