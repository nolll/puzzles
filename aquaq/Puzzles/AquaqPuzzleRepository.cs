using System.Reflection;
using AquaQ.Platform;
using common.Puzzles;

namespace AquaQ.Puzzles;

public class AquaqPuzzleRepository
{
    private readonly List<PuzzleWrapper> _allProblems;
    private readonly PuzzleFactory _puzzleFactory = new AquaqPuzzleFactory();

    public AquaqPuzzleRepository()
    {
        _allProblems = _puzzleFactory.CreatePuzzles();
    }

    public PuzzleWrapper? GetChallenge(int? problemId) =>
        problemId != null
            ? _allProblems.FirstOrDefault(o => o.Id == problemId.Value.ToString())
            : _allProblems.LastOrDefault();

    public IList<PuzzleWrapper> GetAll() => _allProblems;
}

public class AquaqPuzzleFactory : PuzzleFactory
{
    public override List<PuzzleWrapper> CreatePuzzles() =>
        GetConcreteSubclassesOf<AquaqPuzzle>()
            .Select(CreateProblem)
            .OrderBy(o => o.Id)
            .ToList();

    private static PuzzleWrapper CreateProblem(Type t)
    {
        var id = AquaqPuzzleParser.GetChallengeId(t).ToString();
        if (Activator.CreateInstance(t) is not AquaqPuzzle challenge)
            throw new Exception($"Could not create puzzle {id}");

        var title = $"Puzzle {id}";
        var listId = id.PadLeft(2, '0');
        var listTitle = $"Puzzle {listId}";
        return new PuzzleWrapper(id, title, listTitle, challenge);
    }
}