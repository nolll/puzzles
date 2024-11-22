using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2022.Aoc202204;

public class Cleaning
{
    public int Part1(string input)
    {
        var lines = StringReader.ReadLines(input, false);
        var ranges = lines.Select(ParseRanges);

        return ranges.Count(o => o.a.Contains(o.b) || o.b.Contains(o.a));
    }

    public int Part2(string input)
    {
        var lines = StringReader.ReadLines(input, false);
        var ranges = lines.Select(ParseRanges);

        return ranges.Count(o => o.a.Overlaps(o.b) || o.b.Overlaps(o.a));
    }

    private (CleaningRange a, CleaningRange b) ParseRanges(string s)
    {
        var parts = s.Split(',', '-');
        var r1 = new CleaningRange(int.Parse(parts[0]), int.Parse(parts[1]));
        var r2 = new CleaningRange(int.Parse(parts[2]), int.Parse(parts[3]));
        return (r1, r2);
    }
}