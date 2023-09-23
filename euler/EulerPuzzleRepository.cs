using Common.Puzzles;

namespace Euler;

public class EulerPuzzleRepository : IPuzzleRepository
{
    private readonly List<PuzzleWrapper> _allPuzzles;
    private readonly PuzzleFactory _puzzleFactory = new EulerPuzzleFactory();

    public EulerPuzzleRepository()
    {
        _allPuzzles = _puzzleFactory.CreatePuzzles();
    }

    public PuzzleWrapper? GetPuzzle(string id) =>
        _allPuzzles.FirstOrDefault(o => o.Id == id);

    public IList<PuzzleWrapper> GetPuzzles() => _allPuzzles;
}