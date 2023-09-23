using System.Text;

namespace Common.Puzzles;

public abstract class Puzzle
{
    public abstract string Id { get; }
    public abstract string Title { get; }
    public abstract string ListTitle { get; }
    public abstract string Name { get; }
    public virtual string? Comment => null;
    public virtual bool IsSlow => false;
    public virtual bool NeedsRewrite => false;
    public virtual bool IsFunToOptimize => false;

    protected string InputFile
    {
        get
        {
            var filePath = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                InputFilePath);

            if (!File.Exists(filePath))
                throw new FileNotFoundException("File not found", filePath);

            return File.ReadAllText(filePath, Encoding.UTF8);
        }
    }

    public abstract IList<Func<PuzzleResult>> RunFunctions { get; }

    protected abstract string InputFilePath { get; }

    public virtual IEnumerable<string> GetTags()
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