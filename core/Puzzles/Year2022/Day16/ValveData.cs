using System.Collections.Generic;
using System.Linq;
using Core.Common.Strings;

namespace Core.Puzzles.Year2022.Day16;

public class ValveData
{
    public readonly List<string> Valves;
    public readonly Dictionary<string, List<ValveConnection>> Connections;
    public readonly Dictionary<string, int> Rates;

    public ValveData(string input)
    {
        (Valves, Connections, Rates) = ParseData(input);
        (Valves, Connections, Rates) = OptimizeData(Valves, Connections, Rates);
    }

    public static (
        List<string> Valves, 
        Dictionary<string, List<ValveConnection>> Connections, 
        Dictionary<string, int> Rates)
        OptimizeData(
            List<string> valves, 
            Dictionary<string, List<ValveConnection>> connections, 
            Dictionary<string, int> rates)
    {
        var valvesToRemove = valves.Where(o => rates[o] == 0 && o != "AA").ToList();
        var allValves = valves.ToList();
        foreach (var vtr in valvesToRemove)
        {
            foreach (var valve in allValves)
            {
                if (valve == vtr)
                    continue;

                if (connections[valve].All(o => o.Valve != vtr))
                    continue;

                connections[valve] = connections[valve].Where(o => o.Valve != vtr).ToList();
                connections[valve].AddRange(connections[vtr].Select(o => new ValveConnection(o.Valve, o.Cost + 1)));
            }
        }

        foreach (var vtr in valvesToRemove)
        {
            allValves.Remove(vtr);
            connections.Remove(vtr);
            rates.Remove(vtr);
        }

        foreach (var valve in allValves)
        {
            connections[valve] = connections[valve].Where(o => o.Valve != valve).ToList();
        }

        return (allValves, connections, rates);
    }

    public static (
        List<string> valves, 
        Dictionary<string, List<ValveConnection>> Connections, 
        Dictionary<string, int> Rates)
        ParseData(string input)
    {
        var rates = new Dictionary<string, int>();
        var connections = new Dictionary<string, List<ValveConnection>>();
        var valves = new List<string>();
        var lines = PuzzleInputReader.ReadLines(input);

        foreach (var line in lines)
        {
            var parts = line.Split(';');
            var name = parts[0].Split(' ')[1];
            var rate = int.Parse(parts[0].Split(' ')[4].Split('=')[1]);
            var conn = parts[1].Split(' ').Skip(5).Select(o => o.Trim(',', ' ')).ToList();
            rates.Add(name, rate);
            connections.Add(name, conn.Select(o => new ValveConnection(o, 1)).ToList());
            valves.Add(name);
        }
        
        return (valves, connections, rates);
    }
}