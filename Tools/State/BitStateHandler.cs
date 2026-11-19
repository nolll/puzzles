using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Tools.State;

public class BitStateHandler
{
    private readonly Dictionary<char, int> _lookup = new();
    public long MaxValue { get; }
    
    public BitStateHandler(IEnumerable<char> values)
    {
        MaxValue = 0L;
        var i = 0;
        
        foreach (var v in values)
        {
            _lookup[v] = i;
            MaxValue |= (uint)(1 << i);
            i++;
        }
    }

    public bool IsAllMarked(long v) => v == MaxValue;
    public long MarkValue(long state, char c) => state | (uint)(1 << _lookup[c]);
    public bool IsMarked(long state, char c) => (state & (1 << _lookup[c])) > 0;
}

public class CoordBitStateHandler
{
    private readonly Dictionary<Coord, int> _lookup = new();
    public long MaxValue { get; }
    
    public CoordBitStateHandler(IEnumerable<Coord> values)
    {
        MaxValue = 0L;
        var i = 0;
        
        foreach (var v in values)
        {
            _lookup[v] = i;
            MaxValue |= (uint)(1 << i);
            i++;
        }
    }

    public bool IsAllMarked(long v) => v == MaxValue;
    public long MarkValue(long state, Coord c) => state | (uint)(1 << _lookup[c]);
    public bool IsMarked(long state, Coord c) => (state & (1 << _lookup[c])) > 0;
}