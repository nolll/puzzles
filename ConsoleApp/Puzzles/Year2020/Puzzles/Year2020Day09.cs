using System.Collections.Generic;
using System.Linq;
using Core.Tools;

namespace ConsoleApp.Puzzles.Year2020.Puzzles
{
    public class Year2020Day09 : Year2020Day
    {
        public override int Day => 9;

        public override PuzzleResult RunPart1()
        {
            var port = new XmasPort(FileInput, 25);
            var invalidNumber = port.FindFirstInvalidNumber();
            return new PuzzleResult(invalidNumber, 32321523);
        }

        public override PuzzleResult RunPart2()
        {
            var port = new XmasPort(FileInput, 25);
            var weakness = port.FindWeakness();
            return new PuzzleResult(weakness, 4794981);
        }
    }

    public class XmasPort
    {
        private readonly IList<long> _values;
        private readonly int _preambleLength;

        public XmasPort(string input, int preambleLength)
        {
            _values = PuzzleInputReader.ReadLines(input).Select(long.Parse).ToList();
            _preambleLength = preambleLength;
        }

        public long FindFirstInvalidNumber()
        {
            for (var i = _preambleLength; i < _values.Count; i++)
            {
                var valuesToSkip = i - _preambleLength;
                var previousNumbers = _values.Skip(valuesToSkip).Take(_preambleLength).ToList();
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

        private static bool IsSumOfTwoNumbers(long target, IList<long> numbers)
        {
            var permutations = PermutationGenerator.GetPermutations(numbers, 2);
            return permutations.Any(o => o.Sum() == target);
        }
    }
}