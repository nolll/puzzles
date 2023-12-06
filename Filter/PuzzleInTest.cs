using Pzl.Common;

namespace Pzl.Client.Filter;

public class PuzzleInTest : Puzzle
{
    public override string Id { get; }
    public override string SortId { get; }
    public override string Title { get; }
    public override string ListTitle { get; }
    public override string Name { get; }
    protected override string CollectionTag { get; }
    public override IList<Func<PuzzleResult>> RunFunctions => new List<Func<PuzzleResult>>();

    public PuzzleInTest(
        string? id = null, 
        string? sortId = null,
        string? title = null, 
        string? listTitle = null, 
        string? name = null,
        string? collectionTag = null)
    {
        Id = id ?? string.Empty;
        SortId = sortId ?? string.Empty;
        Title = title ?? string.Empty;
        ListTitle = listTitle ?? string.Empty;
        Name = name ?? string.Empty;
        CollectionTag = collectionTag ?? string.Empty;
    }
}