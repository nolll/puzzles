using System.IO;
using Puzzles.Common.Files;

namespace Puzzles.Common.Puzzles;

public abstract class Puzzle
{
    public abstract string Id { get; }
    public abstract string SortId { get; }
    public abstract string Title { get; }
    public abstract string ListTitle { get; }
    public abstract string Name { get; }
    public virtual string? Comment => null;
    public virtual bool IsSlow => false;
    public virtual bool NeedsRewrite => false;
    public virtual bool IsFunToOptimize => false;

    protected string InputFile => FileReader.ReadTextFile(InputFilePath);
    protected string TextFile(string fileName) => ReadLocalFile(fileName);
    protected string CommonTextFile(string fileName) => ReadCommonFile(fileName);
    protected abstract string CollectionTag { get; }

    protected string PuzzlePath => Path.Combine(PuzzlePathParts);

    private string ReadLocalFile(string fileName)
    {
        var parts = PuzzlePathParts.SkipLast(1).ToList();
        parts.Add(fileName);
        var filePath = Path.Combine(parts.ToArray());
        return FileReader.ReadTextFile(filePath);
    }

    private string ReadCommonFile(string fileName)
    {
        var parts = new List<string>
        {
            CollectionTag,
            "CommonInputFiles",
            fileName
        };
        var filePath = Path.Combine(parts.ToArray());
        return FileReader.ReadTextFile(filePath);
    }

    private string[] PuzzlePathParts => GetType()
        .FullName!
        .Split('.')
        .Skip(1)
        .ToArray();

    public abstract IList<Func<PuzzleResult>> RunFunctions { get; }

    private string InputFilePath => $"{PuzzlePath}.txt";

    public IEnumerable<string> Tags
    {
        get
        {
            yield return CollectionTag;

            foreach (var customTag in CustomTags)
            {
                yield return customTag;
            }

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

    protected virtual IEnumerable<string> CustomTags => Enumerable.Empty<string>();
}