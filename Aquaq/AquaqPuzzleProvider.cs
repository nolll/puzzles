using Pzl.Common;

namespace Pzl.Aquaq;

public class AquaqPuzzleProvider : IPuzzleProvider
{
    public List<PuzzleDefinition> GetPuzzles() =>
        PuzzleFactory.GetTypes<AquaqPuzzle>()
            .Select(CreatePuzzleDefinition)
            .ToList();

    private static PuzzleDefinition CreatePuzzleDefinition(PuzzleData data)
    {
        var instance = PuzzleFactory.CreateInstance<AquaqPuzzle>(data.Type);
        return new PuzzleDefinition(data, instance);
    }
}