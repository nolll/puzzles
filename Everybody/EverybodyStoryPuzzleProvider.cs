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
        var sortId = $"{data.PuzzleTypeShortName} s{id}";
        var title = $"{data.PuzzleTypeName} Story {story} Part {paddedPart}";
        var listTitle = $"{data.PuzzleTypeShortName} s{story}-{paddedPart}";
        List<string> tags = [data.PuzzleTypeShortName, $"s{story}", part.ToString()];

        return new PuzzleDefinition(data, tags, sortId, title, listTitle);
    }
}