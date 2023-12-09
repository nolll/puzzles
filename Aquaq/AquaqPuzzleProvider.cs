using Pzl.Common;

namespace Pzl.Aquaq;

public class AquaqPuzzleProvider : IPuzzleProvider
{
    public List<PuzzleDefinition> GetPuzzles() =>
        PuzzleFactory.GetTypes<AquaqPuzzle>()
            .Select(CreatePuzzleDefinition)
            .ToList();

    private static PuzzleDefinition CreatePuzzleDefinition(Type t)
    {
        var instance = PuzzleFactory.CreatePuzzle<AquaqPuzzle>(t);
        return new PuzzleDefinition(t, instance);
    }
}