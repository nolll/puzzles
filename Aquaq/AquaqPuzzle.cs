using Pzl.Common;

namespace Pzl.Aquaq;

public abstract class AquaqPuzzle : OnePartPuzzle
{
    private readonly string _id;

    public override string SortId { get; }
    public override string Title { get; }
    public override string ListTitle { get; }
    protected override string CollectionTag => "aquaq";

    protected AquaqPuzzle()
    {
        _id = AquaqPuzzleParser.GetPuzzleId(GetType()).ToString();
        var paddedId = _id.PadLeft(2, '0');
        SortId = paddedId;
        Title = $"AquaQ Challenge {_id}";
        ListTitle = $"AquaQ {paddedId}";
    }

    protected override IEnumerable<string> CustomTags
    {
        get
        {
            yield return _id;
        }
    }
}