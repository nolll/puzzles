using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2020;

[Name("Adapter Array")]
public class Aoc202010 : AocPuzzle
{
    [Puzzle("56be819907a3ccd3fa53c9340c9cd2b7")]
    public int Part1(string input)
    {
        var adapters = Parse(input);
        var currentValue = 0;
        var diffOneCount = 0;
        var diffThreeCount = 0;
        foreach (var adapter in adapters)
        {
            var diff = adapter - currentValue;
            if (diff == 1)
                diffOneCount += 1;
            if (diff == 3)
                diffThreeCount += 1;
            currentValue = adapter;
        }

        diffThreeCount += 1;

        return diffOneCount * diffThreeCount;
    }

    [Puzzle("791600ed80a4c8e120ae60a88193043f")]
    public long Part2(string input)
    {
        var counts = new Dictionary<int, long>();
        var adapters = Parse(input).OrderBy(o => o).ToList();
        adapters.Add(0);
        foreach (var adapter in adapters) 
            CalculateCount(adapters, counts, adapter);

        return counts[0];
    }

    private static long CalculateCount(List<int> adapters, IDictionary<int, long> counts, int adapter)
    {
        if (counts.TryGetValue(adapter, out var c))
            return c;

        var possibleAdapters = adapters.Where(o => IsWithinRange(adapter, o)).ToList();
        var count = possibleAdapters.Sum(nextAdapter => CalculateCount(adapters, counts, nextAdapter));

        if (count == 0)
            count = 1;

        counts.Add(adapter, count);
        return count;
    }

    private static bool IsWithinRange(int adapter, int nextAdapter) => nextAdapter - adapter is > 0 and <= 3;
    private static List<int> Parse(string input) => input.Split(LineBreaks.Single).Select(int.Parse).OrderBy(o => o).ToList();
}