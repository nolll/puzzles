using System;

namespace Pzl.Common;

public class PuzzleData(
    Type type,
    PuzzleType puzzleType,
    string name,
    string? comment,
    bool isSlow,
    bool needsRewrite,
    int numberOfParts,
    bool hasUniqueInputsPerPart)
{
    public Type Type { get; } = type;
    public PuzzleType PuzzleType { get; } = puzzleType;
    public string Name { get; } = name;
    public string? Comment { get; } = comment;
    public bool IsSlow { get; } = isSlow;
    public bool NeedsRewrite { get; } = needsRewrite;
    public int NumberOfParts { get; } = numberOfParts;
    public bool HasUniqueInputsPerPart { get; } = hasUniqueInputsPerPart;
}