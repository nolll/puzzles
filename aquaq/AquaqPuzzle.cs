using Common.Puzzles;

namespace Aquaq;

public abstract class AquaqPuzzle : OnePartPuzzle
{
    public override string Id { get; }
    public override string SortId { get; }
    public override string Title { get; }
    public override string ListTitle { get; }

    protected AquaqPuzzle()
    {
        var id = AquaqPuzzleParser.GetPuzzleId(GetType()).ToString();
        var paddedId = id.PadLeft(2, '0');
        Id = id;
        SortId = paddedId;
        Title = $"Puzzle {id}";
        ListTitle = $"Puzzle {paddedId}";
    }
}