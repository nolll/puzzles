using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Tools
{
    public static class PuzzleInputReader
    {
        public static IList<string> ReadLines(string str)
        {
            return str.Trim().Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None).ToList();
        }

        public static IList<IList<string>> ReadGroups(string str)
        {
            return str.Trim().Split("\r\n\r\n").Select(ReadLines).ToList();
        }
    }
}