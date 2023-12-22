using Pzl.Common;
using Pzl.Tools.Maths;
using Pzl.Tools.Strings;
using System.Runtime.CompilerServices;

namespace Pzl.Aoc.Puzzles.Aoc2023.Aoc202320;

[Name("Pulse Propagation")]
public class Aoc202320(string input) : AocPuzzle
{
    protected override PuzzleResult RunPart1() => 
        new(CountPulses(input, 1000), "826f2e187e18624950644293ef2e6c8d");

    protected override PuzzleResult RunPart2() =>
        new(CountPulses(input, 5000, true), "1fd3846c9dc834364bf2cdc9c11dfbdb");

    public static long CountPulses(string s, int iterations, bool isPart2 = false)
    {
        var modules = ParseModules(s);
        var moduleSendingToRx = modules.Values.First(o => o.Targets.Length == 1 && o.Targets.First() == "rx");
        var modulesToCheck = modules.Values
            .Where(o => o.Targets.Length == 1 && o.Targets.First() == moduleSendingToRx.Name)
            .Select(o => o.Name)
            .ToArray();
        var part2State = modulesToCheck.ToDictionary(o => o, _ => 0L);

        for (var i = 0; i < iterations; i++)
        {
            var queue = new Queue<(string, Module)>();
            queue.Enqueue(("button", modules["broadcaster"]));
            while (queue.Count > 0)
            {
                var (from, current) = queue.Dequeue();

                current.ReceivePulse(from, modules[from].OutputPulse);
                
                if (!current.ShouldSend)
                    continue;

                var targets = current.Targets;
                foreach (var target in targets)
                {
                    if (modules.TryGetValue(target, out var next))
                    {
                        queue.Enqueue((current.Name, next));
                    }
                }
            }

            if (!isPart2) 
                continue;

            foreach (var key in part2State.Keys)
            {
                if (part2State[key] == 0 && modules[key].LowPulseCount == 1)
                {
                    part2State[key] = i + 1;
                }
            }

            if (part2State.Values.All(o => o > 0))
                return MathTools.Lcm(part2State.Values);
        }

        var low = modules.Values.Sum(o => o.LowPulseCount);
        var high = modules.Values.Sum(o => o.HighPulseCount);

        return low * high;
    }

    private static Dictionary<string, Module> ParseModules(string s)
    {
        var modules = new Dictionary<string, Module>();
        var button = new ButtonModule();
        modules.Add(button.Name, button);
        var lines = StringReader.ReadLines(s);

        foreach (var line in lines)
        {
            var parts = line.Split(" -> ").ToArray();
            var targets = parts[1].Split(", ").ToArray();
            var type = parts[0][0];
            if (type is '%' or '&')
            {
                var name = parts[0][1..];
                if (type is '%')
                    modules.Add(name, new FlipFlopModule(name, targets));
                else
                    modules.Add(name, new ConjunctionModule(name, targets));
            }
            else
            {
                var name = parts[0];
                modules.Add(name, new BroadcasterModule(targets));
            }
        }

        var devnullModules = new List<Module>();
        foreach (var module in modules.Values)
        {
            foreach (var targetName in module.Targets)
            {
                if (modules.TryGetValue(targetName, out var targetModule))
                    targetModule.RegisterSource(module.Name);
                else
                    devnullModules.Add(new DevNullModule(targetName));
            }
        }

        foreach (var module in devnullModules)
        {
            modules.Add(module.Name, module);
        }

        return modules;
    }
}