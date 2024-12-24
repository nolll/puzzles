using System.Diagnostics;
using Pzl.Common;
using Pzl.Tools.Numbers;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2024.Aoc202424;

[Name("Crossed Wires")]
public class Aoc202424 : AocPuzzle
{
    public PuzzleResult Part1(string input)
    {
        var parts = input.Split(LineBreaks.Double);
        var wires = parts[0].Split(LineBreaks.Single)
            .Select(o => o.Split(": "))
            .Select(p => (name: p[0], value: long.Parse(p[1])))
            .ToDictionary(k => k.name, v => v.value);
        var gates = parts[1].Split(LineBreaks.Single)
            .Select(o => o.Split(' '))
            .Select(o => (a: o[0], b: o[2], t: o[4], op: o[1]))
            .ToDictionary(k => k.t, v => (v.a, v.b, v.op));

        var zgates = gates.Keys.Where(o => o.StartsWith('z')).OrderDescending();
        var results = zgates.Select(o => Process(gates, wires, o));
        var s = string.Join("", results);
        var binary = Convert.ToInt64(s, 2);
        
        return new PuzzleResult(binary, "9fc2d4daac695a3b88d61a9cfe083437");
    }

    private long Process(
        Dictionary<string, (string a, string b, string op)> gates,
        Dictionary<string, long> wires,
        string name)
    {
        if (wires.TryGetValue(name, out var v))
            return v;

        var gate = gates[name];

        if (gate.op == "AND")
            return Process(gates, wires, gate.a) & Process(gates, wires, gate.b);
        if (gate.op == "XOR")
            return Process(gates, wires, gate.a) ^ Process(gates, wires, gate.b);
        if (gate.op == "OR")
            return Process(gates, wires, gate.a) | Process(gates, wires, gate.b);

        throw new Exception($"Unknown operation: {gate.op}");
    }

    public PuzzleResult Part2(string input)
    {
        return new PuzzleResult(0);
    }
}