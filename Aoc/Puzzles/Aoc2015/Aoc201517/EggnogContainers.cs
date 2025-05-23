using Pzl.Tools.Combinatorics;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2015.Aoc201517;

public class EggnogContainers
{
    private readonly List<EggnogContainer> _containers;

    public EggnogContainers(string input)
    {
        _containers = StringReader.ReadLines(input).Select((o, index) => new EggnogContainer(index, int.Parse((string) o))).ToList();
    }
        
    public IList<List<EggnogContainer>> GetCombinations(int targetVolume) => 
        CombinationGenerator.GetUniqueCombinationsAnySize(_containers)
            .Where(o => o.Sum(c => c.Volume) == targetVolume)
            .ToList();

    public IList<List<EggnogContainer>> GetCombinationsWithLeastContainers(int targetVolume)
    {
        var combinations = GetCombinations(targetVolume).OrderBy(o => o.Count).ToList();
        var smallestCount = combinations.First().Count;
        return combinations.Where(o => o.Count == smallestCount).ToList();
    }
}