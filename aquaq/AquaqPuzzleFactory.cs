using Common.Puzzles;

namespace Aquaq;

public class AquaqPuzzleFactory : PuzzleFactory
{
    public override List<PuzzleWrapper> CreatePuzzles() =>
        GetConcreteSubclassesOf<AquaqPuzzle>()
            .Select(CreatePuzzleFromType)
            .OrderBy(o => o.Id)
            .ToList();

    private static PuzzleWrapper CreatePuzzleFromType(Type t)
    {
        var id = AquaqPuzzleParser.GetPuzzleId(t).ToString();
        if (Activator.CreateInstance(t) is not AquaqPuzzle puzzle)
            throw new Exception($"Could not create puzzle {id}");

        return CreatePuzzle(id, puzzle);
    }

    private static PuzzleWrapper CreatePuzzle(string id, AquaqPuzzle puzzle)
    {
        return new PuzzleWrapper(puzzle.Id, puzzle.Title, puzzle.ListTitle, puzzle.GetTags().ToList(), puzzle);
    }
}