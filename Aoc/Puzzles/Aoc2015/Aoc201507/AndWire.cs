namespace Pzl.Aoc.Puzzles.Aoc2015.Aoc201507;

public class AndWire(IDictionary<string, Wire> dictionary, string a, string b) : Wire
{
    private ushort WireASignal => ushort.TryParse(a, out var n) ? n : dictionary[a].Signal;
    private ushort WireBSignal => ushort.TryParse(b, out var n) ? n : dictionary[b].Signal;
        
    public override ushort Signal
    {
        get
        {
            _signal ??= (ushort)(WireASignal & WireBSignal);
            return _signal.Value;
        }
    }
}