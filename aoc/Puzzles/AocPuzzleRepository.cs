using System.Collections.Generic;
using System.Linq;
using Aoc.Platform;
using common.Puzzles;

namespace Aoc.Puzzles;

public class AocPuzzleRepository
{
    private readonly List<PuzzleWrapper> _allDays;
    private readonly PuzzleFactory _puzzleFactory = new AocPuzzleFactory();
        
    public AocPuzzleRepository()
    {
        _allDays = _puzzleFactory.CreatePuzzles();
    }

    public PuzzleWrapper? GetPuzzle(string id) =>
        _allDays.FirstOrDefault(o => o.Id == id);

    public List<PuzzleWrapper> GetEventDays(int? selectedYear) =>
        selectedYear != null 
            ? _allDays.Where(o => o.Id.StartsWith(selectedYear.Value.ToString())).ToList() 
            : new List<PuzzleWrapper>();

    public List<PuzzleWrapper> GetAll() => _allDays;
}