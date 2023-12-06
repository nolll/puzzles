using Puzzles.Common.Strings;
using StringReader = Puzzles.Common.Strings.StringReader;

namespace Puzzles.Aoc.Puzzles.Aoc2022.Aoc202216;

// Very inspired by hyper-neutrino
// https://www.youtube.com/watch?v=bLMj50cpOug&t=657s
// https://github.com/hyper-neutrino/advent-of-code/blob/main/2022/day16p1.py
// I had an error in my optimization that I couldn't find.
// In the end I learned a little about bitwise operations.
public class VolcanicPipes
{
    private const string StartValve = "AA"; 

    private readonly Dictionary<string, int> _flows = new();
    private readonly Dictionary<string, int> _indices = new();
    private readonly Dictionary<string, Dictionary<string, int>> _dists = new();
    private readonly Dictionary<(int, string, int), int> _cache = new();
    private readonly List<string> _nonEmpty = new();

    public VolcanicPipes(string input)
    {
        var valves = new List<string>();
        var tunnels = new Dictionary<string, List<string>>();
        var lines = StringReader.ReadLines(input);

        foreach (var line in lines)
        {
            var parts = line.Split(';');
            var name = parts[0].Split(' ')[1];
            var rate = int.Parse(parts[0].Split(' ')[4].Split('=')[1]);
            var conn = parts[1].Split(' ').Skip(5).Select(o => o.Trim(',', ' ')).ToList();
            _flows.Add(name, rate);
            tunnels.Add(name, conn);
            valves.Add(name);
        }

        foreach (var valve in valves)
        {
            if (valve != StartValve && _flows[valve] == 0)
                continue;

            _dists[valve] = new Dictionary<string, int>
            {
                [valve] = 0
            };

            if(valve != StartValve)
            {
                _nonEmpty.Add(valve);
                _dists[valve][StartValve] = 0;
            }

            var visited = new HashSet<string> { valve };

            var queue = new Queue<(int, string)>();
            queue.Enqueue((0, valve));

            while (queue.Any())
            {
                var (distance, position) = queue.Dequeue();
                foreach (var neighbor in tunnels[position])
                {
                    if (visited.Contains(neighbor))
                        continue;

                    visited.Add(neighbor);

                    if (_flows[neighbor] > 0)
                        _dists[valve][neighbor] = distance + 1;

                    queue.Enqueue((distance + 1, neighbor));
                }
            }

            _dists[valve].Remove(valve);
            if (valve != StartValve)
                _dists[valve].Remove(StartValve);
        }

        for (var i = 0; i < _nonEmpty.Count; i++)
        {
            _indices[_nonEmpty[i]] = i;
        }
    }

    public int Part1()
    {
        const int time = 30;
        return Dfs(time, StartValve, 0);
    }

    public int Part2()
    {
        const int time = 26;
        var bitmaskMax = (1 << _nonEmpty.Count) - 1; // example, for five valves: 100000 -> 011111
        var maxVal = 0;
        var optimizedMax = bitmaskMax / 2; // each individual just needs to search half
        for (var bitmask = 0; bitmask <= optimizedMax; bitmask++)
        {
            var oppositeBitmask = bitmaskMax ^ bitmask; // 110011 -> 001100
            var result = Dfs(time, StartValve, bitmask) + Dfs(time, StartValve, oppositeBitmask);
            maxVal = Math.Max(maxVal, result);
        }

        return maxVal;
    }

    private int Dfs(int time, string valve, int bitmask)
    {
        if (_cache.TryGetValue((time, valve, bitmask), out var maxVal))
            return maxVal;

        foreach (var neighbor in _dists[valve])
        {
            var bit = 1 << _indices[neighbor.Key]; // Find current bit. 1 << 3 -> 1000
            if ((bit & bitmask) == bit) // If bit is set, this valve is already on
                continue;
            var remTime = time - neighbor.Value - 1;
            if (remTime <= 0)
                continue;

            var nextBitmask = bitmask | bit; // example, turning on bit 2: 110000 -> 110100
            maxVal = Math.Max(maxVal, Dfs(remTime, neighbor.Key, nextBitmask) + _flows[neighbor.Key] * remTime);
        }

        _cache[(time, valve, bitmask)] = maxVal;
        return maxVal;
    }
}