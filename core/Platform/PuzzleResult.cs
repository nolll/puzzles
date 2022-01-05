using System.Numerics;

namespace App.Platform;

public class PuzzleResult
{
    public string Answer { get; }
    public string CorrectAnswer { get; }
    public PuzzleResultStatus Status { get; }

    public PuzzleResult(string answer, string correctAnswer = null)
        : this(answer, correctAnswer, VerifyResult(answer, correctAnswer))
    {
            
    }

    public PuzzleResult(int? answer, int? correctAnswer = null)
        : this(answer?.ToString(), correctAnswer?.ToString())
    {
    }

    public PuzzleResult(long? answer, long? correctAnswer = null)
        : this(answer?.ToString(), correctAnswer?.ToString())
    {
    }

    public PuzzleResult(BigInteger? answer, BigInteger? correctAnswer = null)
        : this(answer?.ToString(), correctAnswer?.ToString())
    {
    }

    protected PuzzleResult(string answer, PuzzleResultStatus status)
        : this(answer, null, status)
    {
    }

    protected PuzzleResult(string answer, string correctAnswer, PuzzleResultStatus status)
    {
        Answer = answer;
        CorrectAnswer = correctAnswer;
        Status = status;
    }

    private static PuzzleResultStatus VerifyResult(string answer, string correctAnswer)
    {
        if (answer == null)
            return PuzzleResultStatus.Wrong;

        if (correctAnswer == null)
            return PuzzleResultStatus.Completed;

        return answer == correctAnswer
            ? PuzzleResultStatus.Correct
            : PuzzleResultStatus.Wrong;
    }
}