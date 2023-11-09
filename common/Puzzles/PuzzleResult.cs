using System.Numerics;

namespace Common.Puzzles;

public class PuzzleResult
{
    public PuzzleType Type { get; set; }
    public string? CorrectAnswer { get; }
    public string? CorrectAnswerHash { get; }
    public string Answer { get; }

    private PuzzleResult(string? answer)
        : this(answer, null)
    {
    }

    private PuzzleResult(PuzzleType type)
        : this(type, null)
    {
    }

    private PuzzleResult(PuzzleType type, string? answer)
        : this(type, answer, null, null)
    {
    }

    public PuzzleResult(string? answer, string? correctAnswer)
        : this(answer, correctAnswer, null)
    {
    }

    public PuzzleResult(string? answer, string? correctAnswer, string? correctAnswerHash)
        : this(PuzzleType.Default, answer, correctAnswer, correctAnswerHash)
    {
    }

    private PuzzleResult(PuzzleType type, string? answer, string? correctAnswer, string? correctAnswerHash)
    {
        Type = type;
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

    public static PuzzleResult Empty => new(PuzzleType.Empty, "No puzzle here");
    public static PuzzleResult Failed => new(PuzzleType.Default, "Failed");
}