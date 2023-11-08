using System.Numerics;
using Common.Cryptography;

namespace Common.Puzzles;

public class PuzzleResult
{
    public string? CorrectAnswer { get; }
    public string? CorrectAnswerHash { get; }
    public string Answer { get; }
    public string Hash { get; }

    public PuzzleResult(string? answer, string? correctAnswer = null, string? correctAnswerHash = null)
    {
        CorrectAnswer = correctAnswer;
        CorrectAnswerHash = correctAnswerHash;
        Answer = answer ?? string.Empty;
        Hash = new Hashfactory().StringHashFromString(Answer);
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

    private PuzzleResult(string? answer)
    {
        Answer = answer ?? string.Empty;
        Hash = string.Empty;
    }

    public static PuzzleResult Empty => new("No puzzle here");
    public static PuzzleResult Failed => new("Failed");
}