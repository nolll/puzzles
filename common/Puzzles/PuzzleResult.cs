using System.Numerics;
using Common.Cryptography;

namespace Common.Puzzles;

public class PuzzleResult
{
    public string Answer { get; }
    public string Hash { get; }
    public PuzzleResultStatus Status { get; }

    public PuzzleResult(string? answer, string? correctAnswer = null, string? correctAnswerHash = null)
    {
        Answer = answer ?? string.Empty;
        Hash = new Hashfactory().StringHashFromString(Answer);
        Status = VerifyResult(answer, Hash, correctAnswer, correctAnswerHash);
    }

    public PuzzleResult(int? answer, int? correctAnswer = null)
        : this(answer?.ToString(), correctAnswer?.ToString())
    {
    }

    public PuzzleResult(int? answer, string? correctAnswerHash = null)
        : this(answer?.ToString(), null, correctAnswerHash)
    {
    }

    public PuzzleResult(long? answer, long? correctAnswer = null)
        : this(answer?.ToString(), correctAnswer?.ToString())
    {
    }

    public PuzzleResult(long? answer, string? correctAnswerHash = null)
        : this(answer?.ToString(), null, correctAnswerHash)
    {
    }

    public PuzzleResult(BigInteger? answer, BigInteger? correctAnswer = null)
        : this(answer?.ToString(), correctAnswer?.ToString())
    {
    }

    public PuzzleResult(BigInteger? answer, string? correctAnswerHash = null)
        : this(answer?.ToString(), null, correctAnswerHash)
    {
    }

    private PuzzleResult(string? answer, PuzzleResultStatus status)
    {
        Answer = answer ?? string.Empty;
        Hash = string.Empty;
        Status = status;
    }

    public static PuzzleResult Empty => new("No puzzle here", PuzzleResultStatus.Empty);
    public static PuzzleResult Failed => new("Failed", PuzzleResultStatus.Failed);

    private static PuzzleResultStatus VerifyResult(string? answer, string answerHash, string? correctAnswer, string? correctAnswerHash)
    {
        if (answer is null)
            return PuzzleResultStatus.Wrong;

        if(correctAnswer is not null)
            return answer == correctAnswer
                ? PuzzleResultStatus.Correct
                : PuzzleResultStatus.Wrong;

        if(correctAnswerHash is not null)
            return answerHash == correctAnswerHash
                ? PuzzleResultStatus.Correct
                : PuzzleResultStatus.Wrong;

        return PuzzleResultStatus.Completed;
    }
}