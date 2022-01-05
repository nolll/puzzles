using System.Collections.Generic;
using System.Linq;

namespace App.Common.Computers.IntCode;

public static class MemoryParser
{
    public static IList<long> Parse(string input)
    {
        var data = input.Trim();
        var massStrings = data.Split(',');
        return massStrings.Select(long.Parse).ToList();
    }
}