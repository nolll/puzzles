namespace Pzl.Aoc.Puzzles.Aoc2015.Aoc201507;

public class NotWire : Wire
{
    private readonly IDictionary<string, Wire> _dictionary;
    private readonly string _a;

    private ushort WireASignal => _dictionary[_a].Signal;
        
    public override ushort Signal
    {
        get
        {
            if (_signal == null)
                _signal = (ushort)~WireASignal;
            return _signal.Value;
        }
    }

    public NotWire(IDictionary<string, Wire> dictionary, string a)
    {
        _dictionary = dictionary;
        _a = a;
    }
}