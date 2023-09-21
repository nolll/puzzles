using System.IO;
using System.Text;
using common.Puzzles;

namespace AquaQ.Platform;

public abstract class AquaqPuzzle : OnePartPuzzle
{
    protected sealed override string GetFilePath(Type t)
    {
        var id = AquaqPuzzleParser.GetChallengeId(t);
        var paddedId = id.ToString().PadLeft(2, '0');
        return Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory,
            "Puzzles",
            $"Aquaq{paddedId}",
            $"Aquaq{paddedId}.txt");
    }
}