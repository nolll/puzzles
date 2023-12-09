using Pzl.Common;

namespace Pzl.Client;

public class PuzzleRepository
{
    private readonly List<PuzzleDefinition> _puzzleDefinitions;
        
    public PuzzleRepository(IEnumerable<IPuzzleProvider> puzzleProviders)
    {
        _puzzleDefinitions = puzzleProviders.SelectMany(o => o.GetPuzzles()).ToList();
    }

    public IList<Puzzle> GetPuzzles() => _puzzleDefinitions.Select(o => o.Instance).ToList();

    public List<PuzzleDefinition> Search(string query) =>
        _puzzleDefinitions
            .Where(o => MatchesQuery(o, query))
            .ToList();

    private static bool MatchesQuery(PuzzleDefinition definition, string query) =>
        definition.Title.Contains(query, StringComparison.InvariantCultureIgnoreCase) ||
        definition.Name.Contains(query, StringComparison.InvariantCultureIgnoreCase) ||
        definition.Comment is not null && definition.Comment.Contains(query, StringComparison.InvariantCultureIgnoreCase);
}
