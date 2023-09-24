using System.Collections.Generic;
using System.Linq;
using Common.Puzzles;

namespace Aoc.Puzzles;

public class AocPuzzleRepository : IPuzzleRepository
{
    private readonly List<Puzzle> _puzzles;
        
    public AocPuzzleRepository()
    {
        _puzzles = new PuzzleFactory().CreatePuzzles<AocPuzzle>();
    }

    public Puzzle? GetPuzzle(string id) =>
        _puzzles.FirstOrDefault(o => o.Id == id);

    public IList<Puzzle> GetPuzzles() => _puzzles;
}
