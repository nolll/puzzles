using Pzl.Common;

namespace Pzl.Aoc;

public class AocPuzzleProvider : IPuzzleProvider
{
    public List<PuzzleDefinition> GetPuzzles() =>
        PuzzleFactory.GetTypes<AocPuzzle>()
            .Select(CreatePuzzleDefinition)
            .ToList();

    private static PuzzleDefinition CreatePuzzleDefinition(PuzzleData data)
    {
        var (year, day) = AocPuzzleParser.GetYearAndDay(data.Type);
        var paddedDay = day.ToString().PadLeft(2, '0');
        var id = $"{year}{paddedDay}";
        var sortId = $"aoc {id}";
        var title = $"Advent of Code {year}-{paddedDay}";
        var listTitle = $"Aoc {year}-{paddedDay}";
        List<string> tags = ["aoc", year.ToString(), day.ToString()];

        return new PuzzleDefinition(data, tags, sortId, title, listTitle);
    }
}