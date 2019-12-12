using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Tools
{
    public static class StringListReader
    {
        public static List<string> Read(string str)
        {
            return str.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None).ToList();
        }
    }
}