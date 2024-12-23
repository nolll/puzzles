namespace Pzl.Aoc.Puzzles.Aoc2015.Aoc201507;

public class LeftShiftWire : Wire
{
    private readonly IDictionary<string, Wire> _dictionary;
    private readonly string _a;
    private readonly ushort _distance;

    private ushort WireASignal => _dictionary[_a].Signal;

    public override ushort Signal
    {
        get
        {
            if (_signal == null)
                _signal = (ushort)(WireASignal << _distance);
            return _signal.Value;
        }
    }
        
    public LeftShiftWire(IDictionary<string, Wire> dictionary, string a, ushort distance)
    {
        _dictionary = dictionary;
        _a = a;
        _distance = distance;
    }
}