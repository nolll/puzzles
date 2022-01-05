namespace Core.Puzzles.Year2015.Day07;

public abstract class Wire
{
    protected ushort? _signal;

    public abstract ushort Signal { get; }

    public void SetSignal(ushort signal)
    {
        _signal = signal;
    }
}