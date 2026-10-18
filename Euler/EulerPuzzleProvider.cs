using Pzl.Common;

namespace Pzl.Euler;

public class EulerPuzzleProvider : IPuzzleProvider
{
    public List<PuzzleDefinition> GetPuzzles() =>
        PuzzleDataReader.ReadData<EulerPuzzle>()
            .Select(CreatePuzzleDefinition)
            .ToList();

    private static PuzzleDefinition CreatePuzzleDefinition(PuzzleData data)
    {
        var id = EulerPuzzleParser.GetPuzzleId(data.Type).ToString();
        var paddedId = id.PadLeft(3, '0');
        var sortId = $"{data.PuzzleTypeShortName} {paddedId}";
        var title = $"{data.PuzzleTypeName} {id}";
        var listTitle = $"{data.PuzzleTypeShortName} {paddedId}";
        List<string> tags = [data.PuzzleTypeShortName, id];
        return new PuzzleDefinition(data, tags, sortId, title, listTitle);
    }
}