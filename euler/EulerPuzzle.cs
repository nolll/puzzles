using System;
using System.IO;
using Common.Puzzles;

namespace Euler;

public abstract class EulerPuzzle : OnePartPuzzle
{
    private readonly string _paddedId;

    public override string Id { get; }
    public override string Title { get; }
    public override string ListTitle { get; }

    protected EulerPuzzle()
    {
        var id = EulerPuzzleParser.GetPuzzleId(GetType()).ToString();
        _paddedId = id.PadLeft(3, '0');
        Id = id;
        Title = $"Puzzle {id}";
        ListTitle = $"Puzzle {_paddedId}";
    }

    protected override string InputFilePath =>
        Path.Combine(
            "Puzzles",
            $"Euler{_paddedId}",
            $"Euler{_paddedId}.txt");
}