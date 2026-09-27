using Pzl.Common;
using Pzl.Tools.Lists;
using Pzl.Tools.Maths;
using Pzl.Tools.Numbers;
using Pzl.Tools.Strings;

namespace Pzl.Codyssi.Puzzles.Codyssi2025;

[Name("Cataclysmic Escape")]
public class Codyssi202518 : CodyssiPuzzle
{
    private const int SizeX = 10;
    private const int SizeY = 15;
    private const int SizeZ = 60;

    [Puzzle("a8c76203a26abde805a1a11cbd419b79")]
    public int Part1(string input, int sizex = SizeX, int sizey = SizeY, int sizez = SizeZ) =>
        DebrisParser.Parse(input, sizex, sizey, sizez).Count;

    [Puzzle("c8dcfc39bf271a441c80feaf46160a32")]
    public int Part2(string input, int sizex = SizeX, int sizey = SizeY, int sizez = SizeZ) =>
        RunPart2And3(input, sizex, sizey, sizez, 0);

    [Puzzle("f81b4b34e7f317b195c2bfb97a67f3de")]
    public int Part3(string input, int sizex = SizeX, int sizey = SizeY, int sizez = SizeZ) =>
        RunPart2And3(input, sizex, sizey, sizez, 3);

    private static int RunPart2And3(string input, int sizex, int sizey, int sizez, int acceptableDamage)
    {
        var tx = sizex - 1;
        var ty = sizey - 1;
        var tz = sizez - 1;
        const int tw = 0;

        var debrisSystem = DebrisParser.Parse(input, sizex, sizey, sizez);

        var seen = new HashSet<(int x, int y, int z, int w, int damage, int time)>();
        var queue = new Queue<(int x, int y, int z, int w, int damage, int time)>();
        queue.Enqueue((0, 0, 0, 0, 0, 0));

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();
            var (x, y, z, w, damage, time) = current;

            var isTarget = x == tx && y == ty && z == tz && w == tw;
            if (isTarget)
                return time;

            if (!seen.Add(current))
                continue;

            var newtime = time + 1;

            foreach (var adj in debrisSystem.GetAdjacent((x, y, z, w), newtime))
            {
                var (ax, ay, az, aw, ad) = adj;
                var nd = IsStart(adj) ? damage : damage + ad;

                if (nd > acceptableDamage)
                    continue;

                var a = (ax, ay, az, aw, nd, newtime);

                queue.Enqueue(a);
            }
        }

        return 0;
    }

    private static bool IsStart((int x, int y, int z, int w, int _) coord) => coord is { x: 0, y: 0, z: 0, w: 0 };

    public record Debris(int X, int Y, int Z, int W, int Vx, int Vy, int Vz, int Vw);

    public static class DebrisParser
    {
        public static DebrisSystem Parse(string input, int sizex, int sizey, int sizez)
        {
            var rules = input.Split(LineBreaks.Single);
            var coords = GetCoords(sizex, sizey, sizez).ToArray();
            var debris = GetDebris(rules, coords).ToArray();
            return new DebrisSystem(sizex, sizey, sizez, debris);
        }

        private static IEnumerable<Debris> GetDebris(IEnumerable<string> rules, (int x, int y, int z, int w)[] coords)
        {
            foreach (var (_, x, y, z, w, divide, remainder, vx, vy, vz, vw) in rules.Select(Numbers.IntsFromString))
            {
                foreach (var c in coords)
                {
                    var sum = c.x * x + c.y * y + c.z * z + c.w * w;
                    var res = (sum % divide + divide) % divide;
                    if (res == remainder)
                        yield return new Debris(c.x, c.y, c.z, c.w, vx, vy, vz, vw);
                }
            }
        }

        private static IEnumerable<(int x, int y, int z, int w)> GetCoords(int sizex, int sizey, int sizez)
        {
            for (var x = 0; x < sizex; x++)
            {
                for (var y = 0; y < sizey; y++)
                {
                    for (var z = 0; z < sizez; z++)
                    {
                        for (var w = -1; w < 2; w++)
                        {
                            yield return (x, y, z, w);
                        }
                    }
                }
            }
        }
    }

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
            return
            [
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
}