using System.Numerics;

namespace Pzl.Common;

public class PuzzleResult
{
    public PuzzleType Type { get; }
    public string? Hash { get; }
    public string Answer { get; }

    public static PuzzleResult Empty => new(PuzzleType.Empty, "No puzzle here");
    public static PuzzleResult Failed => new(PuzzleType.Default, "Failed");

    public PuzzleResult(string? answer, string? hash = null)
        : this(PuzzleType.Default, answer, hash)
    {
    }

    public PuzzleResult(int? answer, string? hash = null)
        : this(answer?.ToString(), hash)
    {
    }

    public PuzzleResult(long? answer, string? hash = null)
        : this(answer?.ToString(), hash)
    {
    }

    public PuzzleResult(BigInteger? answer, string? hash = null)
        : this(answer?.ToString(), hash)
    {
    }

    private PuzzleResult(PuzzleType type, string? answer, string? hash = null)
    {
        Type = type;
        Answer = answer ?? string.Empty;
        Hash = hash;
    }
}