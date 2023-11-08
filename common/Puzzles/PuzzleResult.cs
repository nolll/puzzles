using System.Numerics;

namespace Common.Puzzles;

public class PuzzleResult
{
    public string? CorrectAnswer { get; }
    public string? CorrectAnswerHash { get; }
    public string Answer { get; }

    private PuzzleResult(string? answer)
        : this(answer, null)
    {
    }

    public PuzzleResult(string? answer, string? correctAnswer)
        : this(answer, correctAnswer, null)
    {
    }

    public PuzzleResult(string? answer, string? correctAnswer, string? correctAnswerHash)
    {
        CorrectAnswer = correctAnswer;
        CorrectAnswerHash = correctAnswerHash;
        Answer = answer ?? string.Empty;
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

    public static PuzzleResult Empty => new("No puzzle here");
    public static PuzzleResult Failed => new("Failed");
}