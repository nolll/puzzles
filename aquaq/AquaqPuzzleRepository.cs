using Common.Puzzles;

namespace Aquaq;

public class AquaqPuzzleRepository : IPuzzleRepository
{
    private readonly List<PuzzleWrapper> _allProblems;
    private readonly PuzzleFactory _puzzleFactory = new AquaqPuzzleFactory();

    public AquaqPuzzleRepository()
    {
        _allProblems = _puzzleFactory.CreatePuzzles();
    }

    public PuzzleWrapper? GetPuzzle(string id) =>
        _allProblems.FirstOrDefault(o => o.Id == id);

    public IList<PuzzleWrapper> GetPuzzles() => _allProblems;
}