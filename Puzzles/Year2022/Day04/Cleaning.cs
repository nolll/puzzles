using System.Linq;
using Aoc.Common.Strings;

namespace Aoc.Puzzles.Year2022.Day04;

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
        var parts = s.Split(',', '-');
        var r1 = new CleaningRange(int.Parse(parts[0]), int.Parse(parts[1]));
        var r2 = new CleaningRange(int.Parse(parts[2]), int.Parse(parts[3]));
        return (r1, r2);
    }
}