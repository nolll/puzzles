using Pzl.Common;
using Pzl.Tools.Numbers;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2025.Aoc202510;

[Name("Factory")]
public class Aoc202510 : AocPuzzle
{
    public PuzzleResult Part1(string input)
    {
        var items = input.Split(LineBreaks.Single).Select(Parse).ToList();
        var results = items.Select(o => Solve(o.lights, o.buttons));
        
        return new PuzzleResult(results.Sum(), "f19c91b91f25b5bde865c715075e4907");
    }

    public PuzzleResult Part2(string input)
    {
        return new PuzzleResult(0);
    }

    private static int Solve(string lights, int[][] buttons)
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
                var nextState = GetNextState(state, button);
                if (!seen.TryGetValue(nextState, out var s2) || s2 > steps + 1)
                    queue.Enqueue((nextState, steps + 1));
            }
        }
        
        return seen[lights];
    }

    private static string GetNextState(string state, int[] button)
    {
        var arr = state.Select(o => o == '#').ToArray();
        foreach (var i in button)
        {
            arr[i] = !arr[i];
        }

        return string.Join("", arr.Select(o => o ? '#' : '.'));
    }

    private static (string lights, int[][] buttons) Parse(string s)
    {
        var parts = s.Replace("[", "").Replace("]", "").Replace("(", "").Replace(")", "").Replace("{", "").Replace("}", "").Split(' ');
        var lights = parts.First();
        var buttons = parts.Skip(1).SkipLast(1).Select(Numbers.IntsFromString).ToArray();
        
        return (lights, buttons);
    }
}