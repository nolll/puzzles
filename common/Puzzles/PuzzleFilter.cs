namespace Common.Puzzles;

public class PuzzleFilter
{
    private readonly Parameters _parameters;

    public PuzzleFilter(Parameters parameters)
    {
        _parameters = parameters;
    }

    public IEnumerable<PuzzleWrapper> Filter(IEnumerable<PuzzleWrapper> puzzles)
    {
        var r = puzzles;
        foreach (var tag in _parameters.Tags)
        {
            r = r.Where(o => o.Tags.Contains(tag));
        }

        return r;
    }
}