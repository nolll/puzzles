using System.Text;

namespace Common.Puzzles;

public abstract class Puzzle
{
    public abstract string Name { get; }
    public virtual string? Comment => null;
    public virtual bool IsSlow => false;
    public virtual bool NeedsRewrite => false;
    public virtual bool IsFunToOptimize => false;

    protected string InputFile
    {
        get
        {
            var filePath = InputFilePath;
            if (!File.Exists(filePath))
                throw new FileNotFoundException("File not found", filePath);

            return File.ReadAllText(filePath, Encoding.UTF8);
        }
    }

    public abstract IList<Func<PuzzleResult>> RunFunctions { get; }

    protected virtual string InputFilePath =>
        Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory,
            GetInputFilePath(GetType()));

    protected abstract string GetInputFilePath(Type t);

    public IEnumerable<string> GetTags()
    {
        if (!string.IsNullOrEmpty(Comment))
            yield return PuzzleTag.Commented;

        if (IsSlow)
            yield return PuzzleTag.Slow;

        if (NeedsRewrite)
            yield return PuzzleTag.Rewrite;

        if (IsFunToOptimize)
            yield return PuzzleTag.Fun;
    }
}