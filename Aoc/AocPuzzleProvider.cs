using Pzl.Common;

namespace Pzl.Aoc;

public class AocPuzzleProvider : IPuzzleProvider
{
    public List<PuzzleDefinition> GetPuzzles() =>
        PuzzleFactory.GetTypes<AocPuzzle>()
            .Select(CreatePuzzleDefinition)
            .ToList();

    private static PuzzleDefinition CreatePuzzleDefinition(PuzzleData data)
    {
        var instance = PuzzleFactory.CreateInstance<AocPuzzle>(data.Type);
        return new PuzzleDefinition(data, instance);
    }
}