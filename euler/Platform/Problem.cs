using System.IO;
using System.Text;
using common.Puzzles;

namespace Euler.Platform;

public abstract class Problem : Puzzle
{
    public abstract string Name { get; }
    public virtual string? Comment => null;
    public virtual bool IsSlow => false;
    public virtual bool NeedsRewrite => false;

    public abstract ProblemResult Run();

    protected sealed override string FilePath
    {
        get
        {
            var type = GetType();
            var problemId = ProblemParser.GetProblemId(type);
            var paddedProblemId = problemId.ToString().PadLeft(3, '0');
            return Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "Problems",
                $"Problem{paddedProblemId}",
                $"Problem{paddedProblemId}.txt");
        }
    }
}