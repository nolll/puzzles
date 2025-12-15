using Pzl.Common;
using Pzl.Tools.Combinatorics;
using Pzl.Tools.Numbers;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2025.Aoc202510;

[Name("Factory")]
// Thanks to Tenth Mascot
public class Aoc202510 : AocPuzzle
{
    public PuzzleResult Part1(string input)
    {
        var items = input.Split(LineBreaks.Single).Select(Parse).ToList();
        var results = items.Select(o => SolvePart1(o.lights, o.buttons));
        
        return new PuzzleResult(results.Sum(), "f19c91b91f25b5bde865c715075e4907");
    }

    public PuzzleResult Part2(string input)
    {
        var items = input.Split(LineBreaks.Single).Select(Parse).ToList();
        var result = items.Select(o => SolvePart2(o.counters, o.buttons)).ToList();
        
        return new PuzzleResult(result.Sum(), "328efb57c96e68e01778dad1dd089540");
    }

    private static int SolvePart1(string targetLights, int[][] buttons)
    {
        var from = targetLights.Replace('#', '.');
        var combinations = FindCombinations(from, targetLights, buttons);

        return combinations.Min(o => o.Count);
    }

    private static IEnumerable<List<int[]>> FindCombinations(string initialState, string to, int[][] buttons)
    {
        var combinations = CombinationGenerator.GetUniqueCombinationsAnySize(buttons);
        foreach (var combination in combinations)
        {
            var state = initialState.Select(o => o == '#').ToArray();
            foreach (var button in combination)
            {
                foreach (var index in button)
                {
                    state[index] = !state[index];
                }
            }
            
            if(string.Join("", state.Select(o => o ? '#' : '.')) == to)
                yield return combination;
        }
    }
    
    private static long SolvePart2(int[] counters, int[][] buttons)
    {
        var patterns = GetPatternsCache(buttons, counters.Length);
        var result = SolveRecursive(patterns, counters, []);

        return result;
    }

    private static IEnumerable<(int[] pattern, long cost)> GetPatterns(int[][] buttons, int size)
    {
        var combinations = CombinationGenerator.GetUniqueCombinationsAnySize(buttons);
        combinations.Add([]);
        foreach (var combination in combinations)
        {
            var a = new int[size];
            foreach (var button in combination)
            {
                foreach (var index in button)
                {
                    a[index] += 1;
                }
            }
            
            yield return (a, combination.Count);
        }
    }
    
    private static Dictionary<string, List<(int[] pattern, long cost)>> GetPatternsCache(int[][] buttons, int size)
    {
        var patterns = GetPatterns(buttons, size);

        var dict = new Dictionary<string, List<(int[] pattern, long cost)>>();
        foreach (var (pattern, cost) in patterns)
        {
            var key = string.Join("", pattern.Select(o => o % 2 == 1 ? '#' : '.'));
            dict.TryAdd(key, []);
            dict[key].Add((pattern, cost));
        }

        return dict;
    }

    private static long SolveRecursive(Dictionary<string, List<(int[] pattern, long cost)>> patterns, int[] goal, Dictionary<string, long> cache)
    {
        var key = string.Join(",", goal);
        if (cache.TryGetValue(key, out var score))
            return score;
        
        if (goal.All(o => o == 0))
        {
            cache.TryAdd(key, score);
            return 0;
        }

        score = 1_000_000L;
        var patternKey = string.Join("", goal.Select(o => o % 2 == 1 ? '#' : '.'));
        if (patterns.TryGetValue(patternKey, out var currentPatterns))
        {
            foreach (var (pattern, cost) in currentPatterns)
            {
                var zip = pattern.Zip(goal).ToList();
                if (!zip.All(o => o.First <= o.Second)) continue;
                var newGoal = zip.Select(o => (o.Second - o.First) / 2).ToArray();
                var next = SolveRecursive(patterns, newGoal, cache);
                score = Math.Min(score, cost + 2 * next);
            }
        }
        cache.TryAdd(key, score);
        return score;
    }

    private static (string lights, int[][] buttons, int[] counters) Parse(string s)
    {
        var parts = s.Replace("[", "").Replace("]", "").Replace("(", "").Replace(")", "").Replace("{", "").Replace("}", "").Split(' ');
        var lights = parts.First();
        var buttons = parts.Skip(1).SkipLast(1).Select(Numbers.IntsFromString).ToArray();
        var counters = Numbers.IntsFromString(parts.Last());
        
        return (lights, buttons, counters);
    }
}