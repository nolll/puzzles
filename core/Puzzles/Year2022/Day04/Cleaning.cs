using System.Linq;
using Core.Common.Strings;

namespace Core.Puzzles.Year2022.Day04;

public class Cleaning
{
    public int Part1(string input)
    {
        var lines = PuzzleInputReader.ReadLines(input, false);
        var ranges = lines.Select(ParseRanges);

        return ranges.Count(o => o.a.Contains(o.b) || o.b.Contains(o.a));
    }

    public int Part2(string input)
    {
        var lines = PuzzleInputReader.ReadLines(input, false);
        var ranges = lines.Select(ParseRanges);

        return ranges.Count(o => o.a.Overlaps(o.b) || o.b.Overlaps(o.a));
    }

    private (CleaningRange a, CleaningRange b) ParseRanges(string s)
    {
        var parts = s.Split(",");
        return (ParseRange(parts[0]), ParseRange(parts[1]));
    }
        
    private CleaningRange ParseRange(string s)
    {
        var parts = s.Split("-");
        return new CleaningRange(int.Parse(parts[0]), int.Parse(parts[1]));
    }
}