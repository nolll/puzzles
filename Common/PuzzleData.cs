using System;

namespace Pzl.Common;

public class PuzzleData
{
    public Type Type { get; }
    public string? Comment { get; }
    public bool IsSlow { get; }
    public bool NeedsRewrite { get; }
    public bool IsFunToOptimize { get; }

    public PuzzleData(Type type, string? comment, bool isSlow, bool needsRewrite, bool isFunToOptimize)
    {
        Type = type;
        Comment = comment;
        IsSlow = isSlow;
        NeedsRewrite = needsRewrite;
        IsFunToOptimize = isFunToOptimize;
    }
}