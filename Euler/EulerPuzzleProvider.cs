using Pzl.Common;
using System.Security.Cryptography;

namespace Pzl.Euler;

public class EulerPuzzleProvider : IPuzzleProvider
{
    public List<PuzzleDefinition> GetPuzzles() =>
        PuzzleFactory.GetTypes<EulerPuzzle>()
            .Select(CreatePuzzleDefinition)
            .ToList();

    private static PuzzleDefinition CreatePuzzleDefinition(PuzzleData data)
    {
        var id = EulerPuzzleParser.GetPuzzleId(data.Type).ToString();
        var paddedId = id.PadLeft(3, '0');
        var sortId = $"euler {paddedId}";
        var title = $"Project Euler {id}";
        var listTitle = $"Euler {paddedId}";
        List<string> tags = ["euler", id];
        return new PuzzleDefinition(data, tags, sortId, title, listTitle);
    }
}