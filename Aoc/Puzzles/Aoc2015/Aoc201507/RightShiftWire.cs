namespace Pzl.Aoc.Puzzles.Aoc2015.Aoc201507;

public class RightShiftWire(IDictionary<string, Wire> dictionary, string a, ushort distance)
    : Wire
{
    private ushort WireASignal => dictionary[a].Signal;
        
    public override ushort Signal
    {
        get
        {
            _signal ??= (ushort)(WireASignal >> distance);
            return _signal.Value;
        }
    }
}