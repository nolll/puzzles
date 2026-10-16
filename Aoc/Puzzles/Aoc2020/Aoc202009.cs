using Pzl.Common;
using Pzl.Tools.Combinatorics;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2020;

[Name("Encoding Error")]
public class Aoc202009 : AocPuzzle
{
    [Puzzle("6c1a0cf69a058bbc7f0efbe438d2f8e7")]
    public long Part1(string input, int preambleLength = 25)
    {
        var values = Parse(input);
        for (var i = preambleLength; i < values.Count; i++)
        {
            var valuesToSkip = i - preambleLength;
            var previousNumbers = values.Skip(valuesToSkip).Take(preambleLength).ToList();
            if (!IsSumOfTwoNumbers(values[i], previousNumbers))
                return values[i];
        }

        return 0;
    }

    [Puzzle("b6c20cca8f108e6c19637716982ff96f")]
    public long Part2(string input, int preambleLength = 25)
    {
        var values = Parse(input);
        var invalidNumber = Part1(input, preambleLength);

        for (var i = 0; i < values.Count; i++)
        {
            var foundValues = new List<long>();
            var pos = i;
            long sum = 0;
            while (sum < invalidNumber)
            {
                var value = values[pos];
                foundValues.Add(value);
                sum += value;
                pos += 1;
            }

            if (sum == invalidNumber)
                return foundValues.Min() + foundValues.Max();
        }

        return 0;
    }

    private static bool IsSumOfTwoNumbers(long target, IList<long> numbers) =>
        PermutationGenerator.GetPermutations(numbers, 2).Any(o => o.Sum() == target);

    private static List<long> Parse(string input) =>
        input.Split(LineBreaks.Single).Select(long.Parse).ToList();
}