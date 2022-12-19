using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Puzzles.Year2022.Day16;

public class VolcanicPipes
{
    private const int TotalTime = 30;
    private readonly Dictionary<string, int> _seen = new();

    public long Part1(string input)
    {
        var data = new ValveData(input);
        var (maxPressure, path) = GetMaxPressure(data.Valves, data.Rates, data.Connections);

        Console.WriteLine(path);

        return maxPressure;
    }

    private (long,string) GetMaxPressure(
        List<string> allValves,
        Dictionary<string, int> rates,
        Dictionary<string, List<ValveConnection>> connections)
    {
        var openValves = allValves.Where(o => rates[o] == 0).ToList();
        var closedValves = allValves.Where(o => rates[o] > 0).ToList();
        const long accumulatedPressure = 0;
        const int time = 0;
        const string current = "AA";
        _seen.Add(BuildId(current, closedValves), 0);

        return GetBestPressure(current, accumulatedPressure, time, openValves, closedValves, connections, rates, 1, current);
    }

    private (long, string) GetBestPressure(string current,
        long accumulatedPressure,
        int time,
        List<string> openValves,
        List<string> closedValves,
        Dictionary<string, List<ValveConnection>> connections,
        Dictionary<string, int> rates,
        int level,
        string actions)
    {
        //Console.WriteLine($"level: {level}, time: {time}");
        var id = BuildId(current, closedValves);
        if (_seen.TryGetValue(id, out var seenTime) && seenTime < time)
        {
            return (0, actions);
        }
        _seen[id] = time;

        if (time >= TotalTime)
        {
            return (accumulatedPressure, actions);
        }

        if (!closedValves.Any())
        {
            return (accumulatedPressure + openValves.Select(o => rates[o]).Sum() * (TotalTime - time), actions);
        }

        var isOpen = openValves.Contains(current);
        var candidates = new List<(long, string)>();
        var newPressure = accumulatedPressure + openValves.Select(o => rates[o]).Sum();


        if (!isOpen)
        {
            var newOpen = openValves.ToList();
            newOpen.Add(current);
            var newClosed = closedValves.Where(o => o != current).ToList();
            var oc = GetBestPressure(current, newPressure, time + 1, newOpen, newClosed, connections, rates, level + 1, actions + "->open");
            candidates.Add(oc);
        }

        var currentConnections = connections[current];
        foreach (var c in currentConnections)
        {
            var newOpen = openValves.ToList();
            var newClosed = closedValves.ToList();
            var oc = GetBestPressure(c.Valve, newPressure, time + 1, newOpen, newClosed, connections, rates, level + 1, actions + "," + c.Valve);
            candidates.Add(oc);
        }

        return candidates.Count > 0 ? candidates.MaxBy(o => o.Item1) : (0, actions);
    }

    private string BuildId(string current, List<string> closedValves)
    {
        return $"{current}--{string.Join(',', closedValves)}";
    }
}