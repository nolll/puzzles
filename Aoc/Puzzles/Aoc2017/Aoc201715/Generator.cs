namespace Pzl.Aoc.Puzzles.Aoc2017.Aoc201715;

public class Generator
{
    private readonly int _validationMultiple;
    private const long Divisor = 2147483647;
    private readonly long _factor;
    private long _lastValue;
    public short ShortLastValue => (short) _lastValue;
    public bool IsValid => _lastValue % _validationMultiple == 0;

    public Generator(in long startValue, in long factor, in int validationMultiple)
    {
        _lastValue = startValue;
        _factor = factor;
        _validationMultiple = validationMultiple;
    }

    public void Process()
    {
        var product = _lastValue * _factor;
        _lastValue = product % Divisor;
    }
}