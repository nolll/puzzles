using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Puzzles.Year2022.Day16;

public class VolcanicPipes
{
    private readonly Dictionary<string, int> _seen = new();
    private readonly List<string> _valves;
    private readonly Dictionary<string, int> _rates;
    private readonly Dictionary<string, List<ValveConnection>> _connections;

    public VolcanicPipes(string input)
    {
        var data = new ValveData(input);
        _valves = data.Valves;
        _rates = data.Rates;
        _connections = data.Connections;

    }
    
    public int Part1()
    {
        var maxPressure = GetMaxPressure();

        return maxPressure;
    }

    private int GetMaxPressure()
    {
        var openValves = _valves.Where(o => _rates[o] == 0).ToList();
        var closedValves = _valves.Where(o => _rates[o] > 0).ToList();
        return GetBestPressure("AA", 30, openValves, closedValves);
    }

    private int GetBestPressure(
        string current,
        int time,
        List<string> openValves,
        List<string> closedValves)
    {
        if (time <= 0)
            return 0;

        var id = BuildId(time, current, closedValves);
        if (_seen.TryGetValue(id, out var seenPressure))
        {
            return seenPressure;
        }

        if (!closedValves.Any())
        {
            return openValves.Select(o => _rates[o]).Sum() * time;
        }

        var newPressure = openValves.Select(o => _rates[o]).Sum();
        var isOpen = openValves.Contains(current);
        var best = 0;

        if (!isOpen)
        {
            var newOpen = openValves.ToList();
            newOpen.Add(current);
            var newClosed = closedValves.Where(o => o != current).Order().ToList();
            var oc = newPressure + GetBestPressure(current, time - 1, newOpen, newClosed);
            best = Math.Max(best, oc);
        }

        foreach (var c in _connections[current])
        {
            var oc = newPressure + GetBestPressure(c.Valve, time - c.Cost, openValves, closedValves);
            best = Math.Max(best, oc);
        }

        _seen[id] = best;
        return best;
    }
    
    private static string BuildId(int time, string current, IEnumerable<string> closedValves)
    {
        return $"{time}--{current}--{string.Join(',', closedValves)}";
    }
}