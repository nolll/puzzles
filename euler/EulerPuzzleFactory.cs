using Common.Puzzles;

namespace Euler;

public class EulerPuzzleFactory : PuzzleFactory
{
    public override List<Puzzle> CreatePuzzles() =>
        GetConcreteSubclassesOf<EulerPuzzle>()
            .Select(CreatePuzzle)
            .OrderBy(o => o.Id)
            .ToList();

    private static Puzzle CreatePuzzle(Type t)
    {
        if (Activator.CreateInstance(t) is not EulerPuzzle puzzle)
            throw new Exception($"Could not create puzzle: {t}");

        return puzzle;
    }
}