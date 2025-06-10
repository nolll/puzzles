using Pzl.Common;
using Pzl.Tools.Lists;
using Pzl.Tools.Numbers;
using Pzl.Tools.Strings;

namespace Pzl.Everybody.Puzzles.Ecs01.Ecs0101;

[Name("EniCode")]
public class Ecs0101 : EverybodyStoryPuzzle
{
    public PuzzleResult RunPart1(string input)
    {
        var lines = input.Split(LineBreaks.Single);
        var best = 0L;
        foreach (var line in lines)
        {
            var (a, b, c, x, y, z, m) = Numbers.IntsFromString(line);
            best = Math.Max(best, EniSum(a, b, c, x, y, z, m));
        }
        
        return new PuzzleResult(best, "400b09c8e50afd8c884e7693f14f2d76");
    }

    public PuzzleResult RunPart2(string input)
    {
        var lines = input.Split(LineBreaks.Single);
        var best = 0L;
        foreach (var line in lines)
        {
            var (a, b, c, x, y, z, m) = Numbers.LongsFromString(line);
            best = Math.Max(best, LimitedEniSum(a, b, c, x, y, z, m));
        }
        
        return new PuzzleResult(best);
    }

    public PuzzleResult RunPart3(string input)
    {
        return new PuzzleResult("");
    }

    public long EniSum(long a, long b, long c, long x, long y, long z, long m) => 
        Eni(a, x, m) + Eni(b, y, m) + Eni(c, z, m);

    public long Eni(long n, long exp, long mod)
    {
        var list = new List<long>();
        var s = 1L;
        for (var i = 0; i < exp; i++)
        {
            s = s * n % mod;
            list.Add(s);
        }
        
        return long.Parse(string.Join("", list.Reversed()));
    }
    
    public long LimitedEniSum(long a, long b, long c, long x, long y, long z, long m) => 
        LimitedEni(a, x, m) + LimitedEni(b, y, m) + LimitedEni(c, z, m);

    public long LimitedEni(long n, long exp, long mod)
    {
        var list = new List<long>();
        var s = 1L;
        for (var i = 0; i < exp; i++)
        {
            s = s * n % mod;
            list.Add(s);
        }
        
        return long.Parse(string.Join("", list.Reversed().Take(5)));
    }
}