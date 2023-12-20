namespace Pzl.Aoc.Puzzles.Aoc2023.Aoc202320;

public class ButtonModule() : Module("button", [])
{
    public override void ReceivePulse(string from, Pulse pulse)
    {
    }

    public override Pulse OutputPulse => Pulse.Low;
    public override bool ShouldSend => true;
    public override void RegisterSource(string source) { }
}