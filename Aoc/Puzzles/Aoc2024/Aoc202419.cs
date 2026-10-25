using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2024;

[Name("Linen Layout")]
public class Aoc202419 : AocPuzzle
{
    [Puzzle("74853ae023c415398e9e1aa4ee83c0f1")]
    public int Part1(string input)
    {
        var (towels, combinations) = Parse(input);
        return combinations.Count(o => IsPossible(towels, o));
    }

    [Puzzle("83d5af4b54081e746c3cfc203a9a544e")]
    public long Part2(string input)
    {
        var (towels, combinations) = Parse(input);
        return combinations.Sum(o => CountCombinations(towels, o, new Dictionary<string, long>()));
    }
    
    private static bool IsPossible(HashSet<string> towels, string combination)
    {
        if (combination == "")
            return true;
        
        foreach (var towel in towels)
        {
            if (!combination.StartsWith(towel))
                continue;
            
            if (combination.Length >= towel.Length && IsPossible(towels, combination[towel.Length..]))
                return true;
        }

        return false;
    }
    
    private static long CountCombinations(HashSet<string> towels, string combination, Dictionary<string, long> seen)
    {
        if (seen.TryGetValue(combination, out var combinations))
            return combinations;
        
        if (combination == "")
            return 1;
        
        var count = 0L;
        foreach (var towel in towels)
        {
            if (combination.StartsWith(towel) && combination.Length >= towel.Length)
            {
                count += CountCombinations(towels, combination[towel.Length..], seen);
            }
        }

        seen[combination] = count;
        return count;
    }

    private static (HashSet<string>, string[]) Parse(string input)
    {
        var parts = input.Split(LineBreaks.Double);
        var towels = parts[0].Split(", ").ToHashSet();
        var combinations = parts[1].Split(LineBreaks.Single);
        return (towels, combinations);
    }
}