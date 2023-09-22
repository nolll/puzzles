using common.Puzzles;

namespace AquaQ.Platform;

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