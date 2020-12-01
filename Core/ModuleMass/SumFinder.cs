using System.Collections.Generic;
using System.Linq;
using Core.Tools;

namespace Core.ModuleMass
{
    public class SumFinder
    {
        private readonly IEnumerable<int> _numbers;

        public SumFinder(string input)
        {
            _numbers = PuzzleInputReader.Read(input).Select(int.Parse);
        }

        public (int a, int b) FindNumbersThatAddUpTo(int target)
        {
            foreach (var number in _numbers)
            {
                var found = _numbers.Where(o => o + number == target).ToList();
                if (found.Any())
                    return (number, found.First());
            }

            return (0, 0);
        }
    }
}