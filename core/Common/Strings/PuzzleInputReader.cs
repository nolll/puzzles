using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Common.Strings;

public static class PuzzleInputReader
{
    public static IList<string> ReadLines(string str)
    {
        return str.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None).Where(o => o.Length > 0).ToList();
    }

    public static IList<IList<string>> ReadLineGroups(string str)
    {
        return ReadStringGroups(str).Select(ReadLines).ToList();
    }

    public static IList<string> ReadStringGroups(string str)
    {
        return str.Trim().Split("\r\n\r\n").ToList();
    }
}