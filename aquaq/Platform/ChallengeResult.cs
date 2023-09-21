namespace AquaQ.Platform;

public class ChallengeResult
{
    public string? Answer { get; }
    public string? CorrectAnswer { get; }
    public ChallengeResultStatus Status { get; }

    public ChallengeResult(string? answer, string? correctAnswer = null)
        : this(answer, correctAnswer, VerifyResult(answer, correctAnswer))
    {
            
    }

    public ChallengeResult(int? answer, int? correctAnswer = null)
        : this(answer?.ToString(), correctAnswer?.ToString())
    {
    }

    public ChallengeResult(long? answer, long? correctAnswer = null)
        : this(answer?.ToString(), correctAnswer?.ToString())
    {
    }

    protected ChallengeResult(string answer, ChallengeResultStatus status)
        : this(answer, null, status)
    {
    }

    protected ChallengeResult(string? answer, string? correctAnswer, ChallengeResultStatus status)
    {
        Answer = answer;
        CorrectAnswer = correctAnswer;
        Status = status;
    }

    private static ChallengeResultStatus VerifyResult(string? answer, string? correctAnswer)
    {
        if (answer == null)
            return ChallengeResultStatus.Wrong;

        if (correctAnswer == null)
            return ChallengeResultStatus.Completed;

        return answer == correctAnswer
            ? ChallengeResultStatus.Correct
            : ChallengeResultStatus.Wrong;
    }
}