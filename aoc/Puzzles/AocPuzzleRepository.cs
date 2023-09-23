using System.Collections.Generic;
using System.Linq;
using Common.Puzzles;

namespace Aoc.Puzzles;

public class AocPuzzleRepository : IPuzzleRepository
{
    private readonly List<Puzzle> _puzzles;
    private readonly PuzzleFactory _puzzleFactory = new AocPuzzleFactory();
        
    public AocPuzzleRepository()
    {
        _puzzles = _puzzleFactory.CreatePuzzles();
    }

    public Puzzle? GetPuzzle(string id) =>
        _puzzles.FirstOrDefault(o => o.Id == id);

    public IList<Puzzle> GetPuzzles() => _puzzles;
}
