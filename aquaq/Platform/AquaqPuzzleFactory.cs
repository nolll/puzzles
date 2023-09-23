using Common.Puzzles;

namespace Aquaq.Platform;

public class AquaqPuzzleFactory : PuzzleFactory
{
    public override List<PuzzleWrapper> CreatePuzzles() =>
        GetConcreteSubclassesOf<AquaqPuzzle>()
            .Select(CreatePuzzleFromType)
            .OrderBy(o => o.Id)
            .ToList();

    private static PuzzleWrapper CreatePuzzleFromType(Type t)
    {
        var id = AquaqPuzzleParser.GetChallengeId(t).ToString();
        if (Activator.CreateInstance(t) is not AquaqPuzzle puzzle)
            throw new Exception($"Could not create puzzle {id}");

        return CreatePuzzle(id, puzzle);
    }

    private static PuzzleWrapper CreatePuzzle(string id, AquaqPuzzle puzzle)
    {
        var title = $"Puzzle {id}";
        var listId = id.PadLeft(2, '0');
        var listTitle = $"Puzzle {listId}";
        var tags = puzzle.GetTags().ToList();
        return new PuzzleWrapper(id, title, listTitle, tags, puzzle);
    }
}