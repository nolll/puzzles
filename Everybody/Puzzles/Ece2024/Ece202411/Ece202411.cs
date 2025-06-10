using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Everybody.Puzzles.Ece2024.Ece202411;

[Name("Biological Warfare")]
public class Ece202411 : EverybodyEventPuzzle
{
    public PuzzleResult Part1(string input)
    {
        var result = Solve(input, "A", 4);
        return new PuzzleResult(result, "cc639f849dfc284544c7bf69de29eeb5");
    }
    
    public PuzzleResult Part2(string input)
    {
        var result = Solve(input, "Z", 10);
        return new PuzzleResult(result, "e3f350e482453f5bf53e0c29f66820a6");
    }
    
    public PuzzleResult Part3(string input)
    {
        var conversions = ParseConversions(input);
        var termites = conversions.Keys;
        var results = termites.Select(termite => Solve(conversions, termite, 20)).ToList();
        var diff = results.Max() - results.Min();
        
        return new PuzzleResult(diff, "aa7535c76fba2d10eeeabdf3d5479c7a");
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