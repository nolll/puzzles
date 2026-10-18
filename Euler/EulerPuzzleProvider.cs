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
        var sortId = $"{EulerPuzzle.ShortName} {paddedId}";
        var title = $"{EulerPuzzle.Name} {id}";
        var listTitle = $"{EulerPuzzle.ShortName} {paddedId}";
        List<string> tags = [EulerPuzzle.ShortName, id];
        return new PuzzleDefinition(data, tags, sortId, title, listTitle);
    }
}