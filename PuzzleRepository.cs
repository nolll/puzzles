using Puzzles.Aoc;
using Puzzles.Aquaq;
using Puzzles.Common.Puzzles;
using Puzzles.Euler;

namespace Puzzles;

public class PuzzleRepository
{
    private readonly List<Puzzle> _puzzles;
        
    public PuzzleRepository()
    {
        var puzzleFactory = new PuzzleFactory();
        _puzzles = new List<Puzzle>();
        _puzzles.AddRange(puzzleFactory.CreatePuzzles<AocPuzzle>());
        _puzzles.AddRange(puzzleFactory.CreatePuzzles<AquaqPuzzle>());
        _puzzles.AddRange(puzzleFactory.CreatePuzzles<EulerPuzzle>());
    }

    public IList<Puzzle> GetPuzzles() => _puzzles;

    public List<Puzzle> Search(string query)
    {
        return _puzzles
            .Where(o => MatchesQuery(o, query))
            .ToList();
    }

    private static bool MatchesQuery(Puzzle o, string query)
    {
        return o.Title.Contains(query, StringComparison.InvariantCultureIgnoreCase) ||
               o.Name.Contains(query, StringComparison.InvariantCultureIgnoreCase) ||
               o.Comment is not null && o.Comment.Contains(query, StringComparison.InvariantCultureIgnoreCase);
    }
}
