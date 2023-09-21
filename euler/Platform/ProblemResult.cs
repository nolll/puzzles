namespace Euler.Platform;

public class ProblemResult
{
    public string? Answer { get; }
    public string? CorrectAnswer { get; }
    public ProblemResultStatus Status { get; }

    public ProblemResult(string? answer, string? correctAnswer = null)
        : this(answer, correctAnswer, VerifyResult(answer, correctAnswer))
    {
            
    }

    public ProblemResult(int? answer, int? correctAnswer = null)
        : this(answer?.ToString(), correctAnswer?.ToString())
    {
    }

    public ProblemResult(long? answer, long? correctAnswer = null)
        : this(answer?.ToString(), correctAnswer?.ToString())
    {
    }

    protected ProblemResult(string answer, ProblemResultStatus status)
        : this(answer, null, status)
    {
    }

    protected ProblemResult(string? answer, string? correctAnswer, ProblemResultStatus status)
    {
        Answer = answer;
        CorrectAnswer = correctAnswer;
        Status = status;
    }

    private static ProblemResultStatus VerifyResult(string? answer, string? correctAnswer)
    {
        if (answer == null)
            return ProblemResultStatus.Wrong;

        if (correctAnswer == null)
            return ProblemResultStatus.Completed;

        return answer == correctAnswer
            ? ProblemResultStatus.Correct
            : ProblemResultStatus.Wrong;
    }
}