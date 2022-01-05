using System.Collections.Generic;
using System.Linq;
using App.Common.Strings;

namespace App.Puzzles.Year2020.Day10;

public class PowerAdapterChain
{
    private readonly List<int> _adapters;
    public int DifferenceProduct { get; }

    public PowerAdapterChain(string input)
    {
        _adapters = PuzzleInputReader.ReadLines(input).Select(int.Parse).OrderBy(o => o).ToList();
        var currentValue = 0;
        var diffOneCount = 0;
        var diffThreeCount = 0;
        foreach (var adapter in _adapters)
        {
            var diff = adapter - currentValue;
            if (diff == 1)
                diffOneCount += 1;
            if (diff == 3)
                diffThreeCount += 1;
            currentValue = adapter;
        }

        diffThreeCount += 1;

        DifferenceProduct = diffOneCount * diffThreeCount;
    }

    public long GetTotalNumberOfCombinations()
    {
        var counts = new Dictionary<int, long>();
        var adapters = _adapters.OrderBy(o => o).ToList();
        adapters.Add(0);
        foreach (var adapter in adapters)
        {
            CalculateCount(counts, adapter);
        }

        return counts[0];
    }

    private long CalculateCount(IDictionary<int, long> counts, int adapter)
    {
        if (counts.ContainsKey(adapter))
            return counts[adapter];

        var possibleAdapters = _adapters.Where(o => IsWithinRange(adapter, o)).ToList();
        var count = possibleAdapters.Sum(nextAdapter => CalculateCount(counts, nextAdapter));

        if (count == 0)
            count = 1;

        counts.Add(adapter, count);
        return count;
    }

    private static bool IsWithinRange(int adapter, int nextAdapter)
    {
        var diff = nextAdapter - adapter;
        return diff > 0 && diff <= 3;
    }
}