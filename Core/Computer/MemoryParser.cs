using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Core.Computer
{
    public static class MemoryParser
    {
        public static IList<long> Parse(string input)
        {
            var data = input.Trim();
            var massStrings = data.Split(',');
            return massStrings.Select(long.Parse).ToList();
        }
    }
}