using Pzl.Common;

namespace Pzl.Aoc;

public class AocPuzzleProvider : IPuzzleProvider
{
    public List<PuzzleDefinition> GetPuzzles() =>
        PuzzleDataReader.ReadData<AocPuzzle>()
            .Select(CreatePuzzleDefinition)
            .ToList();

    private static PuzzleDefinition CreatePuzzleDefinition(PuzzleData data)
    {
        var (year, day) = AocPuzzleParser.ParseYearAndDay(data.Type);
        var paddedDay = day.ToString().PadLeft(2, '0');
        var id = $"{year}{paddedDay}";
        var sortId = $"{data.PuzzleType.ShortName} {id}";
        var title = $"{data.PuzzleType.Name} {year} Day {paddedDay}";
        var listTitle = $"{data.PuzzleType.ShortName} {year}-{paddedDay}";
        List<string> tags = [data.PuzzleType.ShortName, year.ToString(), day.ToString()];

        return new PuzzleDefinition(data, tags, sortId, title, listTitle);
    }
}