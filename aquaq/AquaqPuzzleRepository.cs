using Common.Puzzles;

namespace Aquaq;

public class AquaqPuzzleRepository : IPuzzleRepository
{
    private readonly List<Puzzle> _puzzles;
    private readonly PuzzleFactory _puzzleFactory = new AquaqPuzzleFactory();

    public AquaqPuzzleRepository()
    {
        _puzzles = _puzzleFactory.CreatePuzzles();
    }

    public Puzzle? GetPuzzle(string id) =>
        _puzzles.FirstOrDefault(o => o.Id == id);

    public IList<Puzzle> GetPuzzles() => _puzzles;
}