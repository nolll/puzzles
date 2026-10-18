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
        var sortId = $"{data.PuzzleTypeShortName} {paddedId}";
        var title = $"{data.PuzzleTypeName} {id}";
        var listTitle = $"{data.PuzzleTypeShortName} {paddedId}";
        List<string> tags = [data.PuzzleTypeShortName, id];
        return new PuzzleDefinition(data, tags, sortId, title, listTitle);
    }
}