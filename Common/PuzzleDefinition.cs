using System;
using System.Collections.Generic;

namespace Pzl.Common;

public class PuzzleDefinition(
    Type type,
    IEnumerable<string> tags,
    string sortId,
    string title,
    string listTitle,
    string name,
    string? comment,
    int numberOfParts,
    bool hasUniqueInputsPerPart)
{
    public Type Type { get; } = type;
    public IEnumerable<string> Tags { get; } = tags;
    public string SortId { get; } = sortId;
    public string Title { get; } = title;
    public string ListTitle { get; } = listTitle;
    public string Name { get; } = name;
    public string? Comment { get; } = comment;
    public int NumberOfParts { get; } = numberOfParts;
    public bool HasUniqueInputsPerPart { get; } = hasUniqueInputsPerPart;

    public PuzzleDefinition(
        PuzzleData data, 
        List<string> tags,
        string sortId,
        string title,
        string listTitle)
        : this(
            data.Type,
            [..tags, ..CreateTags(data)],
            sortId,
            title,
            listTitle,
            data.Name,
            data.Comment,
            data.NumberOfParts,
            data.HasUniqueInputsPerPart)
    {
    }

    private static IEnumerable<string> CreateTags(PuzzleData data)
    {
        if (data.Comment is not null)
            yield return PuzzleTag.Commented; 
        
        if (data.IsSlow)
            yield return PuzzleTag.Slow;

        if (data.NeedsRewrite)
            yield return PuzzleTag.Rewrite;

        if (data.IsFunToOptimize)
            yield return PuzzleTag.Fun;
    }
}