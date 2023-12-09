using System;
using System.Collections.Generic;

namespace Pzl.Common;

public class PuzzleDefinition
{
    public Type Type { get; }
    public Puzzle Instance { get; }
    public IEnumerable<string> Tags { get; }
    public string SortId { get; }
    public string Title { get; }
    public string ListTitle { get; }
    public string Name { get; }
    public string? Comment { get; }
    public bool IsSlow { get; }
    public bool NeedsRewrite { get; }
    public bool IsFunToOptimize { get; }

    public PuzzleDefinition(Type type, Puzzle instance)
    {
        Type = type;
        Instance = instance;
        Tags = instance.Tags;
        SortId = instance.SortId;
        Title = instance.Title;
        ListTitle = instance.ListTitle;
        Name = instance.Name;
        Comment = instance.Comment;
        IsSlow = instance.IsSlow;
        NeedsRewrite = instance.NeedsRewrite;
        IsFunToOptimize = instance.IsFunToOptimize;
    }
}