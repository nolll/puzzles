namespace Pzl.Tools.Grids.Grids2d;

public class CoordCompressor
{
    private readonly int _maxDistance;
    private readonly Dictionary<int, int> _xmap;
    private readonly Dictionary<int, int> _ymap;
        
    public List<Coord> Compressed => field.Select(Compress).ToList();
    public (int x, int y) Compress((int x, int y) coord) => (_xmap[coord.x], _ymap[coord.y]);
    public Coord Compress(Coord coord) => new(_xmap[coord.X], _ymap[coord.Y]);

    public CoordCompressor(List<Coord> corners, int maxDistance = 1)
    {
        _maxDistance = maxDistance;
        Compressed = corners;
        _xmap = GetMap(corners.Select(o => o.X).Distinct().Order().ToList());
        _ymap = GetMap(corners.Select(o => o.Y).Distinct().Order().ToList());
    }

    private Dictionary<int, int> GetMap(List<int> values)
    {
        var m = new Dictionary<int, int>();
        var current = values.First();
        m.Add(current, current);
        foreach (var (a, b) in values.Zip(values.Skip(1)))
        {
            if(m.ContainsKey(b))
                continue;
            
            var distance = b - a;
            var needsShortening = distance > _maxDistance;
            current += needsShortening ? _maxDistance : distance;

            m.TryAdd(b, current);
        }

        return m;
    }
}