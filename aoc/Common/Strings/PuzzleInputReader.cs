using System;
using System.Collections.Generic;
using System.Linq;

namespace Aoc.Common.Strings;

public static class PuzzleInputReader
{
    public static IList<string> ReadLines(string str)
    {
        return ReadLines(str, true);
    }

    public static IList<string> ReadLines(string str, bool includeEmptyLines)
    {
        var lines = str.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
        if (!includeEmptyLines)
            return lines.Where(o => o.Length > 0).ToList();

        return lines.ToList();
    }

    public static IList<IList<string>> ReadLineGroups(string str)
    {
        return ReadStringGroups(str).Select(ReadLines).ToList();
    }

    public static IList<IList<string>> ReadLineGroupsWithWhiteSpace(string str)
    {
        return ReadStringGroupsWithWhitespace(str).Select(ReadLines).ToList();
    }

    public static IList<string> ReadStringGroups(string str)
    {
        return str.Trim().Split("\r\n\r\n").ToList();
    }

    public static IList<string> ReadStringGroupsWithWhitespace(string str)
    {
        return str.Split("\r\n\r\n").ToList();
    }
}