using System.Numerics;

namespace Puzzles.Common.Puzzles;

public class PuzzleResult
{
    public PuzzleType Type { get; }
    public string? CheckHash { get; }
    public string Answer { get; }

    public static PuzzleResult Empty => new(PuzzleType.Empty, "No puzzle here");
    public static PuzzleResult Failed => new(PuzzleType.Default, "Failed");

    public PuzzleResult(string? answer, string? checkHash = null)
        : this(PuzzleType.Default, answer, checkHash)
    {
    }

    public PuzzleResult(int? answer, string? checkHash = null)
        : this(answer?.ToString(), checkHash)
    {
    }

    public PuzzleResult(long? answer, string? checkHash = null)
        : this(answer?.ToString(), checkHash)
    {
    }

    public PuzzleResult(BigInteger? answer, string? checkHash = null)
        : this(answer?.ToString(), checkHash)
    {
    }

    private PuzzleResult(PuzzleType type, string? answer, string? checkHash = null)
    {
        Type = type;
        Answer = answer ?? string.Empty;
        CheckHash = checkHash;
    }
}