using common.Puzzles;

namespace Euler.Platform;

public class EulerPuzzleFactory : PuzzleFactory
{
    public override List<PuzzleWrapper> CreatePuzzles() =>
        GetConcreteSubclassesOf<EulerPuzzle>()
            .Select(CreateProblem)
            .OrderBy(o => o.Id)
            .ToList();

    private static PuzzleWrapper CreateProblem(Type t)
    {
        var id = EulerPuzzleParser.GetProblemId(t).ToString();
        if (Activator.CreateInstance(t) is not EulerPuzzle problem)
            throw new Exception($"Could not create puzzle {id}");

        var title = $"Puzzle {id}";
        var listId = id.PadLeft(3, '0');
        var listTitle = $"Puzzle {listId}";
        return new PuzzleWrapper(id, title, listTitle, problem);
    }
}