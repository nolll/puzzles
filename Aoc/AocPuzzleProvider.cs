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
        var sortId = $"aoc {id}";
        var title = $"Advent of Code {year} Day {paddedDay}";
        var listTitle = $"aoc {year}-{paddedDay}";
        List<string> tags = ["aoc", year.ToString(), day.ToString()];

        return new PuzzleDefinition(data, tags, sortId, title, listTitle);
    }
}