using Pzl.Common;

namespace Pzl.Euler;

public class EulerPuzzleProvider : IPuzzleProvider
{
    public List<PuzzleDefinition> GetPuzzles() =>
        PuzzleFactory.GetTypes<EulerPuzzle>()
            .Select(CreatePuzzleDefinition)
            .ToList();

    private static PuzzleDefinition CreatePuzzleDefinition(PuzzleData data)
    {
        var instance = PuzzleFactory.CreateInstance<EulerPuzzle>(data.Type);
        return new PuzzleDefinition(data, instance);
    }
}