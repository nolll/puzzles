using System.Numerics;

namespace Pzl.Common;

public class PuzzleResult
{
    public PuzzleResultType ResultType { get; }
    public string? Hash { get; }
    public string Answer { get; }
    
    private PuzzleResult(PuzzleResultType resultType, string? answer, string? hash = null)
    {
        ResultType = resultType;
        Hash = hash;
        Answer = answer ?? string.Empty;
    }
    
    public static PuzzleResult Empty => new(PuzzleResultType.Empty, "No puzzle here");
    public static PuzzleResult Failed => new(PuzzleResultType.Default, "Failed");

    public static PuzzleResult Create(PuzzleResultType resultType, string? answer, string? hash) => new(resultType, answer, hash);
    public static PuzzleResult Create(string? answer, string? hash) => new(PuzzleResultType.Default, answer, hash);
    public static PuzzleResult Create(int? answer, string? hash) => Create(answer.ToString(), hash);
    public static PuzzleResult Create(long? answer, string? hash) => Create(answer.ToString(), hash);
    public static PuzzleResult Create(BigInteger? answer, string? hash) => Create(answer.ToString(), hash);
}