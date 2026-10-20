using Pzl.Common;
using Pzl.Tools.Numbers;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2022;

[Name("Camp Cleanup")]
public class Aoc202204 : AocPuzzle
{
    [Puzzle("9569cfbf59abc27202b8777006153703")]
    public int Part1(string input) => input.Split(LineBreaks.Single)
        .Select(ParseRanges)
        .Count(o => o.a.Contains(o.b) || o.b.Contains(o.a));

    [Puzzle("1cf622579ace09c8f182b5640835416f")]
    public int Part2(string input) => input.Split(LineBreaks.Single)
        .Select(ParseRanges)
        .Count(o => o.a.Overlaps(o.b) || o.b.Overlaps(o.a));

    private static (CleaningRange a, CleaningRange b) ParseRanges(string s)
    {
        var parts = Numbers.IntsFromString(s.Replace('-', '_'));
        var (s1, e1, s2, e2) = parts;
        return (new CleaningRange(s1, e1), new CleaningRange(s2, e2));
    }

    private class CleaningRange(int from, int to)
    {
        private readonly int _from = from;
        private readonly int _to = to;

        public bool Contains(CleaningRange other) => other._from >= _from && other._to <= _to;

        public bool Overlaps(CleaningRange other) =>
            other._to >= _from && other._to <= _to ||
            other._from <= _to && other._from >= _from;
    }
}