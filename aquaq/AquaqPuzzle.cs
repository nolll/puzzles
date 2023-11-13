using Puzzles.common.Puzzles;

namespace Puzzles.aquaq;

public abstract class AquaqPuzzle : OnePartPuzzle
{
    public override string Id { get; }
    public override string SortId { get; }
    public override string Title { get; }
    public override string ListTitle { get; }
    protected override string CollectionTag => PuzzleTag.Aquaq;

    protected AquaqPuzzle()
    {
        var id = AquaqPuzzleParser.GetPuzzleId(GetType()).ToString();
        var paddedId = id.PadLeft(2, '0');
        Id = id;
        SortId = paddedId;
        Title = $"AquaQ Challenge {id}";
        ListTitle = $"{PuzzleTag.Aquaq} {paddedId}";
    }

    protected override IEnumerable<string> CustomTags
    {
        get
        {
            yield return Id;
        }
    }
}