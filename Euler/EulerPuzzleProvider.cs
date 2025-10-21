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
        var sortId = $"euler {paddedId}";
        var title = $"Project Euler {id}";
        var listTitle = $"euler {paddedId}";
        List<string> tags = ["euler", id];
        return new PuzzleDefinition(data, tags, sortId, title, listTitle);
    }
}