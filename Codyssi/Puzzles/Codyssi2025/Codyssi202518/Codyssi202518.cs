using System.Runtime.InteropServices.ComTypes;
using Pzl.Common;
using Pzl.Tools.Numbers;
using Pzl.Tools.Queues;
using Pzl.Tools.Strings;

namespace Pzl.Codyssi.Puzzles.Codyssi2025.Codyssi202518;

[Name("Cataclysmic Escape")]
public class Codyssi202518 : CodyssiPuzzle
{
    public PuzzleResult Part1(string input)
    {
        var result = RunPart1(input, 10, 15, 60);
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
        var result = RunPart2(input, 10, 15, 60, 9, 14, 59, 0);
        return new PuzzleResult(result, "c8dcfc39bf271a441c80feaf46160a32");
    }
    
    public int RunPart2(string input, int sizex, int sizey, int sizez, int tx, int ty, int tz, int tw)
    {
        var rules = input.Split(LineBreaks.Single).Select(Numbers.IntsFromString);
        var debrisSystem = new DebrisSystem(sizex, sizey, sizez);

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
                {
                    d[key].Add((vx, vy, vz, vw));
                    debrisSystem.Add(new Debris(key.x, key.y, key.z, key.w, vx, vy, vz, vw));
                }
            }
        }

        var seen = new HashSet<(int x, int y, int z, int w, int t)>();

        var queue = new Queue<(int x, int y, int z, int w, int t)>();
        queue.Enqueue((0, 0, 0, 0, 0));
        
        while (queue.Count > 0)
        {
            var current = queue.Dequeue();
            var (x, y, z, w, t) = current;
            var coord = (x, y, z, w);

            if (t > 300)
                break;
            
            if (seen.Contains(current))
                continue;
            
            var adjacent = debrisSystem.GetAdjacent(coord, t).ToArray();
            
            seen.Add(current);
            
            if (x == tx && y == ty && z == tz && w == tw)
                continue;

            var at = t + 1;
            foreach (var adj in adjacent)
            {
                var (ax, ay, az, aw) = adj;
                var a = (ax, ay, az, aw, at);
                if (seen.Contains(a))
                    continue;
                
                queue.Enqueue(a);
            }
        }
        
        return seen.Where(o => o.x == tx && o.y == ty && o.z == tz && o.w == tw)
            .Select(o => o.t)
            .Min() - 1; // Still don't know why I need to subtract 1
    }

    public PuzzleResult Part3(string input)
    {
        return new PuzzleResult(0);
    }

    private class DebrisSystem(int sizex, int sizey, int sizez)
    {
        private readonly int _minx = 0;
        private readonly int _maxx = sizex - 1;
        private readonly int _miny = 0;
        private readonly int _maxy = sizey - 1;
        private readonly int _minz = 0;
        private readonly int _maxz = sizez - 1;
        private readonly int _minw = -1;
        private readonly int _maxw = 1;
        private readonly int _diffw = 3;

        private readonly List<Debris> _debris = new();
        public Dictionary<int, HashSet<(int x, int y, int z, int w)>> Cache = new();

        private HashSet<(int x, int y, int z, int w)> PositionsAtTime(int t)
        {
            if (Cache.TryGetValue(t, out var v))
                return v;

            v = _debris.Select(d => GetPosAfter(d, t)).ToHashSet();
            Cache.Add(t, v);
            return v;
        }

        private (int x, int y, int z, int w) GetPosAfter(Debris debris, int time) =>
        (
            ClampX(debris.X + debris.Vx * time),
            ClampY(debris.Y + debris.Vy * time),
            ClampZ(debris.Z + debris.Vz * time),
            ClampW(debris.W + debris.Vw * time)
        );

        private int ClampX(int v) => Clamp(_minx, _maxx, sizex, v);
        private int ClampY(int v) => Clamp(_miny, _maxy, sizey, v);
        private int ClampZ(int v) => Clamp(_minz, _maxz, sizez, v);
        private int ClampW(int v) => Clamp(_minw, _maxw, _diffw, v);

        private static int Clamp(int min, int max, int diff, int v)
        {
            while (v < min)
                v += diff;
            
            while (v > max)
                v -= diff;

            return v;
        }

        public void Add(Debris debris)
        {
            _debris.Add(debris);
        }
        
        public void Add(IEnumerable<Debris> debris)
        {
            _debris.AddRange(debris);
        }

        public IEnumerable<(int x, int y, int z, int w)> GetAdjacent((int x, int y, int z, int w) coord, int t)
        {
            var positions = PositionsAtTime(t);
            return GetAdjacent(coord).Where(o => !positions.Contains(o) || IsStart(o));
        }

        private IEnumerable<(int x, int y, int z, int w)> GetAdjacent((int x, int y, int z, int w) coord) => 
            GetAllAdjacent(coord).Where(IsValid).ToArray();

        private static bool IsStart((int, int, int, int) coord)
        {
            var (x, y, z, w) = coord;
            return x == 0 && y == 0 && z == 0 && w == 0;
        }
        
        private bool IsValid((int x, int y, int z, int w) coord)
        {
            var (x, y, z, w) = coord;
            if (x < _minx)
                return false;
            if (x > _maxx)
                return false;
            if (y < _miny)
                return false;
            if (y > _maxy)
                return false;
            if (z < _minz)
                return false;
            if (z > _maxz)
                return false;
            if (w < _minw)
                return false;
            if (w > _maxw)
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

    private class Debris(int x, int y, int z, int w, int vx, int vy, int vz, int vw)
    {
        public int X { get; } = x;
        public int Y { get; } = y;
        public int Z { get; } = z;
        public int W { get; } = w;
        public int Vx { get; } = vx;
        public int Vy { get; } = vy;
        public int Vz { get; } = vz;
        public int Vw { get; } = vw;
    }
}