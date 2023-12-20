namespace Pzl.Aoc.Puzzles.Aoc2023.Aoc202320;

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