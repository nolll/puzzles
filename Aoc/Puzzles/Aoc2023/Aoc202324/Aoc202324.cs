using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2023.Aoc202324;

[Name("Never Tell Me The Odds")]
[Comment("Learn more about equation systems")]
public class Aoc202324 : AocPuzzle
{
    public PuzzleResult RunPart1(string input)
    {
        var result = CountIntersectingWithin(input, 200_000_000_000_000, 400_000_000_000_000);

        return new PuzzleResult(result, "907db44ec104f348525996e3821ac11d");
    }
    
    public static int CountIntersectingWithin(string s, long min, long max)
    {
        var count = 0;
        var hailstones = ParseHailstones(s);
        var seen = new HashSet<(long, long)>();
        foreach (var a in hailstones)
        {
            foreach (var b in hailstones)
            {
                if (a.Id == b.Id)
                    continue;

                List<Hailstone> both = [a, b];
                var first = both.MinBy(o => o.Id)!;
                var second = both.MaxBy(o => o.Id)!;
                var key = (first.Id, second.Id);
                if (!seen.Add(key))
                    continue;

                var intersection = first.IntersectsWith(second);
                if(intersection is null)
                    continue;

                var isInRange = intersection.X > min && intersection.X < max && intersection.Y > min && intersection.Y < max; 
                count += isInRange ? 1 : 0;
            }   
        }

        return count;
    }

    public PuzzleResult RunPart2(string input)
    {
        var stones = ParseHailstones(input);

        var res = Solve(stones);
        
        return new PuzzleResult(res, "95042738f3ece8b6cd45dd711ee9d3fa");
    }

    private long Solve(List<Hailstone> stones)
    {
        for (var i = 0; i < stones.Count; i++)
        {
            for (var j = 0; j < stones.Count; j++)
            {
                for (var k = 0; k < stones.Count; k++)
                {
                    if (i == j || i == k || j == k)
                        continue;
                    
                    var res = Solve(stones, i, j, k);
                    if (res != 0)
                        return res;
                }
            }
        }

        return 0;
    }

    // Followed this solution. Will try to learn more about equation systems
    private long Solve(List<Hailstone> stones, int ai, int bi, int ci)
    {
        double ax = stones[ai].X;
        double ay = stones[ai].Y;
        double az = stones[ai].Z;
        double avx = stones[ai].Vx;
        double avy = stones[ai].Vy;
        double avz = stones[ai].Vz;
        
        double bx = stones[bi].X;
        double by = stones[bi].Y;
        double bz = stones[bi].Z;
        double bvx = stones[bi].Vx;
        double bvy = stones[bi].Vy;
        double bvz = stones[bi].Vz;
        
        double cx = stones[ci].X;
        double cy = stones[ci].Y;
        double cz = stones[ci].Z;
        double cvx = stones[ci].Vx;
        double cvy = stones[ci].Vy;
        double cvz = stones[ci].Vz;

        var abvx = avx - bvx;
        var abvy = avy - bvy;
        var abvz = avz - bvz;

        var acvx = avx - cvx;
        var acvy = avy - cvy;
        var acvz = avz - cvz;

        var abx = ax - bx;
        var aby = ay - by;
        var abz = az - bz;

        var acx = ax - cx;
        var acy = ay - cy;
        var acz = az - cz;

        var h0 = by * bvx - bx * bvy - (ay * avx - ax * avy);
        var h1 = cy * cvx - cx * cvy - (ay * avx - ax * avy);
        var h2 = bx * bvz - bz * bvx - (ax * avz - az * avx);
        var h3 = cx * cvz - cz * cvx - (ax * avz - az * avx);
        var h4 = bz * bvy - by * bvz - (az * avy - ay * avz);
        var h5 = cz * cvy - cy * cvz - (az * avy - ay * avz);

        var pxx = acvx * abz - abvx * acz;
        var pyy = acvy * abx - abvy * acx;
        var pzz = acvz * aby - abvz * acy;

        var pxz = abvx * acx - acvx * abx;
        var pzy = abvz * acz - acvz * abz;
        var pyx = abvy * acy - acvy * aby;

        var pxc = abvx * h3 - acvx * h2;
        var pyc = abvy * h1 - acvy * h0;
        var pzc = abvz * h5 - acvz * h4;

        var pxd = acvx * abvz - abvx * acvz;
        var pyd = acvy * abvx - abvy * acvx;
        var pzd = acvz * abvy - abvz * acvy;

        var qz0 = abvy / pxd * pxz;
        var qx0 = abvy / pxd * pxx - abvx / pyd * pyx - aby;
        var qy0 = abx - abvx / pyd * pyy;
        var r0 = h0 - abvy / pxd * pxc + abvx / pyd * pyc;

        var qy1 = abvx / pzd * pzy;
        var qz1 = abvx / pzd * pzz - abvz / pxd * pxz - abx;
        var qx1 = abz - abvz / pxd * pxx;
        var r1 = h2 - abvx / pzd * pzc + abvz / pxd * pxc;

        var qx2 = abvz / pyd * pyx;
        var qy2 = abvz / pyd * pyy - abvy / pzd * pzy - abz;
        var qz2 = aby - abvy / pzd * pzz;
        var r2 = h4 - abvz / pyd * pyc + abvy / pzd * pzc;
        
        var qz = ((qx1 * qy0 - qx0 * qy1) * (qx2 * r0 - qx0 * r2) - (qx2 * qy0 - qx0 * qy2) * (qx1 * r0 - qx0 * r1)) / 
                 ((qx2 * qy0 - qx0 * qy2) * (qx0 * qz1 - qx1 * qz0) - (qx1 * qy0 - qx0 * qy1) * (qx0 * qz2 - qx2 * qz0));

        var qy = ((qx0 * qz1 - qx1 * qz0) * qz + (qx1 * r0 - qx0 * r1)) / (qx1 * qy0 - qx0 * qy1);

        var qx = (r0 - qy0 * qy - qz0 * qz) / qx0;

        var px = (pxz * qz + pxx * qx + pxc) / pxd;
        var py = (pyx * qx + pyy * qy + pyc) / pyd;
        var pz = (pzy * qy + pzz * qz + pzc) / pzd;

        if (px % 1 > 0.001 || py % 1 > 0.001 || pz % 1 > 0.001)
            return 0;
        
        var sum = (long)Math.Round(px) + (long)Math.Round(py) + (long)Math.Round(pz);
        return sum;
    }

    private static List<Hailstone> ParseHailstones(string s)
    {
        var lines = StringReader.ReadLines(s);
        return lines.Select(o => o.Replace(" @", ",").Replace(" ", "").Split(',').Select(long.Parse).ToArray())
            .Select((o, i) => new Hailstone(i, o[0], o[1], o[2], o[3], o[4], o[5]))
            .ToList();
    }
}