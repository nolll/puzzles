using System.Collections.Generic;
using System.Linq;
using Aoc.Common.Combinatorics;
using Aoc.Common.Strings;

namespace Aoc.Puzzles.Year2015.Day17;

public class EggnogContainers
{
    private readonly List<EggnogContainer> _containers;

    public EggnogContainers(string input)
    {
        _containers = PuzzleInputReader.ReadLines(input).Select((o, index) => new EggnogContainer(index, int.Parse((string) o))).ToList();
    }
        
    public IList<List<EggnogContainer>> GetCombinations(int targetVolume)
    {
        var combinations = CombinationGenerator.GetAllCombinationsAnySize(_containers);
        return combinations.Where(o => o.Sum(c => c.Volume) == targetVolume).ToList();
    }

    public IList<List<EggnogContainer>> GetCombinationsWithLeastContainers(int targetVolume)
    {
        var combinations = GetCombinations(targetVolume).OrderBy(o => o.Count).ToList();
        var smallestCount = combinations.First().Count;
        return combinations.Where(o => o.Count == smallestCount).ToList();
    }
}