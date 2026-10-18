using Pzl.Common;

namespace Pzl.Everybody;

public class EverybodyStoryPuzzleProvider : IPuzzleProvider
{
    public List<PuzzleDefinition> GetPuzzles() =>
        [.. PuzzleDataReader.ReadData<EverybodyStoryPuzzle>().Select(CreatePuzzleDefinition)];

    private static PuzzleDefinition CreatePuzzleDefinition(PuzzleData data)
    {
        var (story, part) = EverybodyStoryPuzzleParser.ParseStoryAndPart(data.Type);
        var paddedPart = part.ToString().PadLeft(2, '0');
        var id = $"{story}{paddedPart}";
        var sortId = $"{data.PuzzleType.ShortName} s{id}";
        var title = $"{data.PuzzleType.Name} Story {story} Part {paddedPart}";
        var listTitle = $"{data.PuzzleType.ShortName} s{story}-{paddedPart}";
        List<string> tags = [data.PuzzleType.ShortName, $"s{story}", part.ToString()];

        return new PuzzleDefinition(data, tags, sortId, title, listTitle);
    }
}