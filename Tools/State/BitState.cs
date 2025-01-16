namespace Pzl.Tools.State;

public class BitState
{
    private readonly Dictionary<char, int> _lookup = new();
    public long FullState { get; }
    
    public BitState(IEnumerable<char> values)
    {
        FullState = 0L;
        var i = 0;
        
        foreach (var v in values)
        {
            _lookup[v] = i;
            FullState |= (uint)(1 << i);
            i++;
        }
    }

    public bool IsFull(long v) => v == FullState;
    public long MarkValue(long state, char c) => state | (uint)(1 << _lookup[c]);
}