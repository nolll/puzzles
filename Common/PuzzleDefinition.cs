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
        : this(
            type,
            instance.Tags,
            instance.SortId,
            instance.Title,
            instance.ListTitle,
            instance.Name,
            instance.Comment,
            instance.IsSlow,
            instance.NeedsRewrite,
            instance.IsFunToOptimize)
    {
        Instance = instance;
    }

    public PuzzleDefinition(
        Type type, 
        IEnumerable<string> tags, 
        string sortId, 
        string title, 
        string listTitle, 
        string name, 
        string? comment, 
        bool isSlow, 
        bool needsRewrite, 
        bool isFunToOptimize)
    {
        Type = type;
        Instance = null;
        Tags = tags;
        SortId = sortId;
        Title = title;
        ListTitle = listTitle;
        Name = name;
        Comment = comment;
        IsSlow = isSlow;
        NeedsRewrite = needsRewrite;
        IsFunToOptimize = isFunToOptimize;
    }
}