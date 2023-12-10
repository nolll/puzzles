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
        var id = AquaqPuzzleParser.GetPuzzleId(data.Type).ToString();
        var paddedId = id.PadLeft(2, '0');
        var sortId = $"aquaq {paddedId}";
        var title = $"AquaQ Challenge {id}";
        var listTitle = $"AquaQ {paddedId}";
        List<string> tags = ["aquaq", id];
        var instance = PuzzleFactory.CreateInstance<AquaqPuzzle>(data.Type);
        return new PuzzleDefinition(data, instance, tags, sortId, title, listTitle);
    }
}