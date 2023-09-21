using System.IO;
using System.Text;
using common.Puzzles;

namespace Euler.Platform;

public abstract class EulerPuzzle : OnePartPuzzle
{
    protected sealed override string FilePath => GetFilePath(GetType());

    protected sealed override string GetFilePath(Type t)
    {
        var problemId = ProblemParser.GetProblemId(t);
        var paddedProblemId = problemId.ToString().PadLeft(3, '0');
        return Path.Combine(
            RootPath,
            "Problems",
            $"Problem{paddedProblemId}",
            $"Problem{paddedProblemId}.txt");
    }
}