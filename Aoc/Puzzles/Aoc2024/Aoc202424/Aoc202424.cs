using Pzl.Common;
using Pzl.Tools.Combinatorics;
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
        var result = Part2(input, 4);
        return new PuzzleResult(result);
    }
    
    public string Part2(string input, int swapCount)
    {
        var parts = input.Split(LineBreaks.Double);
        var wires = parts[0].Split(LineBreaks.Single)
            .Select(o => o.Split(": "))
            .ToDictionary(k => k[0], v => long.Parse(v[1]));
        var gates = parts[1].Split(LineBreaks.Single)
            .Select(o => o.Split(' '))
            .ToDictionary(k => k[4], v => (v[0], v[2], v[1]));

        var xwires = wires.Where(o => o.Key.StartsWith('x')).OrderByDescending(o => o.Key).Select(o => o.Value);
        var ywires = wires.Where(o => o.Key.StartsWith('y')).OrderByDescending(o => o.Key).Select(o => o.Value);
        var a = Convert.ToInt64(string.Join("", xwires), 2);
        var b = Convert.ToInt64(string.Join("", ywires), 2);

        var gateNames = gates.Keys.Order().ToArray();
        var swapset = new HashSet<(string, string)>();
        for (var i = 0; i < gates.Keys.Count; i++)
        {
            for (var j = i + 1; j < gates.Keys.Count; j++)
            {
                if (i == j)
                    continue;

                swapset.Add((gateNames[i], gateNames[j]));
            }
        }

        var swaps = swapset.ToArray();
        Console.WriteLine("Get combos");
        var swapcombos = CombinationGenerator.GetUniqueCombinationsFixedSize(swaps, swapCount).Where(o =>
        {
            var all = new List<string>();
            foreach (var swap in o)
            {
                all.Add(swap.Item1);
                all.Add(swap.Item2);
            }

            return all.Distinct().Count() == o.Count * swapCount;
        }).ToList();
        
        Console.WriteLine($" Swapcombos: {swapcombos.Count()}");
        
        var expectedResult = a & b;

        var zgates = gates.Keys.Where(o => o.StartsWith('z')).OrderDescending().ToList();
        IList<(string, string)> selectedSwap = [];
        var processor = new Processor(gates, wires);
        var counter = 0;
        foreach (var combo in swapcombos)
        {
            counter++;
            processor.Swap(combo);
            var results = zgates.Select(o => processor.Process(o));
            var dec = Convert.ToInt64(string.Join("", results), 2);
            if (dec == expectedResult)
            {
                selectedSwap = combo;
                break;
            }
            processor.Swap(combo);
            Console.WriteLine(counter);
        }

        var result = new List<string>();
        foreach (var swap in selectedSwap)
        {
            result.Add(swap.Item1);
            result.Add(swap.Item2);
        }

        var ans = string.Join(",", result.Order());
        
        return ans;
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

        public void Swap(IList<(string, string)> swaps)
        {
            foreach (var swap in swaps)
            {
                (_gates[swap.Item1], _gates[swap.Item2]) = (_gates[swap.Item2], _gates[swap.Item1]);
            }
        }
    }
}