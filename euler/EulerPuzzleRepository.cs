using Common.Puzzles;

namespace Euler;

public class EulerPuzzleRepository : IPuzzleRepository
{
    private readonly List<Puzzle> _puzzles;
    private readonly PuzzleFactory _puzzleFactory = new EulerPuzzleFactory();

    public EulerPuzzleRepository()
    {
        _puzzles = _puzzleFactory.CreatePuzzles();
    }

    public Puzzle? GetPuzzle(string id) =>
        _puzzles.FirstOrDefault(o => o.Id == id);

    public IList<Puzzle> GetPuzzles() => _puzzles;
}