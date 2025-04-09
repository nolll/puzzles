using Pzl.Tools.Maths;

namespace Pzl.Codyssi.Puzzles.Codyssi2025.Codyssi202518;

public class DebrisSystem(int sizex, int sizey, int sizez, Debris[] debris)
{
    private const int Minx = 0;
    private int Maxx { get; } = sizex - 1;
    private const int Miny = 0;
    private int Maxy { get; } = sizey - 1;
    private const int Minz = 0;
    private int Maxz { get; } = sizez - 1;
    private const int Minw = -1;
    private const int Maxw = 1;
        
    private readonly Dictionary<int, Dictionary<(int x, int y, int z, int w), int>> _cache = new();

    private Dictionary<(int x, int y, int z, int w), int> PositionsAtTime(int t)
    {
        if (_cache.TryGetValue(t, out var v))
            return v;

        var damage = debris.Select(d => GetPosAfter(d, t));
        v = new Dictionary<(int x, int y, int z, int w), int>();
        foreach (var d in damage)
        {
            if (!v.TryAdd(d, 1)) 
                v[d] += 1;
        }
                
        _cache.Add(t, v);
        return v;
    }

    private (int x, int y, int z, int w) GetPosAfter(Debris d, int time) =>
    (
        ClampX(d.X + d.Vx * time),
        ClampY(d.Y + d.Vy * time),
        ClampZ(d.Z + d.Vz * time),
        ClampW(d.W + d.Vw * time)
    );

    private int ClampX(int v) => MathTools.Clamp(v, Minx, Maxx);
    private int ClampY(int v) => MathTools.Clamp(v, Miny, Maxy);
    private int ClampZ(int v) => MathTools.Clamp(v, Minz, Maxz);
    private int ClampW(int v) => MathTools.Clamp(v, Minw, Maxw);
        
    public int Count => debris.Length;

    public IEnumerable<(int x, int y, int z, int w, int damage)> GetAdjacent((int x, int y, int z, int w) coord, int t)
    {
        var positions = PositionsAtTime(t);
        var adjacent = GetAdjacent(coord);

        var list = new List<(int x, int y, int z, int w, int damage)>();
        foreach (var adj in adjacent)
        {
            var damage = positions.GetValueOrDefault(adj, 0);

            var (x, y, z, w) = adj;
            list.Add((x, y, z, w, damage));
        }

        return list;
    }

    private IEnumerable<(int x, int y, int z, int w)> GetAdjacent((int x, int y, int z, int w) coord) => 
        GetAllAdjacent(coord).Where(IsValid).ToArray();

    private bool IsValid((int x, int y, int z, int w) c) =>
        IsValid(c.x, Minx, Maxx) && 
        IsValid(c.y, Miny, Maxy) && 
        IsValid(c.z, Minz, Maxz) &&
        IsValid(c.w, Minw, Maxw);

    private static bool IsValid(int v, int min, int max) => v >= min && v <= max;

    private static IEnumerable<(int x, int y, int z, int w)> GetAllAdjacent((int x, int y, int z, int w) coord)
    {
        var (x, y, z, w) = coord;
        return [
            (x - 1, y, z, w),
            (x + 1, y, z, w),
            (x, y - 1, z, w),
            (x, y + 1, z, w),
            (x, y, z - 1, w),
            (x, y, z + 1, w),
            coord
        ];
    }
}