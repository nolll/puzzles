using System;

namespace Pzl.Common;

public class PuzzleData(
    Type type,
    string name,
    string? comment,
    bool isSlow,
    bool needsRewrite,
    bool isFunToOptimize,
    int numberOfParts,
    bool hasUniqueInputsPerPart)
{
    public Type Type { get; } = type;
    public string Name { get; } = name;
    public string? Comment { get; } = comment;
    public bool IsSlow { get; } = isSlow;
    public bool NeedsRewrite { get; } = needsRewrite;
    public bool IsFunToOptimize { get; } = isFunToOptimize;
    public int NumberOfParts { get; } = numberOfParts;
    public bool HasUniqueInputsPerPart { get; } = hasUniqueInputsPerPart;
}