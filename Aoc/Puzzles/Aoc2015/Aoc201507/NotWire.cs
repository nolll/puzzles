namespace Pzl.Aoc.Puzzles.Aoc2015.Aoc201507;

public class NotWire(IDictionary<string, Wire> dictionary, string a) : Wire
{
    private ushort WireASignal => dictionary[a].Signal;
        
    public override ushort Signal
    {
        get
        {
            _signal ??= (ushort)~WireASignal;
            return _signal.Value;
        }
    }
}