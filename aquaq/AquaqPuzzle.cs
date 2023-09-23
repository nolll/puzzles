using System.IO;
using Common.Puzzles;

namespace Aquaq;

public abstract class AquaqPuzzle : OnePartPuzzle
{
    private readonly string _paddedId;

    public override string Id { get; }
    public override string Title { get; }
    public override string ListTitle { get; }

    protected AquaqPuzzle()
    {
        var id = AquaqPuzzleParser.GetPuzzleId(GetType()).ToString();
        _paddedId = id.PadLeft(2, '0');
        Id = id;
        Title = $"Puzzle {id}";
        ListTitle = $"Puzzle {_paddedId}";
    }

    protected sealed override string GetInputFilePath(Type t) =>
        Path.Combine(
            "Puzzles",
            $"Aquaq{_paddedId}",
            $"Aquaq{_paddedId}.txt");
}