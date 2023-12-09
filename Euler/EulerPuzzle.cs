using Pzl.Common;

namespace Pzl.Euler;

public abstract class EulerPuzzle : OnePartPuzzle
{
    private readonly string _id;

    public override string SortId { get; }
    public override string Title { get; }
    public override string ListTitle { get; }
    protected override string CollectionTag => "euler";

    protected EulerPuzzle()
    {
        _id = EulerPuzzleParser.GetPuzzleId(GetType()).ToString();
        var paddedId = _id.PadLeft(3, '0');
        SortId = paddedId;
        Title = $"Project Euler {_id}";
        ListTitle = $"Euler {paddedId}";
    }

    protected override IEnumerable<string> CustomTags
    {
        get
        {
            yield return _id;
        }
    }
}