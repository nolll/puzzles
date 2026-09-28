using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2022;

[Name("Camp Cleanup")]
public class Aoc202204 : AocPuzzle
{
    [Puzzle("9569cfbf59abc27202b8777006153703")]
    public int Part1(string input) => new Cleaning().Part1(input);

    [Puzzle("1cf622579ace09c8f182b5640835416f")]
    public int Part2(string input) => new Cleaning().Part2(input);
    
    public class Cleaning
    {
        public int Part1(string input) => input.Split(LineBreaks.Single)
            .Where(o => o.Length > 0)
            .Select(ParseRanges)
            .Count(o => o.a.Contains(o.b) || o.b.Contains(o.a));

        public int Part2(string input) => input.Split(LineBreaks.Single)
            .Where(o => o.Length > 0)
            .Select(ParseRanges)
            .Count(o => o.a.Overlaps(o.b) || o.b.Overlaps(o.a));

        private (CleaningRange a, CleaningRange b) ParseRanges(string s)
        {
            var parts = s.Split(',', '-');
            var r1 = new CleaningRange(int.Parse(parts[0]), int.Parse(parts[1]));
            var r2 = new CleaningRange(int.Parse(parts[2]), int.Parse(parts[3]));
            return (r1, r2);
        }
    }
    
    public class CleaningRange(int from, int to)
    {
        private readonly int _from = from;
        private readonly int _to = to;

        public bool Contains(CleaningRange other) => other._from >= _from && other._to <= _to;

        public bool Overlaps(CleaningRange other) =>
            other._to >= _from && other._to <= _to || 
            other._from <= _to && other._from >= _from;
    }
}