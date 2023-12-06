using Puzzles.Common.Strings;

namespace Puzzles.Aoc.Puzzles.Aoc2022.Aoc202203;

public static class Rucksacks
{
    public static int GetPriority1(string input)
    {
        var lines = InputReader.ReadLines(input, false);
        return GetPrioritySumForLines(lines);
    }

    public static int GetPriority2(string input)
    {
        var lines = InputReader.ReadLines(input, false);
        return GetPrioritySumForGroups(lines);
    }

    private static int GetPrioritySumForLines(IList<string> lines)
    {
        var partsList = lines.Select(SplitInTwo);
        return partsList.Sum(parts => GetPriorityForLine(parts[0], parts[1]));
    }

    private static int GetPriorityForLine(string s1, string s2)
    {
        var a1 = s1.ToCharArray();
        var a2 = s2.ToCharArray();
        foreach (var c in a1)
        {
            if (a2.Contains(c))
            {
                return GetPriority(c);
            }
        }

        return 0;
    }

    private static int GetPrioritySumForGroups(IList<string> lines)
    {
        var totalSum = 0;

        for (var i = 0; i < lines.Count(); i += 3)
        {
            totalSum += GetPriorityForGroup(lines[i], lines[i + 1], lines[i + 2]);
        }

        return totalSum;
    }

    private static int GetPriorityForGroup(string s1, string s2, string s3)
    {
        var a1 = s1.ToCharArray();
        var a2 = s2.ToCharArray();
        var a3 = s3.ToCharArray();

        foreach (var c in a1)
        {
            if (a2.Contains(c) && a3.Contains(c))
            {
                return GetPriority(c);
            }
        }

        return 0;
    }

    private static int GetPriority(char c)
    {
        return char.IsUpper(c)
            ? c - 38
            : c - 96;
    }

    private static string[] SplitInTwo(string s)
    {
        return new[]
        {
            s[..(s.Length / 2)],
            s[(s.Length / 2)..]
        };
    }
}