using Pzl.Common;

namespace Pzl.FlipFlop;

public class FlipFlopPuzzleProvider : IPuzzleProvider
{
    public List<PuzzleDefinition> GetPuzzles() =>
        PuzzleDataReader.ReadData<FlipFlopPuzzle>()
            .Select(CreatePuzzleDefinition)
            .ToList();
    
    private static PuzzleDefinition CreatePuzzleDefinition(PuzzleData data)
    {
        var (year, day) = FlipFlopPuzzleParser.GetPuzzleId(data.Type);
        var paddedDay = day.ToString().PadLeft(2, '0');
        var id = $"{year}{paddedDay}";
        var sortId = $"{data.PuzzleTypeShortName} {id}";
        var title = $"{data.PuzzleTypeName} {year} Day {paddedDay}";
        var listTitle = $"{data.PuzzleTypeShortName} {year}-{paddedDay}";
        List<string> tags = [data.PuzzleTypeShortName, year.ToString(), day.ToString()];

        return new PuzzleDefinition(data, tags, sortId, title, listTitle);
    }
}