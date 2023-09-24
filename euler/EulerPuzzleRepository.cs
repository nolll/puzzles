using Common.Puzzles;

namespace Euler;

public class EulerPuzzleRepository : IPuzzleRepository
{
    private readonly List<Puzzle> _puzzles;

    public EulerPuzzleRepository()
    {
        _puzzles = new PuzzleFactory().CreatePuzzles<EulerPuzzle>();
    }

    public Puzzle? GetPuzzle(string id) =>
        _puzzles.FirstOrDefault(o => o.Id == id);

    public IList<Puzzle> GetPuzzles() => _puzzles;
}