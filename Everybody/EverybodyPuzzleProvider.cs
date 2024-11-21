using Pzl.Common;

namespace Pzl.Everybody;

public class EverybodyPuzzleProvider : IPuzzleProvider
{
    public List<PuzzleDefinition> GetPuzzles() =>
        PuzzleDataReader.ReadData<EverybodyPuzzle>()
            .Select(CreatePuzzleDefinition)
            .ToList();
    
    private static PuzzleDefinition CreatePuzzleDefinition(PuzzleData data)
    {
        var id = EverybodyPuzzleParser.GetPuzzleId(data.Type).ToString();
        var paddedId = id.PadLeft(2, '0');
        var sortId = $"everybody {paddedId}";
        var title = $"Everybody Codes {id}";
        var listTitle = $"Every {paddedId}";
        List<string> tags = ["everybody", id];
        return new PuzzleDefinition(data, tags, sortId, title, listTitle);
    }
}