namespace Pzl.Aoc.Puzzles.Aoc2023.Aoc202320;

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