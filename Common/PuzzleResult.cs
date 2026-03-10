using System.Numerics;

namespace Pzl.Common;

public class PuzzleResult
{
    public PuzzleType Type { get; }
    public string? Hash { get; }
    public string Answer { get; }

    public static PuzzleResult Empty => new(PuzzleType.Empty, "No puzzle here");
    public static PuzzleResult Failed => new(PuzzleType.Default, "Failed");
    
    private PuzzleResult(PuzzleType type, string? answer, string? hash = null)
    {
        Type = type;
        Hash = hash;
        Answer = answer ?? string.Empty;
    }

    public PuzzleResult(string? answer) : this(PuzzleType.Default, answer){}
    public PuzzleResult(int? answer) : this(PuzzleType.Default, answer.ToString()){}
    public PuzzleResult(long? answer) : this(PuzzleType.Default, answer.ToString()){}
    
    public PuzzleResult(string? answer, string? hash) : this(PuzzleType.Default, answer, hash){}
    public PuzzleResult(int? answer, string? hash) : this(PuzzleType.Default, answer.ToString(), hash){}
    public PuzzleResult(long? answer, string? hash) : this(PuzzleType.Default, answer.ToString(), hash){}

    public static PuzzleResult Create(PuzzleType type, string? answer, string? hash) => new(type, answer, hash);
    public static PuzzleResult Create(string? answer, string? hash) => new(PuzzleType.Default, answer, hash);
    public static PuzzleResult Create(int? answer, string? hash) => Create(answer.ToString(), hash);
    public static PuzzleResult Create(long? answer, string? hash) => Create(answer.ToString(), hash);
    public static PuzzleResult Create(BigInteger? answer, string? hash) => Create(answer.ToString(), hash);
}