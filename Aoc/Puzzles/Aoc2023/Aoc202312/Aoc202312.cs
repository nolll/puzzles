using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2023.Aoc202312;

[Name("Hot Springs")]
public class Aoc202312(string input) : AocPuzzle
{
    protected override PuzzleResult RunPart1()
    {
        var lines = StringReader.ReadLines(input);
        var counts = lines.Select(o => CombinationCount(o));

        return new PuzzleResult(counts.Sum(), "ec83138b082ab4da38bb60e88263c52f");
    }

    protected override PuzzleResult RunPart2()
    {
        var lines = StringReader.ReadLines(input);
        var counts = lines.Select(o => CombinationCount(o, true));

        return new PuzzleResult(counts.Sum(), "2ecb30790515e2ebbae12a478dbf36f7");
    }

    public static long CombinationCount(string s, bool isPart2 = false)
    {
        var parts = s.Split(' ');
        var pattern = parts.First();
        var groups = parts.Last().Split(',').Select(int.Parse).ToList();

        if (isPart2)
        {
            var pattern2 = new List<string>();
            var groups2 = new List<int>();
            for (var i = 0; i < 5; i++)
            {
                pattern2.Add(pattern);
                groups2.AddRange(groups);
            }

            pattern = string.Join('?', pattern2);
            groups = groups2;
        }

        var seen = new Dictionary<(string, string), long>();
        return GetValidCount(pattern.ToCharArray(), groups.ToArray(), seen);
    }

    private static long GetValidCount(
        char[] pattern,
        int[] groups,
        Dictionary<(string, string), long> seen)
    {
        if (pattern.Length == 0)
            return groups.Length == 0 ? 1 : 0;

        if (groups.Length == 0)
            return pattern.Any(o => o == '#') ? 0 : 1;

        var cacheKey = (string.Join("", pattern), string.Join(",", groups));
        if (seen.TryGetValue(cacheKey, out var validCount))
            return validCount;

        var c = pattern.First();
        if (c is '.' or '?')
        {
            validCount += GetValidCount(pattern.Skip(1).ToArray(), groups, seen);
        }

        if (c is '#' or '?')
        {
            var groupLength = groups.First();
            if (groupLength <= pattern.Length)
            {
                var matchesGroup = !pattern.Take(groupLength).Contains('.');
                if (matchesGroup)
                {
                    var hasAdjacentGroup = pattern.Length > groupLength && pattern[groupLength] == '#';
                    if (!hasAdjacentGroup) 
                        validCount += GetValidCount(pattern.Skip(groupLength + 1).ToArray(), groups.Skip(1).ToArray(), seen);
                }
            }
        }

        seen.Add(cacheKey, validCount);

        return validCount;
    }
}