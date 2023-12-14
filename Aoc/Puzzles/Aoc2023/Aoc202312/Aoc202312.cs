using System.Buffers;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;
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

        return new PuzzleResult(counts.Sum());
    }

    public static long CombinationCount(string s, bool isPart2 = false)
    {
        var parts = s.Split(' ');
        var layout = parts.First();
        var damagedGroups = parts.Last().Split(',').Select(int.Parse).ToList();

        if (isPart2)
        {
            var layouts2 = new List<string>();
            var damagedGroups2 = new List<int>();
            for (var i = 0; i < 5; i++)
            {
                layouts2.Add(layout);
                damagedGroups2.AddRange(damagedGroups);
            }

            layout = string.Join('?', layouts2);
            damagedGroups = damagedGroups2;
        }

        var seen = new Dictionary<string, long>();
        var count = GetValidCount(layout.ToCharArray().ToList(), damagedGroups, 0, "", seen);

        Console.WriteLine($"   {s}: {count}");

        return count;
    }

    private static long GetValidCount(
        List<char> layout, 
        List<int> damagedGroups, 
        int pos, string s,
        Dictionary<string, long> seen)
    {
        if (!IsValid(layout, s))
            return 0;

        if (damagedGroups.Count == 0)
            return layout.Skip(pos).Any(o => o == '#') ? 0 : 1;

        var minLength = damagedGroups.Sum() + damagedGroups.Count - 1;
        var loopLength = layout.Count - pos - minLength;
        var validCount = 0L;
        var groupSize = damagedGroups.First();
        for (var i = 0; i <= loopLength; i++)
        {
            var ns = $"{s}{GenerateString('.', i)}{GenerateString('#', groupSize)}.";
            if (seen.TryGetValue(ns, out var cached))
            {
                validCount += cached;
                continue;
            }

            var isAdjacentToDamaged = IsAdjacentToDamaged(layout, groupSize, pos + i);
            if (isAdjacentToDamaged)
                continue;

            var c = GetValidCount(layout, damagedGroups.Skip(1).ToList(), pos + i + groupSize + 1, ns, seen);
            validCount += c;
            seen.Add(ns, c);
            var isExactMatch = IsExactMatch(layout, groupSize, pos + i);
            if (isExactMatch)
                break;
        }

        return validCount;
    }

    private static bool IsValid(List<char> layout, string s)
    {
        var a = s.ToCharArray();
        for (var i = 0; i < Math.Min(layout.Count, s.Length); i++)
        {
            var isValid = layout[i] == '?' || layout[i] == a[i];
            if (!isValid)
                return false;
        }

        return true;
    }

    private static bool IsExactMatch(List<char> layout, int length, int pos)
    {
        for (var i = 0; i < length; i++)
        {
            if (layout[pos + i] != '#')
                return false;
        }

        return true;
    }

    private static bool IsAdjacentToDamaged(List<char> layout, int length, int pos)
    {
        if (pos > 0)
        {
            if (layout[pos - 1] == '#')
                return true;
        }

        if (pos + length < layout.Count - 1)
        {
            if (layout[pos + length] == '#')
                return true;
        }

        return false;
    }

    private static string GenerateString(char c, int length)
    {
        return string.Join("", Enumerable.Range(0, length).Select(o => c));
    }
}