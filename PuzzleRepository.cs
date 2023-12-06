using Pzl.Common;

namespace Pzl.Client;

public class PuzzleRepository
{
    private readonly List<Puzzle> _puzzles;
        
    public PuzzleRepository(IEnumerable<IPuzzleProvider> puzzleProviders)
    {
        _puzzles = puzzleProviders.SelectMany(o => o.GetPuzzles()).ToList();
    }

    public IList<Puzzle> GetPuzzles() => _puzzles;

    public List<Puzzle> Search(string query) =>
        _puzzles
            .Where(o => MatchesQuery(o, query))
            .ToList();

    private static bool MatchesQuery(Puzzle o, string query) =>
        o.Title.Contains(query, StringComparison.InvariantCultureIgnoreCase) ||
        o.Name.Contains(query, StringComparison.InvariantCultureIgnoreCase) ||
        o.Comment is not null && o.Comment.Contains(query, StringComparison.InvariantCultureIgnoreCase);
}
