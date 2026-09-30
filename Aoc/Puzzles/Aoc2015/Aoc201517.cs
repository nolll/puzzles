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

    private static EggnogContainer[] Parse(string input) =>
        [.. input.Split(LineBreaks.Single).Select((o, index) => new EggnogContainer(index, int.Parse(o)))];

    public IEnumerable<List<EggnogContainer>> GetCombinations(string input, int targetVolume) =>
        CombinationGenerator.GetUniqueCombinationsAnySize(Parse(input))
            .Where(o => o.Sum(c => c.Volume) == targetVolume);

    private IEnumerable<List<EggnogContainer>> GetCombinationsWithLeastContainers(string input, int targetVolume)
    {
        var combinations = GetCombinations(input, targetVolume).ToList();
        var minCount = combinations.Min(c => c.Count);
        return combinations.Where(o => o.Count == minCount);
    }

    public class EggnogContainer(int id, int volume) : IEquatable<EggnogContainer>
    {
        private readonly int _id = id;
        public int Volume { get; } = volume;

        public bool Equals(EggnogContainer? other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return _id == other._id;
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((EggnogContainer)obj);
        }

        public override int GetHashCode() => _id;
    }
}