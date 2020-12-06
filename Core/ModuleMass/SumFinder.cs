using System.Collections.Generic;
using System.Linq;
using Core.Tools;

namespace Core.ModuleMass
{
    public class SumFinder
    {
        private readonly IList<int> _numbers;

        public SumFinder(string input)
        {
            _numbers = PuzzleInputReader.ReadLines(input).Select(int.Parse).ToList();
        }

        public IList<int> FindNumbersThatAddUpTo(int target, int numbersToFind)
        {
            var permutations = PermutationGenerator.GetPermutations<int>(_numbers, numbersToFind);
            var match = permutations.First(o => o.Sum() == target);
            return match.ToList();
        }
    }
}