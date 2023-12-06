namespace Pzl.Aoc.Puzzles.Aoc2019.Aoc201904;

public static class PasswordAnalyzer
{
    public static bool HasGroupOfTwo(IEnumerable<char> chars)
    {
        var groups = GetGroups(chars).Select(o => o.Count());
        return groups.Any(o => o == 2);
    }

    public static bool HasGroup(IEnumerable<char> chars)
    {
        var groups = GetGroups(chars).Select(o => o.Count());
        return groups.Any(o => o >= 2);
    }

    private static IEnumerable<IEnumerable<char>> GetGroups(IEnumerable<char> chars)
    {
        var lastChar = ' ';
        var groups = new List<IEnumerable<char>>();
        IList<char> currentGroup = new List<char>();
        foreach (var c in chars)
        {
            if (c == lastChar)
            {
                currentGroup.Add(c);
            }
            else
            {
                currentGroup = new List<char> { c };
                groups.Add(currentGroup);
            }

            lastChar = c;
        }

        return groups;
    }
}