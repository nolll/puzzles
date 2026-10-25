using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2024;

[Name("Crossed Wires")]
[NeedsRewrite]
[Comment("Solved by manual inspection of printout. Could possibly remove hardcoded swaps")]
public class Aoc202424 : AocPuzzle
{
    [Puzzle("9fc2d4daac695a3b88d61a9cfe083437")]
    public long Part1(string input)
    {
        var (wires, gates) = ParseWiresAndGates(input);
        var processor = new Processor(gates, wires);
        var results = gates.Keys.Where(o => o.StartsWith('z')).OrderDescending().Select(processor.Process);

        return Convert.ToInt64(string.Concat(results), 2);
    }

    [Puzzle("664e08ee1c7756ec0bf56764e81d2280")]
    public string Part2(string input)
    {
        var (wires, gates) = ParseWiresAndGates(input);

        var xwires = wires.Where(o => o.Key.StartsWith('x')).OrderByDescending(o => o.Key).Select(o => o.Value);
        var ywires = wires.Where(o => o.Key.StartsWith('y')).OrderByDescending(o => o.Key).Select(o => o.Value);
        var x = Convert.ToInt64(string.Concat(xwires), 2);
        var y = Convert.ToInt64(string.Concat(ywires), 2);

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

        var processor = new Processor(gates, wires);
        var results = gates.Keys.Where(o => o.StartsWith('z')).Order().ToList().Select(processor.Process).ToList();
        var r = Convert.ToInt64(string.Concat(results.Reversed()), 2);

        // Make sure result is correct. This will fail without the swaps
        if (r != x + y)
            throw new Exception("Calculation not correct");

        var swapped = swaps.SelectMany(o => o).Order();

        return string.Join(",", swapped);
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