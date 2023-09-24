using System.Collections.Generic;

namespace Aoc.Puzzles.Aoc2022.Day06;

internal static class TuningTrouble
{
    public static int FindMarker(string input)
    {
        return Find(input, 4);
    }

    public static int FindMessage(string input)
    {
        return Find(input, 14);
    }

    private static int Find(string input, int searchLength)
    {
        for (var i = searchLength; i < input.Length; i++)
        {
            if (IsAllUnique(input[(i - searchLength)..i]))
                return i;
        }

        return 0;
    }

    private static bool IsAllUnique(string s)
    {
        var set = new HashSet<char>(s.ToCharArray());
        return set.Count == s.Length;
    }
}