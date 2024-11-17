using System;
using System.Collections.Generic;

namespace Pzl.Common;

public class PuzzleDefinition
{
    public Type Type { get; }
    public IEnumerable<string> Tags { get; }
    public string SortId { get; }
    public string Title { get; }
    public string ListTitle { get; }
    public string Name { get; }
    public string? Comment { get; }
    public int NumberOfParts { get; }
    public bool HasUniqueInputsPerPart { get; }
    public string? CommonFile { get; }
    public string? LocalFile { get; }

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
            data.HasUniqueInputsPerPart,
            data.CommonFile,
            data.LocalFile)
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

    public PuzzleDefinition(
        Type type, 
        IEnumerable<string> tags, 
        string sortId, 
        string title, 
        string listTitle, 
        string name, 
        string? comment, 
        int numberOfParts,
        bool hasUniqueInputsPerPart,
        string? commonFile,
        string? localFile)
    {
        Type = type;
        Tags = tags;
        SortId = sortId;
        Title = title;
        ListTitle = listTitle;
        Name = name;
        Comment = comment;
        NumberOfParts = numberOfParts;
        HasUniqueInputsPerPart = hasUniqueInputsPerPart;
        CommonFile = commonFile;
        LocalFile = localFile;
    }
}