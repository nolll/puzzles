using Pzl.Common;

namespace Pzl.Everybody;

public class EverybodyStoryPuzzleProvider : IPuzzleProvider
{
    public List<PuzzleDefinition> GetPuzzles() =>
        PuzzleDataReader.ReadData<EverybodyStoryPuzzle>()
            .Select(CreatePuzzleDefinition)
            .ToList();
    
    private static PuzzleDefinition CreatePuzzleDefinition(PuzzleData data)
    {
        var (story, part) = EverybodyStoryPuzzleParser.ParseStoryAndPart(data.Type);
        var paddedPart = part.ToString().PadLeft(2, '0');
        var id = $"{story}{paddedPart}";
        var sortId = $"ec s{id}";
        var title = $"Everybody Codes Story {story} Part {paddedPart}";
        var listTitle = $"ec s{story}-{paddedPart}";
        List<string> tags = ["ec", $"s{story}", part.ToString()];

        return new PuzzleDefinition(data, tags, sortId, title, listTitle);
    }
}