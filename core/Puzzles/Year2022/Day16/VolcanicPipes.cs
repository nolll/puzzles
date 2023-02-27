using System;
using System.Collections.Generic;
using System.Linq;
using Core.Common.Strings;

namespace Core.Puzzles.Year2022.Day16;

// Very inspired by hyper-neutrino
// https://www.youtube.com/watch?v=bLMj50cpOug&t=657s
// https://github.com/hyper-neutrino/advent-of-code/blob/main/2022/day16p1.py
public class VolcanicPipes
{
    private readonly Dictionary<string, int> _flows;
    private readonly Dictionary<string, int> _indices;
    private readonly Dictionary<string, Dictionary<string, int>> _dists;
    private readonly Dictionary<(int, string, int), int> _cache;

    public VolcanicPipes(string input)
    {
        _flows = new Dictionary<string, int>();
        _indices = new Dictionary<string, int>();
        _dists = new Dictionary<string, Dictionary<string, int>>();
        _cache = new Dictionary<(int, string, int), int>();
        
        var valves = new List<string>();
        var tunnels = new Dictionary<string, List<string>>();
        var nonEmpty = new List<string>();
        var lines = PuzzleInputReader.ReadLines(input);

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
            if (valve != "AA" && _flows[valve] == 0)
                continue;

            _dists[valve] = new Dictionary<string, int>
            {
                [valve] = 0
            };

            if(valve != "AA")
            {
                nonEmpty.Add(valve);
                _dists[valve]["AA"] = 0;
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
            if (valve != "AA")
                _dists[valve].Remove("AA");
        }

        for (var i = 0; i < nonEmpty.Count; i++)
        {
            _indices[nonEmpty[i]] = i;
        }
    }

    public int Part1()
    {
        return Dfs(30, "AA", 0);
    }

    private int Dfs(int time, string valve, int bitmask)
    {
        if (_cache.TryGetValue((time, valve, bitmask), out var maxVal))
            return maxVal;

        foreach (var neighbor in _dists[valve])
        {
            var bit = 1 << _indices[neighbor.Key];
            if ((bit & bitmask) == bit)
                continue;
            var remTime = time - neighbor.Value - 1;
            if (remTime <= 0)
                continue;
            maxVal = Math.Max(maxVal, Dfs(remTime, neighbor.Key, bitmask | bit) + _flows[neighbor.Key] * remTime);
        }

        _cache[(time, valve, bitmask)] = maxVal;
        return maxVal;
    }
}