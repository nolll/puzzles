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
        var sortId = $"flipflop {id}";
        var title = $"FlipFlop {year} Day {paddedDay}";
        var listTitle = $"ff {year}-{paddedDay}";
        List<string> tags = ["ff", year.ToString(), day.ToString()];

        return new PuzzleDefinition(data, tags, sortId, title, listTitle);
    }
}