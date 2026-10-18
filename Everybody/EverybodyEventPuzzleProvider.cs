using Pzl.Common;

namespace Pzl.Everybody;

public class EverybodyEventPuzzleProvider : IPuzzleProvider
{
    public List<PuzzleDefinition> GetPuzzles() =>
        PuzzleDataReader.ReadData<EverybodyEventPuzzle>()
            .Select(CreatePuzzleDefinition)
            .ToList();
    
    private static PuzzleDefinition CreatePuzzleDefinition(PuzzleData data)
    {
        var (year, day) = EverybodyEventPuzzleParser.ParseYearAndDay(data.Type);
        var paddedDay = day.ToString().PadLeft(2, '0');
        var id = $"{year}{paddedDay}";
        var sortId = $"{EverybodyPuzzle.ShortName} e{id}";
        var title = $"{EverybodyPuzzle.Name} Event {year} Day {paddedDay}";
        var listTitle = $"{EverybodyPuzzle.ShortName} {year}-{paddedDay}";
        List<string> tags = [EverybodyPuzzle.ShortName, year.ToString(), day.ToString()];

        return new PuzzleDefinition(data, tags, sortId, title, listTitle);
    }
}