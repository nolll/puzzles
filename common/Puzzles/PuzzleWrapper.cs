namespace Common.Puzzles;

public class PuzzleWrapper
{
    public string Id { get; }
    public string Title { get; }
    public string ListTitle { get; }
    public List<string> Tags { get; }
    public Puzzle Puzzle { get; }

    public PuzzleWrapper(string id, string title, string listTitle, List<string>? tags, Puzzle puzzle)
    {
        Id = id;
        Title = title;
        ListTitle = listTitle;
        Tags = tags ?? new List<string>();
        Puzzle = puzzle;
    }
}