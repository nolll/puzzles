using Pzl.Common;
using Pzl.Tools.Numbers;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2025.Aoc202510;

[Name("Factory")]
[IsSlow]
[Comment("30s for part 1. Infinite for part 2.")]
public class Aoc202510 : AocPuzzle
{
    public PuzzleResult Part1(string input)
    {
        var items = input.Split(LineBreaks.Single).Select(Parse).ToList();
        var results = items.Select((o, index) =>
        {
            return SolvePart1(o.lights, o.buttons);
        });
        
        return new PuzzleResult(results.Sum(), "f19c91b91f25b5bde865c715075e4907");
    }

    public PuzzleResult Part2(string input)
    {
        var items = input.Split(LineBreaks.Single).Select(Parse).ToList();
        var results = items.Select((o, index) =>
        {
            return SolvePart2(o.counters, o.buttons);
        });
        
        return new PuzzleResult(results.Sum());
    }

    private static int SolvePart1(string lights, int[][] buttons)
    {
        var initialState = lights.Replace('#', '.');
        var seen = new Dictionary<string, int>();
        var queue = new Queue<(string state, int steps)>();
        queue.Enqueue((initialState, 0));
        while (queue.Count > 0)
        {
            var (state, steps) = queue.Dequeue();

            if (seen.TryGetValue(state, out var s1) && s1 < steps)
                continue;
            
            seen[state] = steps;
            
            foreach (var button in buttons)
            {
                var nextState = GetNextStatePart1(state, button);
                if (!seen.TryGetValue(nextState, out var s2) || s2 > steps + 1)
                    queue.Enqueue((nextState, steps + 1));
            }
        }
        
        return seen[lights];
    }
    
    private static int SolvePart2(string counters, int[][] buttons)
    {
        var targetState = Numbers.IntsFromString(counters);
        var initialState = string.Join(",", counters.Split(',').Select(_ => '0'));
        var seen = new Dictionary<string, int>();
        var queue = new Queue<(string state, int steps)>();
        queue.Enqueue((initialState, 0));
        while (queue.Count > 0)
        {
            var (state, steps) = queue.Dequeue();

            if (seen.TryGetValue(state, out var s1) && s1 < steps)
                continue;
            
            seen[state] = steps;
            var intState = Numbers.IntsFromString(state);
            
            foreach (var button in buttons)
            {
                var newIntState = GetNextStatePart2(intState, button);
                var newStrState = string.Join(",", newIntState);
                if (!seen.TryGetValue(newStrState, out var s2) || s2 > steps + 1)
                {
                    var isValid = true;
                    for (var i = 0; i < targetState.Length; i++)
                    {
                        if (newIntState[i] > targetState[i])
                        {
                            isValid = false;
                            break;
                        }
                    }
                    
                    if(isValid)
                        queue.Enqueue((newStrState, steps + 1));
                }
            }
        }
        
        return seen[counters];
    }

    private static string GetNextStatePart1(string state, int[] button)
    {
        var arr = state.Select(o => o == '#').ToArray();
        foreach (var i in button)
        {
            arr[i] = !arr[i];
        }

        return string.Join("", arr.Select(o => o ? '#' : '.'));
    }
    
    private static int[] GetNextStatePart2(int[] state, int[] button)
    {
        var newState = state.ToArray();
        foreach (var i in button)
        {
            newState[i] += 1;
        }

        return newState;
    }

    private static (string lights, int[][] buttons, string counters) Parse(string s)
    {
        var parts = s.Replace("[", "").Replace("]", "").Replace("(", "").Replace(")", "").Replace("{", "").Replace("}", "").Split(' ');
        var lights = parts.First();
        var buttons = parts.Skip(1).SkipLast(1).Select(Numbers.IntsFromString).ToArray();
        var counters = parts.Last();
        
        return (lights, buttons, counters);
    }
}