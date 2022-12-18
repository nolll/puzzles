using System.Collections.Generic;
using System.Linq;
using Core.Common.Strings;
using NUnit.Framework;

namespace Core.Puzzles.Year2022.Day16;

public class Year2022Day16Tests
{
    public class VolcanicPipes
    {
        private const int TotalTime = 30;
        private Dictionary<string, int> _cache = new();

        public int Part1(string input)
        {
            var lines = PuzzleInputReader.ReadLines(input);
            var rates = new Dictionary<string, int>();
            var connections = new Dictionary<string, List<string>>();
            var allValves = new List<string>();
            foreach (var line in lines)
            {
                var parts = line.Split(';');
                var name = parts[0].Split(' ')[1];
                var rate = int.Parse(parts[0].Split(' ')[4].Split('=')[1]);
                var conn = parts[1].Split(' ').Skip(5).Select(o => o.Trim(',', ' ')).ToList();
                rates.Add(name, rate);
                connections.Add(name, conn);
                allValves.Add(name);
            }

            return GetMaxPressure(allValves, rates, connections);
        }

        private int GetMaxPressure(List<string> allValves, Dictionary<string, int> rates, Dictionary<string, List<string>> connections)
        {
            var openValves = allValves.Where(o => rates[o] == 0).ToList();
            var closedValves = allValves.Where(o => rates[o] > 0).ToList();
            var accumulatedPressure = 0;
            var time = 0;

            return GetBestPressure("AA", accumulatedPressure, time, openValves, closedValves, connections, rates);
        }

        private int GetBestPressure(
            string current,
            int accumulatedPressure,
            int time,
            List<string> openValves,
            List<string> closedValves,
            Dictionary<string, List<string>> connections,
            Dictionary<string, int> rates)
        {
            var isOpen = openValves.Contains(current);
            var candidates = new List<int>();

            if (!isOpen)
            {
                var newOpen = openValves.ToList();
                newOpen.Add(current);
                var newClosed = closedValves.Where(o => o != current).ToList();
                var newAcc = accumulatedPressure + (TotalTime - time) * rates[current];
                var oc = GetBestPressure(current, newAcc, time + 1, newClosed, newOpen, connections, rates);
                candidates.Add(oc);
            }

            var currentConnections = connections[current];
            foreach (var c in currentConnections)
            {
                var newOpen = openValves.ToList();
                var newClosed = closedValves.ToList();
                var oc = GetBestPressure(c, accumulatedPressure, time + 1, newClosed, newOpen, connections, rates);
                candidates.Add(oc);
            }

            return candidates.Max();
        }
    }

    [Test]
    public void Part1()
    {
        var pipes = new VolcanicPipes();
        var result = pipes.Part1(Input);

        Assert.That(result, Is.EqualTo(1651));
    }

    [Test]
    public void Part2()
    {
        var result = 0;

        Assert.That(result, Is.EqualTo(0));
    }

    private const string Input = """ 
Valve AA has flow rate=0; tunnels lead to valves DD, II, BB
Valve BB has flow rate=13; tunnels lead to valves CC, AA
Valve CC has flow rate=2; tunnels lead to valves DD, BB
Valve DD has flow rate=20; tunnels lead to valves CC, AA, EE
Valve EE has flow rate=3; tunnels lead to valves FF, DD
Valve FF has flow rate=0; tunnels lead to valves EE, GG
Valve GG has flow rate=0; tunnels lead to valves FF, HH
Valve HH has flow rate=22; tunnel leads to valve GG
Valve II has flow rate=0; tunnels lead to valves AA, JJ
Valve JJ has flow rate=21; tunnel leads to valve II
""";
}