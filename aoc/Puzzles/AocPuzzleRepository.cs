using System.Collections.Generic;
using System.Linq;
using Aoc.Platform;
using Common.Puzzles;

namespace Aoc.Puzzles;

public class AocPuzzleRepository : IPuzzleRepository
{
    private readonly List<PuzzleWrapper> _allDays;
    private readonly PuzzleFactory _puzzleFactory = new AocPuzzleFactory();
        
    public AocPuzzleRepository()
    {
        _allDays = _puzzleFactory.CreatePuzzles();
    }

    public PuzzleWrapper? GetPuzzle(string id) =>
        _allDays.FirstOrDefault(o => o.Id == id);

    public IList<PuzzleWrapper> GetPuzzles() => _allDays;
}
