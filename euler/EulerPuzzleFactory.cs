using Common.Puzzles;

namespace Euler;

public class EulerPuzzleFactory : PuzzleFactory
{
    public override List<PuzzleWrapper> CreatePuzzles() =>
        GetConcreteSubclassesOf<EulerPuzzle>()
            .Select(CreatePuzzle)
            .OrderBy(o => o.Id)
            .ToList();

    private static PuzzleWrapper CreatePuzzle(Type t)
    {
        var id = EulerPuzzleParser.GetProblemId(t).ToString();
        if (Activator.CreateInstance(t) is not EulerPuzzle puzzle)
            throw new Exception($"Could not create puzzle {id}");

        return CreatePuzzle(id, puzzle);
    }

    private static PuzzleWrapper CreatePuzzle(string id, EulerPuzzle puzzle)
    {
        var title = $"Puzzle {id}";
        var listId = id.PadLeft(3, '0');
        var listTitle = $"Puzzle {listId}";
        var tags = puzzle.GetTags().ToList();
        return new PuzzleWrapper(id, title, listTitle, tags, puzzle);
    }
}