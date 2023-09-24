using Common.Puzzles;

namespace Aquaq;

public class AquaqPuzzleRepository : IPuzzleRepository
{
    private readonly List<Puzzle> _puzzles;

    public AquaqPuzzleRepository()
    {
        _puzzles = new PuzzleFactory().CreatePuzzles<AquaqPuzzle>();
    }

    public Puzzle? GetPuzzle(string id) =>
        _puzzles.FirstOrDefault(o => o.Id == id);

    public IList<Puzzle> GetPuzzles() => _puzzles;
}