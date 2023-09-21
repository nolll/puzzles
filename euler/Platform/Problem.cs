using System.IO;
using System.Text;

namespace Euler.Platform;

public abstract class Problem
{
    public abstract string Name { get; }
    public virtual string? Comment => null;
    public virtual bool IsSlow => false;
    public virtual bool NeedsRewrite => false;

    public abstract ProblemResult Run();

    protected string FileInput
    {
        get
        {
            var filePath = FilePath;
            if (!File.Exists(filePath))
                throw new FileNotFoundException("File not found", filePath);

            return File.ReadAllText(filePath, Encoding.UTF8);
        }
    }

    private string FilePath
    {
        get
        {
            var type = GetType();
            var problemId = ProblemParser.ParseType(type);
            var paddedProblemId = problemId.ToString().PadLeft(3, '0');
            return Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "Problems",
                $"Problem{paddedProblemId}",
                $"Problem{paddedProblemId}.txt");
        }
    }
}