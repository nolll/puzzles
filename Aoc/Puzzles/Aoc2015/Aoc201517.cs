using Pzl.Common;
using Pzl.Tools.Combinatorics;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2015;

[Name("No Such Thing as Too Much")]
public class Aoc201517 : AocPuzzle
{
    [Puzzle("5c9cb3225ec72026a92a9d18b0257800")]
    public int Part1(string input) => GetCombinations(input, 150).Count();

    [Puzzle("b5099aa249856738b5000cb46145f473")]
    public int Part2(string input) => GetCombinationsWithLeastContainers(input, 150).Count();

    private static Container[] Parse(string input) =>
        [.. input.Split(LineBreaks.Single).Select((o, index) => new Container(index, int.Parse(o)))];

    public IEnumerable<List<Container>> GetCombinations(string input, int targetVolume) =>
        CombinationGenerator.GetUniqueCombinationsAnySize(Parse(input))
            .Where(o => o.Sum(c => c.Volume) == targetVolume);

    private IEnumerable<List<Container>> GetCombinationsWithLeastContainers(string input, int targetVolume)
    {
        var combinations = GetCombinations(input, targetVolume).ToList();
        var minCount = combinations.Min(c => c.Count);
        return combinations.Where(o => o.Count == minCount);
    }

    public record Container(int Id, int Volume);
}