using System.IO;
using System.Text;
using common.Puzzles;

namespace Euler.Platform;

public abstract class EulerPuzzle : OnePartPuzzle
{
    protected sealed override string GetFilePath(Type t)
    {
        var id = EulerPuzzleParser.GetProblemId(t);
        var paddedId = id.ToString().PadLeft(3, '0');
        return Path.Combine(
            RootPath,
            "Problems",
            $"Problem{paddedId}",
            $"Problem{paddedId}.txt");
    }
}