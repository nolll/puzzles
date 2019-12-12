using System.Collections.Generic;
using System.Linq;
using Core.Tools;

namespace Core.Frequencies
{
    public static class IntListReader
    {
        public static List<int> Read(string str)
        {
            return StringListReader.Read(str).Select(ConvertToInt).ToList();
        }

        private static int ConvertToInt(string str)
        {
            return int.Parse(str);
        }
    }
}