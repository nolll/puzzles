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
        var sortId = $"{AquaqPuzzle.ShortName} {paddedId}";
        var title = $"{AquaqPuzzle.Name} {id}";
        var listTitle = $"{AquaqPuzzle.ShortName} {paddedId}";
        List<string> tags = [AquaqPuzzle.ShortName, id];
        return new PuzzleDefinition(data, tags, sortId, title, listTitle);
    }
}