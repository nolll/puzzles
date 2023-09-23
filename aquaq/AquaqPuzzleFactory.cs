using Common.Puzzles;

namespace Aquaq;

public class AquaqPuzzleFactory : PuzzleFactory
{
    public override List<Puzzle> CreatePuzzles() =>
        GetConcreteSubclassesOf<AquaqPuzzle>()
            .Select(CreatePuzzle)
            .OrderBy(o => o.Id)
            .ToList();

    private static Puzzle CreatePuzzle(Type t)
    {
        if (Activator.CreateInstance(t) is not AquaqPuzzle puzzle)
            throw new Exception($"Could not create puzzle: {t}");

        return puzzle;
    }

}