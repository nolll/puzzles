using System.Collections.Generic;
using System.Linq;
using Core.Tools;

namespace Core.XmasEncryption
{
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

        private bool IsSumOfTwoNumbers(long target, IList<long> numbers)
        {
            var permutations = PermutationGenerator.GetPermutations<long>(numbers, 2);
            return permutations.Any(o => o.Sum() == target);
        }
    }
}