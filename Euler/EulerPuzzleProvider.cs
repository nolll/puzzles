using Pzl.Common;

namespace Pzl.Euler;

public class EulerPuzzleProvider : IPuzzleProvider
{
    public List<PuzzleDefinition> GetPuzzles() =>
        PuzzleFactory.GetTypes<EulerPuzzle>()
            .Select(CreatePuzzleDefinition)
            .ToList();

    private static PuzzleDefinition CreatePuzzleDefinition(Type t)
    {
        var instance = PuzzleFactory.CreatePuzzle<EulerPuzzle>(t);
        return new PuzzleDefinition(t, instance);
    }
}