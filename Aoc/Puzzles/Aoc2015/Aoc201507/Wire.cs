namespace Puzzles.Aoc.Puzzles.Aoc2015.Aoc201507;

public abstract class Wire
{
    protected ushort? _signal;

    public abstract ushort Signal { get; }

    public void SetSignal(ushort signal)
    {
        _signal = signal;
    }
}