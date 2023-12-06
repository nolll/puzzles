using Puzzles.Common.Puzzles;
using Pzl.Aoc;
using Pzl.Aquaq;
using Pzl.Euler;

namespace Pzl.Cli;

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

    public List<Puzzle> Search(string query) =>
        _puzzles
            .Where(o => MatchesQuery(o, query))
            .ToList();

    private static bool MatchesQuery(Puzzle o, string query) =>
        o.Title.Contains(query, StringComparison.InvariantCultureIgnoreCase) ||
        o.Name.Contains(query, StringComparison.InvariantCultureIgnoreCase) ||
        o.Comment is not null && o.Comment.Contains(query, StringComparison.InvariantCultureIgnoreCase);
}
