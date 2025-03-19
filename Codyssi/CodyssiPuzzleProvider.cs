using Pzl.Common;

namespace Pzl.Codyssi;

public class CodyssiPuzzleProvider : IPuzzleProvider
{
    public List<PuzzleDefinition> GetPuzzles() =>
        PuzzleDataReader.ReadData<CodyssiPuzzle>()
            .Select(CreatePuzzleDefinition)
            .ToList();
    
    private static PuzzleDefinition CreatePuzzleDefinition(PuzzleData data)
    {
        var id = CodyssiPuzzleParser.GetPuzzleId(data.Type).ToString();
        var paddedId = id.PadLeft(2, '0');
        var sortId = $"codyssi {paddedId}";
        var title = $"Codyssi {id}";
        var listTitle = $"Codyssi {paddedId}";
        List<string> tags = ["codyssi", id];
        return new PuzzleDefinition(data, tags, sortId, title, listTitle);
    }
}