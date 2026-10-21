using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2022;

// Very inspired by hyper-neutrino
// https://www.youtube.com/watch?v=bLMj50cpOug&t=657s
// https://github.com/hyper-neutrino/advent-of-code/blob/main/2022/day16p1.py
// I had an error in my optimization that I couldn't find.
// In the end I learned a little about bitwise operations.
[Name("Proboscidea Volcanium")]
public class Aoc202216 : AocPuzzle
{
    private const string StartValve = "AA";
    
    [Puzzle("dd3e51c50edd114901226b469c51dd40")]
    public int Part1(string input)
    {
        const int time = 30;
        var (flows, indices, dists, _) = Init(input);
        return Dfs(flows, indices, dists, [], time, StartValve, 0);
    }

    [Puzzle("29db1cdba5fd2b052581c68854027ea8")]
    public int Part2(string input)
    {
        const int time = 26;
        var cache = new Dictionary<(int, string, int), int>();
        var (flows, indices, dists, nonEmpty) = Init(input);
        var bitmaskMax = (1 << nonEmpty.Count) - 1; // example, for five valves: 100000 -> 011111
        var maxVal = 0;
        var optimizedMax = bitmaskMax / 2; // each individual just needs to search half
        for (var bitmask = 0; bitmask <= optimizedMax; bitmask++)
        {
            var oppositeBitmask = bitmaskMax ^ bitmask; // 110011 -> 001100
            var result = Dfs(flows, indices, dists, cache, time, StartValve, bitmask) +
                         Dfs(flows, indices, dists, cache, time, StartValve, oppositeBitmask);
            maxVal = Math.Max(maxVal, result);
        }

        return maxVal;
    }

    private (
        Dictionary<string, int> flows,
        Dictionary<string, int> indices,
        Dictionary<string, Dictionary<string, int>> dists,
        List<string> nonEmpty)
        Init(string input)
    {
        var valves = new List<string>();
        var tunnels = new Dictionary<string, List<string>>();
        var flows = new Dictionary<string, int>();
        var dists = new Dictionary<string, Dictionary<string, int>>();
        var indices = new Dictionary<string, int>();
        var nonEmpty = new List<string>();
        var lines = input.Split(LineBreaks.Single);

        foreach (var line in lines)
        {
            var parts = line.Split(';');
            var name = parts[0].Split(' ')[1];
            var rate = int.Parse(parts[0].Split(' ')[4].Split('=')[1]);
            var conn = parts[1].Split(' ').Skip(5).Select(o => o.Trim(',', ' ')).ToList();
            flows.Add(name, rate);
            tunnels.Add(name, conn);
            valves.Add(name);
        }

        foreach (var valve in valves)
        {
            if (valve != StartValve && flows[valve] == 0)
                continue;

            dists[valve] = new Dictionary<string, int>
            {
                [valve] = 0
            };

            if (valve != StartValve)
            {
                nonEmpty.Add(valve);
                dists[valve][StartValve] = 0;
            }

            var visited = new HashSet<string> { valve };

            var queue = new Queue<(int, string)>();
            queue.Enqueue((0, valve));

            while (queue.Count != 0)
            {
                var (distance, position) = queue.Dequeue();
                foreach (var neighbor in tunnels[position])
                {
                    if (!visited.Add(neighbor))
                        continue;

                    if (flows[neighbor] > 0)
                        dists[valve][neighbor] = distance + 1;

                    queue.Enqueue((distance + 1, neighbor));
                }
            }

            dists[valve].Remove(valve);
            if (valve != StartValve)
                dists[valve].Remove(StartValve);
        }

        for (var i = 0; i < nonEmpty.Count; i++) 
            indices[nonEmpty[i]] = i;

        return (flows, indices, dists, nonEmpty);
    }

    private static int Dfs(
        Dictionary<string, int> flows,
        Dictionary<string, int> indices,
        Dictionary<string, Dictionary<string, int>> dists,
        Dictionary<(int, string, int), int> cache,
        int time,
        string valve,
        int bitmask)
    {
        if (cache.TryGetValue((time, valve, bitmask), out var maxVal))
            return maxVal;

        foreach (var neighbor in dists[valve])
        {
            var bit = 1 << indices[neighbor.Key]; // Find current bit. 1 << 3 -> 1000
            if ((bit & bitmask) == bit) // If bit is set, this valve is already on
                continue;
            var remTime = time - neighbor.Value - 1;
            if (remTime <= 0)
                continue;

            var nextBitmask = bitmask | bit; // example, turning on bit 2: 110000 -> 110100
            maxVal = Math.Max(maxVal, Dfs(flows, indices, dists, cache, remTime, neighbor.Key, nextBitmask) + flows[neighbor.Key] * remTime);
        }

        cache[(time, valve, bitmask)] = maxVal;
        return maxVal;
    }
}