using System;

namespace Pzl.Common;

public class PuzzleData
{
    public Type Type { get; }
    public bool IsSlow { get; }
    public string? Comment { get; }

    public PuzzleData(Type type, bool isSlow, string? comment)
    {
        Type = type;
        IsSlow = isSlow;
        Comment = comment;
    }
}