namespace Pzl.Aoc.Puzzles.Aoc2015.Aoc201507;

public class PassWire(IDictionary<string, Wire> dictionary, string a) : Wire
{
    private ushort WireASignal => ushort.TryParse(a, out var n) ? n : dictionary[a].Signal;

    public override ushort Signal
    {
        get
        {
            _signal ??= WireASignal;
            return _signal.Value;
        }
    }
}