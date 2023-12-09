namespace Pzl.Tools.Numbers;

public static class Sequence
{
    public static long Next(IEnumerable<long> input) => Extrapolate(input.ToArray(), Mode.Next);
    public static long Previous(IEnumerable<long> input) => Extrapolate(input.ToArray(), Mode.Prev);

    // Inspired by hyper-neutrino
    private static long Extrapolate(long[] numbers, Mode mode)
    {
        if (numbers.All(o => o == 0))
            return 0;

        var deltas = numbers.Zip(numbers.Skip(1), (a, b) => b - a);
        var diff = Extrapolate(deltas.ToArray(), mode);

        return mode == Mode.Prev 
            ? numbers.First() - diff
            : numbers.Last() + diff;
    }

    private enum Mode
    {
        Next,
        Prev
    }
}