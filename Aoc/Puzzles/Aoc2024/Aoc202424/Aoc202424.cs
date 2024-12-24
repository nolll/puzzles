using Pzl.Common;
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
            .ToDictionary(k => k[0], v => long.Parse(v[1]));
        var gates = parts[1].Split(LineBreaks.Single)
            .Select(o => o.Split(' '))
            .ToDictionary(k => k[4], v => (v[0], v[2], v[1]));

        var processor = new Processor(gates, wires);
        
        var zgates = gates.Keys.Where(o => o.StartsWith('z')).OrderDescending();
        var results = zgates.Select(o => processor.Process(o));
        var binary = Convert.ToInt64(string.Join("", results), 2);
        
        return new PuzzleResult(binary, "9fc2d4daac695a3b88d61a9cfe083437");
    }

    public PuzzleResult Part2(string input)
    {
        var parts = input.Split(LineBreaks.Double);
        var wires = parts[0].Split(LineBreaks.Single)
            .Select(o => o.Split(": "))
            .ToDictionary(k => k[0], v => long.Parse(v[1]));
        //var gates = parts[1].Split(LineBreaks.Single)
        //    .Select(o => o.Split(' '))
        //    .ToDictionary(k => k[4], v => (v[0], v[2], v[1]));

        var xwires = wires.Where(o => o.Key.StartsWith('x')).OrderByDescending(o => o.Key).Select(o => o.Value);
        var ywires = wires.Where(o => o.Key.StartsWith('y')).OrderByDescending(o => o.Key).Select(o => o.Value);
        var a = Convert.ToInt64(string.Join("", xwires), 2);
        var b = Convert.ToInt64(string.Join("", ywires), 2);
        var expectedResult = a + b;

        //var processor = new Processor(gates, wires);
        
        //var zgates = gates.Keys.Where(o => o.StartsWith('z')).OrderDescending();
        //var results = zgates.Select(o => processor.Process(o));
        //var binary = Convert.ToInt64(string.Join("", results), 2);
        
        return new PuzzleResult(0);
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