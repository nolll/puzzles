using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Everybody.Puzzles.Ece2024.Ece202411;

[Name("Biological Warfare")]
public class Ece202411 : EverybodyEventPuzzle
{
    [Puzzle("cc639f849dfc284544c7bf69de29eeb5")]
    public long Part1(string input) => Solve(input, "A", 4);
    
    [Puzzle("e3f350e482453f5bf53e0c29f66820a6")]
    public long Part2(string input) => Solve(input, "Z", 10);

    [Puzzle("aa7535c76fba2d10eeeabdf3d5479c7a")]
    public long Part3(string input)
    {
        var conversions = ParseConversions(input);
        var termites = conversions.Keys;
        var results = termites.Select(termite => Solve(conversions, termite, 20)).ToList();
        return results.Max() - results.Min();
    }

    public long Solve(string input, string initalTermite, long days) => 
        Solve(ParseConversions(input), initalTermite, days);

    private static long Solve(Dictionary<string, string[]> conversions, string initalTermite, long days) => 
        CountTermites(conversions, new Dictionary<(string, long), long>(), initalTermite, days);
    
    private static long CountTermites(
        Dictionary<string, string[]> conversions, 
        Dictionary<(string, long), long> cache,
        string from, 
        long generation)
    {
        if (generation == 0)
            return 1;

        if (cache.TryGetValue((from, generation), out var nextCount))
            return nextCount;

        nextCount = conversions[from].Sum(o => CountTermites(conversions, cache, o, generation - 1));
        cache.TryAdd((from, generation), nextCount);

        return nextCount;
    }

    private static Dictionary<string, string[]> ParseConversions(string input)
    {
        var lines = input.Split(LineBreaks.Single);
        var conversions = new Dictionary<string, string[]>();
        foreach (var line in lines)
        {
            var parts = line.Split(':');
            var name = parts[0];
            var convertsTo = parts[1].Split(',').ToList();
            conversions.Add(name, convertsTo.ToArray());
        }

        return conversions;
    }
}