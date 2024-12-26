using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2024.Aoc202424;

[Name("Crossed Wires")]
[Comment("Solved by manual inspection of printout")]
public class Aoc202424 : AocPuzzle
{
    public PuzzleResult Part1(string input)
    {
        var (wires, gates) = ParseWiresAndGates(input);

        var processor = new Processor(gates, wires);
        
        var zgates = gates.Keys.Where(o => o.StartsWith('z')).OrderDescending();
        var results = zgates.Select(o => processor.Process(o));
        var binary = Convert.ToInt64(string.Join("", results), 2);
        
        return new PuzzleResult(binary, "9fc2d4daac695a3b88d61a9cfe083437");
    }

    public PuzzleResult Part2(string input)
    {
        var (wires, gates) = ParseWiresAndGates(input);

        var zgates = gates.Keys.Where(o => o.StartsWith('z')).Order().ToList();
        var xwires = wires.Where(o => o.Key.StartsWith('x')).OrderByDescending(o => o.Key).Select(o => o.Value);
        var ywires = wires.Where(o => o.Key.StartsWith('y')).OrderByDescending(o => o.Key).Select(o => o.Value);
        var x = Convert.ToInt64(string.Join("", xwires), 2);
        var y = Convert.ToInt64(string.Join("", ywires), 2);

        // Found by inspecting printout
        List<string[]> swaps =
        [
            ["z07", "swt"],
            ["z13", "pqc"],
            ["wsv", "rjm"],
            ["z31", "bgs"]
        ];

        foreach (var swap in swaps) 
            (gates[swap[0]], gates[swap[1]]) = (gates[swap[1]], gates[swap[0]]);
        
        // Print(gates, zgates);
        
        var processor = new Processor(gates, wires);
        var results = zgates.Select(zgate => processor.Process(zgate)).ToList();
        var r = Convert.ToInt64(string.Join("", results.Reversed()), 2);
        
        // Make sure result is correct. This will fail without the swaps
        if (r != x + y)
            throw new Exception("Calculation not correct");
        
        var swapped = swaps.SelectMany(o => o).Order();

        var result = string.Join(",", swapped);
        
        return new PuzzleResult(result, "664e08ee1c7756ec0bf56764e81d2280");
    }

    private (Dictionary<string, long> wires, Dictionary<string, (string, string, string)> gates) ParseWiresAndGates(
        string input)
    {
        var parts = input.Split(LineBreaks.Double);
        var wires = parts[0].Split(LineBreaks.Single)
            .Select(o => o.Split(": "))
            .ToDictionary(k => k[0], v => long.Parse(v[1]));
        var gates = parts[1].Split(LineBreaks.Single)
            .Select(o => o.Split(' '))
            .ToDictionary(k => k[4], v => (v[0], v[2], v[1]));

        return (wires, gates);
    }

    private void Print(Dictionary<string, (string, string, string)> gates, List<string> zgates)
    {
        foreach (var zgate in zgates)
        {
            Console.WriteLine();
            Print(gates, zgate, 3, 0);
        }
    }

    private void Print(Dictionary<string, (string, string, string)> gates, string name, int maxdepth, int depth)
    {
        if (depth == maxdepth)
            return;

        if (!gates.TryGetValue(name, out var gate))
            return;
        
        var space = new string(' ', depth * 2);
        Console.WriteLine($"{space}{name} = {gate.Item1} {gate.Item3} {gate.Item2}");
        
        Print(gates, gates[name].Item1, maxdepth, depth + 1);
        Print(gates, gates[name].Item2, maxdepth, depth + 1);
    }

    private class Processor
    {
        private readonly Dictionary<string, long> _wires;
        private readonly Dictionary<string, (string a, string b, Func<string, string, long> f)> _gates;
        
        public Processor(Dictionary<string, (string a, string b, string op)> gates, Dictionary<string, long> wires)
        {
            _gates = gates.ToDictionary(o => o.Key, o => (o.Value.a, o.Value.b, f: GetProcessFunc(o.Value.op)));
            _wires = wires;
        }

        public long Process(string name)
        {
            if (_wires.TryGetValue(name, out var v))
                return v;
            
            var gate = _gates[name];
            return gate.f(gate.a, gate.b);
        }

        private Func<string, string, long> GetProcessFunc(string op) =>
            op switch
            {
                "AND" => ProcessAnd,
                "OR" => ProcessOr,
                "XOR" => ProcessXor,
                _ => throw new Exception($"Unknown operation: {op}")
            };

        private long ProcessAnd(string a, string b) => Process(a) & Process(b);
        private long ProcessOr(string a, string b) => Process(a) | Process(b);
        private long ProcessXor(string a, string b) => Process(a) ^ Process(b);
    }
}