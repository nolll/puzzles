using Pzl.Common;

namespace Pzl.Aoc;

public class AocPuzzleProvider : IPuzzleProvider
{
    public List<PuzzleDefinition> GetPuzzles() =>
        PuzzleFactory.GetTypes<AocPuzzle>()
            .Select(CreatePuzzleDefinition)
            .ToList();

    private static PuzzleDefinition CreatePuzzleDefinition(Type t)
    {
        var instance = PuzzleFactory.CreatePuzzle<AocPuzzle>(t);
        return new PuzzleDefinition(t, instance);
    }
}