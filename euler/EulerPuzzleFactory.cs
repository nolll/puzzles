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
        var id = EulerPuzzleParser.GetPuzzleId(t).ToString();
        if (Activator.CreateInstance(t) is not EulerPuzzle puzzle)
            throw new Exception($"Could not create puzzle {id}");

        return CreatePuzzle(id, puzzle);
    }

    private static PuzzleWrapper CreatePuzzle(string id, EulerPuzzle puzzle)
    {
        return new PuzzleWrapper(puzzle.Id, puzzle.Title, puzzle.ListTitle, puzzle.GetTags().ToList(), puzzle);
    }
}