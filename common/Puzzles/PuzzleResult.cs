using System.Numerics;
using Common.Cryptography;

namespace Common.Puzzles;

public class PuzzleResult
{
    public string Answer { get; }
    public PuzzleResultStatus Status { get; }

    public PuzzleResult(string? answer, string? correctAnswer = null, string? correctAnswerHash = null)
        : this(answer, VerifyResult(answer, correctAnswer, correctAnswerHash))
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

    private PuzzleResult(string? answer, PuzzleResultStatus status)
    {
        Answer = answer ?? string.Empty;
        Status = status;
    }

    public static PuzzleResult Empty => new("No puzzle here", PuzzleResultStatus.Empty);
    public static PuzzleResult Failed => new("Failed", PuzzleResultStatus.Failed);

    private static PuzzleResultStatus VerifyResult(string? answer, string? correctAnswer, string? correctAnswerHash)
    {
        if (answer is null)
            return PuzzleResultStatus.Wrong;

        if(correctAnswer is not null)
            return answer == correctAnswer
                ? PuzzleResultStatus.Correct
                : PuzzleResultStatus.Wrong;

        if(correctAnswerHash is not null)
            return new Hashfactory().StringHashFromString(answer) == correctAnswerHash
                ? PuzzleResultStatus.Correct
                : PuzzleResultStatus.Wrong;

        return PuzzleResultStatus.Completed;
    }
}