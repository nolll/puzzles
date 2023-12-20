namespace Pzl.Aoc.Puzzles.Aoc2023.Aoc202320;

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