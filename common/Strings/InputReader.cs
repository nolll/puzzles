﻿namespace common.Strings;

public static class InputReader
{
    public static IEnumerable<string> ReadLines(string str)
    {
        return str.Trim().Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None).ToList();
    }
}