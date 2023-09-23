namespace Common.Puzzles;

public class PuzzleFilter
{
    private readonly Parameters _parameters;

    public PuzzleFilter(Parameters parameters)
    {
        _parameters = parameters;
    }

    public IEnumerable<Puzzle> Filter(IEnumerable<Puzzle> puzzles)
    {
        var r = puzzles;
        foreach (var tag in _parameters.Tags)
        {
            r = r.Where(o => o.GetTags().Contains(tag));
        }

        return r;
    }
}