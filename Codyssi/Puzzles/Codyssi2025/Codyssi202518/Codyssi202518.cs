using System.Runtime.InteropServices.ComTypes;
using Pzl.Common;
using Pzl.Tools.Lists;
using Pzl.Tools.Numbers;
using Pzl.Tools.Strings;

namespace Pzl.Codyssi.Puzzles.Codyssi2025.Codyssi202518;

[Name("Cataclysmic Escape")]
public class Codyssi202518 : CodyssiPuzzle
{
    private const int SizeX = 10;
    private const int SizeY = 15;
    private const int SizeZ = 60;

    private const int UpperStepLimit = 300;

    public PuzzleResult Part1(string input)
    {
        var result = RunPart1(input, SizeX, SizeY, SizeZ);
        return new PuzzleResult(result, "a8c76203a26abde805a1a11cbd419b79");
    }

    public int RunPart1(string input, int sizex, int sizey, int sizez)
    {
        var rules = input.Split(LineBreaks.Single).Select(Numbers.IntsFromString);

        var d = new Dictionary<(int x, int y, int z, int w), List<(int vx, int vy, int vz, int vw)>>();
        for (var x = 0; x < sizex; x++)
        {
            for (var y = 0; y < sizey; y++)
            {
                for (var z = 0; z < sizez; z++)
                {
                    for (var w = -1; w < 2; w++)
                    {
                        d.Add((x, y, z, w), []);
                    }
                }
            }
        }
        
        foreach (var rule in rules)
        {
            var x = rule[1];
            var y = rule[2];
            var z = rule[3];
            var w = rule[4];
            var divide = rule[5];
            var remainder = rule[6];
            var vx = rule[7];
            var vy = rule[8];
            var vz = rule[9];
            var vw = rule[10];
            
            foreach (var key in d.Keys)
            {
                var sum = key.x * x + key.y * y + key.z * z + key.w * w;

                var res = (sum % divide + divide) % divide; 
                if(res == remainder) 
                    d[key].Add((vx, vy, vz, vw));
            }
        }

        return d.Values.Sum(list => list.Count);
    }

    public PuzzleResult Part2(string input)
    {
        const int acceptableDamage = 0;
        var result = RunPart2And3(input, SizeX, SizeY, SizeZ, acceptableDamage);
        return new PuzzleResult(result, "c8dcfc39bf271a441c80feaf46160a32");
    }
    
    public PuzzleResult Part3(string input)
    {
        const int acceptableDamage = 3;
        var result = RunPart2And3(input, SizeX, SizeY, SizeZ, acceptableDamage);
        return new PuzzleResult(result, "f81b4b34e7f317b195c2bfb97a67f3de");
    }
    
    public int RunPart2And3(string input, int sizex, int sizey, int sizez, int acceptableDamage)
    {
        var tx = sizex - 1;
        var ty = sizey - 1;
        var tz = sizez - 1;
        const int tw = 0;

        var debrisSystem = Parse(input, sizex, sizey, sizez);

        var seen = new HashSet<(int x, int y, int z, int w, int damage, int t)>();
        var queue = new Queue<(int x, int y, int z, int w, int damage, int t)>();
        queue.Enqueue((0, 0, 0, 0, 0, 0));
        
        while (queue.Count > 0)
        {
            var current = queue.Dequeue();
            var (x, y, z, w, damage, t) = current;
            var coord = (x, y, z, w);
            
            if (t > UpperStepLimit)
                break;
            
            if (seen.Contains(current))
                continue;
            
            var at = t + 1;
            var adjacent = debrisSystem.GetAdjacent(coord, at).ToArray();
            
            seen.Add(current);
            
            if (x == tx && y == ty && z == tz && w == tw)
                continue;
            
            foreach (var adj in adjacent)
            {
                var (ax, ay, az, aw, ad) = adj;
                var nd = IsStart(adj) ? damage : damage + ad;

                if (nd > acceptableDamage)
                    continue;
                
                var a = (ax, ay, az, aw, nd, at);
                if (seen.Contains(a))
                    continue;
                
                queue.Enqueue(a);
            }
        }

        var reachedTarget = seen.Where(o => o.x == tx && o.y == ty && o.z == tz && o.w == tw).ToArray(); 
        return reachedTarget
            .Select(o => o.t)
            .Min();
    }
    
    private static bool IsStart((int, int, int, int, int) coord)
    {
        var (x, y, z, w, _) = coord;
        return x == 0 && y == 0 && z == 0 && w == 0;
    }

    private DebrisSystem Parse(string input, int sizex, int sizey, int sizez)
    {
        var rules = input.Split(LineBreaks.Single).Select(Numbers.IntsFromString);
        var debrisSystem = new DebrisSystem(sizex, sizey, sizez);
        var coords = new List<(int x, int y, int z, int w)>();
        
        for (var x = 0; x < sizex; x++)
        {
            for (var y = 0; y < sizey; y++)
            {
                for (var z = 0; z < sizez; z++)
                {
                    for (var w = -1; w < 2; w++)
                    {
                        coords.Add((x, y, z, w));
                    }
                }
            }
        }
        
        foreach (var (_, x, y, z, w, divide, remainder, vx, vy, vz, vw) in rules)
        {
            foreach (var c in coords)
            {
                var sum = c.x * x + c.y * y + c.z * z + c.w * w;
                var res = (sum % divide + divide) % divide; 
                if (res == remainder) 
                    debrisSystem.Add(new Debris(c.x, c.y, c.z, c.w, vx, vy, vz, vw));
            }
        }

        return debrisSystem;
    }

    private class DebrisSystem(int sizex, int sizey, int sizez)
    {
        private const int Minx = 0;
        private readonly int _maxx = sizex - 1;
        private const int Miny = 0;
        private readonly int _maxy = sizey - 1;
        private const int Minz = 0;
        private readonly int _maxz = sizez - 1;
        private const int Minw = -1;
        private const int Maxw = 1;
        private const int Diffw = Maxw - Minw + 1;

        private readonly List<Debris> _debris = [];
        private readonly Dictionary<int, Dictionary<(int x, int y, int z, int w), int>> _cache = new();

        private Dictionary<(int x, int y, int z, int w), int> PositionsAtTime(int t)
        {
            if (_cache.TryGetValue(t, out var v))
                return v;

            var debris = _debris.Select(d => GetPosAfter(d, t));
            v = new Dictionary<(int x, int y, int z, int w), int>();
            foreach (var d in debris)
            {
                if (!v.TryAdd(d, 1)) 
                    v[d] += 1;
            }
                
            _cache.Add(t, v);
            return v;
        }

        private (int x, int y, int z, int w) GetPosAfter(Debris debris, int time) =>
        (
            ClampX(debris.X + debris.Vx * time),
            ClampY(debris.Y + debris.Vy * time),
            ClampZ(debris.Z + debris.Vz * time),
            ClampW(debris.W + debris.Vw * time)
        );

        private int ClampX(int v) => Clamp(Minx, _maxx, sizex, v);
        private int ClampY(int v) => Clamp(Miny, _maxy, sizey, v);
        private int ClampZ(int v) => Clamp(Minz, _maxz, sizez, v);
        private int ClampW(int v) => Clamp(Minw, Maxw, Diffw, v);

        private static int Clamp(int min, int max, int diff, int v)
        {
            while (v < min)
                v += diff;
            
            while (v > max)
                v -= diff;

            return v;
        }

        public void Add(Debris debris) => _debris.Add(debris);

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
        
        private bool IsValid((int x, int y, int z, int w) coord)
        {
            var (x, y, z, w) = coord;
            if (x < Minx)
                return false;
            if (x > _maxx)
                return false;
            if (y < Miny)
                return false;
            if (y > _maxy)
                return false;
            if (z < Minz)
                return false;
            if (z > _maxz)
                return false;
            if (w < Minw)
                return false;
            if (w > Maxw)
                return false;
            return true;
        }

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

    private record Debris(int X, int Y, int Z, int W, int Vx, int Vy, int Vz, int Vw);
}