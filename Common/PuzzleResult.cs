using System.Numerics;

namespace Pzl.Common;

public class PuzzleResult(PuzzleType type, string? answer, string? hash = null)
{
    public PuzzleType Type { get; } = type;
    public string? Hash { get; } = hash;
    public string Answer { get; } = answer ?? string.Empty;

    public static PuzzleResult Empty => new(PuzzleType.Empty, "No puzzle here");
    public static PuzzleResult Failed => new(PuzzleType.Default, "Failed");

    public PuzzleResult(string? answer, string? hash = null) : this(PuzzleType.Default, answer, hash) {}
    public PuzzleResult(int? answer, string? hash = null) : this(answer?.ToString(), hash) {}
    public PuzzleResult(long? answer, string? hash = null) : this(answer?.ToString(), hash) {}
    public PuzzleResult(BigInteger? answer, string? hash = null) : this(answer?.ToString(), hash) {}
}