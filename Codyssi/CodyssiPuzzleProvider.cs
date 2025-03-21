using Pzl.Common;

namespace Pzl.Codyssi;

public class CodyssiPuzzleProvider : IPuzzleProvider
{
    public List<PuzzleDefinition> GetPuzzles() =>
        PuzzleDataReader.ReadData<CodyssiPuzzle>()
            .Select(CreatePuzzleDefinition)
            .ToList();
    
    private static PuzzleDefinition CreatePuzzleDefinition(PuzzleData data)
    {
        var (year, day) = CodyssiPuzzleParser.GetPuzzleId(data.Type);
        var paddedDay = day.ToString().PadLeft(2, '0');
        var id = $"{year}{paddedDay}";
        var sortId = $"codyssi {id}";
        var title = $"Codyssi {year}-{paddedDay}";
        var listTitle = $"C5i {year}-{paddedDay}";
        List<string> tags = ["codyssi", year.ToString(), day.ToString()];

        return new PuzzleDefinition(data, tags, sortId, title, listTitle);
    }
}