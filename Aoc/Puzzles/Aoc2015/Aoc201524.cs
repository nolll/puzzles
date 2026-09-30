using Pzl.Common;
using Pzl.Tools.Combinatorics;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2015;

[Name("It Hangs in the Balance")]
public class Aoc201524 : AocPuzzle
{
    [Puzzle("112caddb8448ec5cdd5bfca087f393aa")]
    public long Part1(string input) => GetQuantumEntanglementOfFirstGroup(input, 3);

    [Puzzle("d1eb70991c3477542b3499f754799982")]
    public long Part2(string input) => GetQuantumEntanglementOfFirstGroup(input, 4);

    public long GetQuantumEntanglementOfFirstGroup(string input, int groupCount)
    {
        var presents = input.Split(LineBreaks.Single).Select(long.Parse).ToList();
        presents.Reverse();
        var partitionSum = presents.Sum() / groupCount;
        var groups = FindGroups(presents, partitionSum);
        var quantumEntanglements = groups.Select(o => o.Aggregate((long)1, (x, y) => x * y));
        return quantumEntanglements.Min();
    }

    private static IEnumerable<IEnumerable<long>> FindGroups(List<long> presents, long partitionSum)
    {
        var count = 1;
        while(count < presents.Count)
        {
            var combinations = CombinationGenerator.GetUniqueCombinationsFixedSize(presents, count);
            var valid = combinations.Where(o => o.Sum() == partitionSum).ToList();
            if (valid.Count > 0)
                return valid;
            
            count++;
        }

        return [];
    }
}