using System.IO;
using Common.Puzzles;

namespace Aquaq;

public abstract class AquaqPuzzle : OnePartPuzzle
{
    protected sealed override string GetRelativeFilePath(Type t)
    {
        var id = AquaqPuzzleParser.GetPuzzleId(t);
        var paddedId = id.ToString().PadLeft(2, '0');
        return Path.Combine(
            "Puzzles",
            $"Aquaq{paddedId}",
            $"Aquaq{paddedId}.txt");
    }
}