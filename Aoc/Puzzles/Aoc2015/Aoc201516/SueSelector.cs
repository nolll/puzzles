using Puzzles.Common.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2015.Aoc201516;

public class SueSelector
{
    public int SueNumberPart1 { get; }
    public int SueNumberPart2 { get; }

    public SueSelector(string input)
    {
        var sues = ParseSues(input);
        var correctSuePart1 = sues.FirstOrDefault(o => o.IsCorrectSuePart1);
        SueNumberPart1 = correctSuePart1?.Number ?? 0;
        var correctSuePart2 = sues.FirstOrDefault(o => o.IsCorrectSuePart2);
        SueNumberPart2 = correctSuePart2?.Number ?? 0;
    }

    private IList<Sue> ParseSues(string input)
    {
        var rows = StringReader.ReadLines(input);
        return rows.Select(ParseSue).ToList();
    }

    private Sue ParseSue(string s)
    {
        var parts = s.Replace(":", "").Replace(",", "").Split(' ');
        var number = int.Parse(parts[1]);
        var sue = new Sue(number);
        sue.Set(parts[2], int.Parse(parts[3]));
        sue.Set(parts[4], int.Parse(parts[5]));
        sue.Set(parts[6], int.Parse(parts[7]));
        return sue;
    }
}