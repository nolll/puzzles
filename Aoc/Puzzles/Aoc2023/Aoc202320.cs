using Pzl.Common;
using Pzl.Tools.Maths;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2023;

[Name("Pulse Propagation")]
public class Aoc202320 : AocPuzzle
{
    [Puzzle("826f2e187e18624950644293ef2e6c8d")]
    public long Part1(string input) => CountPulses(input, 1000);

    [Puzzle("1fd3846c9dc834364bf2cdc9c11dfbdb")]
    public long Part2(string input) => CountPulses(input, 5000, true);

    public static long CountPulses(string s, int iterations, bool isPart2 = false)
    {
        var modules = ParseModules(s);
        var part2State = new Dictionary<string, long>();
        if (isPart2)
        {
            var moduleSendingToRx = modules.Values.First(o => o.Targets.Length == 1 && o.Targets.First() == "rx");
            var modulesToCheck = modules.Values
                .Where(o => o.Targets.Length == 1 && o.Targets.First() == moduleSendingToRx.Name)
                .Select(o => o.Name)
                .ToArray();
            part2State = modulesToCheck.ToDictionary(o => o, _ => 0L);
        }
        
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
        var lines = s.Split(LineBreaks.Single);

        foreach (var line in lines)
        {
            var parts = line.Split(" -> ");
            var targets = parts[1].Split(", ");
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
    
    public class BroadcasterModule(string[] targets) : Module("broadcaster", targets)
    {
        public override void ReceivePulse(string from, Pulse pulse)
        {
            if (pulse == Pulse.Low)
                LowPulseCount++;
            else
                HighPulseCount++;
        }

        public override Pulse OutputPulse => Pulse.Low;
        public override bool ShouldSend => true;
        public override void RegisterSource(string source) { }
    }
    
    public class ButtonModule() : Module("button", [])
    {
        public override void ReceivePulse(string from, Pulse pulse)
        {
        }

        public override Pulse OutputPulse => Pulse.Low;
        public override bool ShouldSend => true;
        public override void RegisterSource(string source) { }
    }
    
    public class ConjunctionModule(string name, string[] targets) : Module(name, targets)
    {
        private readonly Dictionary<string, Pulse> _memory = new();

        public override void ReceivePulse(string from, Pulse pulse)
        {
            if (pulse == Pulse.Low)
                LowPulseCount++;
            else
                HighPulseCount++;

            _memory[from] = pulse;
        }

        public override Pulse OutputPulse => _memory.Values.All(o => o == Pulse.High) ? Pulse.Low : Pulse.High;
        public override bool ShouldSend => true;
        public override void RegisterSource(string source)
        {
            _memory[source] = Pulse.Low;
        }
    }
    
    public class DevNullModule(string name) : Module(name, [])
    {
        public override void ReceivePulse(string from, Pulse pulse)
        {
            if (pulse == Pulse.Low)
                LowPulseCount++;
            else
                HighPulseCount++;
        }

        public override Pulse OutputPulse => Pulse.Low;
        public override bool ShouldSend => true;
        public override void RegisterSource(string source) { }
    }
    
    public class FlipFlopModule(string name, string[] targets) : Module(name, targets)
    {
        private State _state = State.Off;
        private Pulse _output = Pulse.Low;
        private bool _shouldSend = false;

        public override void ReceivePulse(string from, Pulse pulse)
        {
            if (pulse == Pulse.Low)
                LowPulseCount++;
            else
                HighPulseCount++;

            if (pulse == Pulse.Low)
            {
                if (_state == State.Off)
                {
                    _output = Pulse.High;
                    _state = State.On;
                }
                else
                {
                    _output = Pulse.Low;
                    _state = State.Off;
                }
                _shouldSend = true;
            }
            else
            {
                _shouldSend = false;
            }
        }

        public override Pulse OutputPulse => _output;
        public override bool ShouldSend => _shouldSend;
        public override void RegisterSource(string source){}
    }
    
    public abstract class Module(string name, string[] targets)
    {
        public string Name { get; } = name;
        public string[] Targets { get; } = targets;

        public abstract void ReceivePulse(string from, Pulse pulse);
        public abstract Pulse OutputPulse { get; }
        public abstract bool ShouldSend { get; }
        public long LowPulseCount { get; protected set; } = 0;
        public long HighPulseCount { get; protected set; } = 0;
        public abstract void RegisterSource(string source);
    }
    
    public enum Pulse
    {
        Low,
        High
    }
    
    public enum State
    {
        Off,
        On
    }
}