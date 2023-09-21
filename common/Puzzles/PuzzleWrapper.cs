namespace common.Puzzles;

public class PuzzleWrapper
{
    public string Id { get; }
    public string Title { get; }
    public string ListTitle { get; }
    public Puzzle Puzzle { get; }

    public PuzzleWrapper(string id, string title, string listTitle, Puzzle puzzle)
    {
        Id = id;
        Title = title;
        ListTitle = listTitle;
        Puzzle = puzzle;
    }
}