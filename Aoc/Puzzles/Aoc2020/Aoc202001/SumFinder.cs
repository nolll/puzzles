using Puzzles.Common.Combinatorics;
using Puzzles.Common.Strings;
using StringReader = Puzzles.Common.Strings.StringReader;

namespace Puzzles.Aoc.Puzzles.Aoc2020.Aoc202001;

public class SumFinder
{
    private readonly IList<int> _numbers;

    public SumFinder(string input)
    {
        _numbers = StringReader.ReadLines(input).Select(int.Parse).ToList();
    }

    public IList<int> FindNumbersThatAddUpTo(int target, int numbersToFind)
    {
        var permutations = PermutationGenerator.GetPermutations<int>(_numbers, numbersToFind);
        var match = permutations.First(o => o.Sum() == target);
        return match.ToList();
    }
}