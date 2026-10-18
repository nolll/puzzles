using Pzl.Common;

namespace Pzl.Aquaq;

public class AquaqPuzzleProvider : IPuzzleProvider
{
    public List<PuzzleDefinition> GetPuzzles() =>
        PuzzleDataReader.ReadData<AquaqPuzzle>()
            .Select(CreatePuzzleDefinition)
            .ToList();

    private static PuzzleDefinition CreatePuzzleDefinition(PuzzleData data)
    {
        var id = AquaqPuzzleParser.GetPuzzleId(data.Type).ToString();
        var paddedId = id.PadLeft(2, '0');
        var sortId = $"{data.PuzzleType.ShortName} {paddedId}";
        var title = $"{data.PuzzleType.Name} {id}";
        var listTitle = $"{data.PuzzleType.ShortName} {paddedId}";
        List<string> tags = [data.PuzzleType.ShortName, id];
        return new PuzzleDefinition(data, tags, sortId, title, listTitle);
    }
}