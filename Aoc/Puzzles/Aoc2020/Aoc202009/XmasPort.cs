using Pzl.Tools.Combinatorics;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2020.Aoc202009;

public class XmasPort(string input, int preambleLength)
{
    private readonly IList<long> _values = input.Split(LineBreaks.Single).Select(long.Parse).ToList();

    public long FindFirstInvalidNumber()
    {
        for (var i = preambleLength; i < _values.Count; i++)
        {
            var valuesToSkip = i - preambleLength;
            var previousNumbers = _values.Skip(valuesToSkip).Take(preambleLength).ToList();
            if (!IsSumOfTwoNumbers(_values[i], previousNumbers))
                return _values[i];
        }

        return 0;
    }

    public long FindWeakness()
    {
        var invalidNumber = FindFirstInvalidNumber();

        for (var i = 0; i < _values.Count; i++)
        {
            var foundValues = new List<long>();
            var pos = i;
            long sum = 0;
            while (sum < invalidNumber)
            {
                var value = _values[pos];
                foundValues.Add(value);
                sum += value;
                pos += 1;
            }

            if (sum == invalidNumber)
            {
                return foundValues.Min() + foundValues.Max();
            }
        }

        return 0;
    }

    private static bool IsSumOfTwoNumbers(long target, IList<long> numbers) => 
        PermutationGenerator.GetPermutations(numbers, 2).Any(o => o.Sum() == target);
}