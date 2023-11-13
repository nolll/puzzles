using Puzzles.aoc;
using Puzzles.aquaq;
using Puzzles.common.Puzzles;
using Puzzles.euler;

namespace Puzzles;

public class PuzzleRepository : IPuzzleRepository
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

    public Puzzle? GetPuzzle(string id) =>
        _puzzles.FirstOrDefault(o => o.Id == id);

    public IList<Puzzle> GetPuzzles() => _puzzles;
}
