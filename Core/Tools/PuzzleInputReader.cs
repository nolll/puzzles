using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Tools
{
    public static class PuzzleInputReader
    {
        public static IList<string> Read(string str)
        {
            return str.Trim().Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None).ToList();
        }
    }
}