using System;

namespace Pzl.Common;

public class PuzzleData
{
    public Type Type { get; }
    public string Name { get; }
    public string? Comment { get; }
    public bool IsSlow { get; }
    public bool NeedsRewrite { get; }
    public bool IsFunToOptimize { get; }
    public int NumberOfParts { get; }
    public bool HasUniqueInputsPerPart { get; }

    public PuzzleData(
        Type type, 
        string name, 
        string? comment, 
        bool isSlow, 
        bool needsRewrite, 
        bool isFunToOptimize,
        int numberOfParts,
        bool hasUniqueInputsPerPart)
    {
        Type = type;
        Name = name;
        Comment = comment;
        IsSlow = isSlow;
        NeedsRewrite = needsRewrite;
        IsFunToOptimize = isFunToOptimize;
        NumberOfParts = numberOfParts;
        HasUniqueInputsPerPart = hasUniqueInputsPerPart;
    }
}