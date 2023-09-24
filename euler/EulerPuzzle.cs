using Common.Puzzles;

namespace Euler;

public abstract class EulerPuzzle : OnePartPuzzle
{
    public override string Id { get; }
    public override string SortId { get; }
    public override string Title { get; }
    public override string ListTitle { get; }

    protected EulerPuzzle()
    {
        var id = EulerPuzzleParser.GetPuzzleId(GetType()).ToString();
        var paddedId = id.PadLeft(3, '0');
        Id = id;
        SortId = paddedId;
        Title = $"Puzzle {id}";
        ListTitle = $"Puzzle {paddedId}";
    }
}