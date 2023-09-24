namespace Common.Puzzles;

public class PuzzleInTest : Puzzle
{
    public override string Id { get; }
    public override string SortId { get; }
    public override string Title { get; }
    public override string ListTitle { get; }
    public override string Name { get; }
    public override IList<Func<PuzzleResult>> RunFunctions => new List<Func<PuzzleResult>>();

    public PuzzleInTest(
        string? id = null, 
        string? sortId = null,
        string? title = null, 
        string? listTitle = null, 
        string? name = null)
    {
        Id = id ?? string.Empty;
        SortId = sortId ?? string.Empty;
        Title = title ?? string.Empty;
        ListTitle = listTitle ?? string.Empty;
        Name = name ?? string.Empty;
    }
}

public class CommentedPuzzleInTest : PuzzleInTest
{
    public override string Name => "Commented Puzzle";
    public override string Comment => "Comment";
}

public class SlowPuzzleInTest : PuzzleInTest
{
    public override string Name => "Slow Puzzle";
    public override bool IsSlow => true;
}

public class FunPuzzleInTest : PuzzleInTest
{
    public override string Name => "Fun Puzzle";
    public override bool IsFunToOptimize => true;
}

public class PlainPuzzleInTest : PuzzleInTest
{
    public override string Name => "Plain Puzzle";
}