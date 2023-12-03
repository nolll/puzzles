using Puzzles.common.Combinatorics;
using Puzzles.common.Strings;

namespace Puzzles.aoc.Puzzles.Aoc2015.Aoc201524;

public class PresentBalancer
{
    public long QuantumEntanglementOfFirstGroup { get; }

    public PresentBalancer(string input, int groupCount)
    {
        var presents = StringReader.ReadLines(input).Select(long.Parse).ToList();
        presents.Reverse();
        var sum = presents.Sum();
        var partitionSum = sum / groupCount;
        var groups = FindGroups(presents, partitionSum);
        var quantumEntanglements = groups.Select(o => o.Aggregate((long)1, (x, y) => x * y));
        QuantumEntanglementOfFirstGroup = quantumEntanglements.Min();
    }

    private IEnumerable<IEnumerable<long>> FindGroups(List<long> presents, long partitionSum)
    {
        var count = 1;
        while(count < presents.Count)
        {
            var combinations = CombinationGenerator.GetUniqueCombinationsFixedSize(presents, count);
            var valid = combinations.Where(o => o.Sum() == partitionSum);
            if (valid.Any())
            {
                return valid;
            }
            count++;
        }

        return Enumerable.Empty<IEnumerable<long>>();
    }
}