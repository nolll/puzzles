namespace Pzl.Aoc.Puzzles.Aoc2023.Aoc202320;

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