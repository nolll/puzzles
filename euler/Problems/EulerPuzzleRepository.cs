using common.Puzzles;
using Euler.Platform;

namespace Euler.Problems;

public class EulerPuzzleRepository
{
    private readonly List<PuzzleWrapper> _allProblems;
    private readonly PuzzleFactory _puzzleFactory = new EulerPuzzleFactory();

    public EulerPuzzleRepository()
    {
        _allProblems = _puzzleFactory.CreatePuzzles();
    }

    public PuzzleWrapper? GetProblem(int? problemId) =>
        problemId != null
            ? _allProblems.FirstOrDefault(o => o.Id == problemId.Value.ToString())
            : _allProblems.LastOrDefault();

    public IList<PuzzleWrapper> GetAll() => _allProblems;
}