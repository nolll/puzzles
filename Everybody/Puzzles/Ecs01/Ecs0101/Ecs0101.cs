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
        var result = FindBestResult(Eni1, input);
        return new PuzzleResult(result, "400b09c8e50afd8c884e7693f14f2d76");
    }

    public PuzzleResult RunPart2(string input)
    {
        var result = FindBestResult(Eni2, input);
        return new PuzzleResult(result, "218170e1ab319a7f79e6be73f824bcb7");
    }

    public PuzzleResult RunPart3(string input)
    {
        var result = FindBestResult(Eni3, input);
        return new PuzzleResult(result, "66e6499f59383f4a9fd43d9320e68816");
    }

    private static long FindBestResult(Func<long, long, long, long> eni, string input)
    {
        var lines = input.Split(LineBreaks.Single);
        var best = 0L;
        foreach (var line in lines)
        {
            var (a, b, c, x, y, z, m) = Numbers.LongsFromString(line);
            best = Math.Max(best, EniSum(eni, a, b, c, x, y, z, m));
        }

        return best;
    }

    public static long Eni1(long n, long exp, long mod)
    {
        var list = new List<long>();
        var s = 1L;
        
        for (var i = 0; i < exp; i++)
        {
            s = s * n % mod;
            list.Add(s);
        }

        return GetResult(list);
    }

    public static long Eni2(long n, long exp, long mod)
    {
        var list = new List<long>();
        var s = 1L;
        var seen = new Dictionary<long, long>();
        var skipped = false;
        for (var i = 0L; i < exp; i++)
        {
            s = s * n % mod;
            list.Add(s);
            if (!skipped && seen.TryGetValue(s, out var seenIndex))
            {
                var cycleLength = i - seenIndex;
                var skipCount = (exp - i) / cycleLength - 5;
                i += skipCount * cycleLength;
                skipped = true;
            }

            seen.TryAdd(s, i);
        }

        return GetResult(list.TakeLast(5));
    }
    
    public static long EniSum(Func<long, long, long, long> eni, long a, long b, long c, long x, long y, long z, long m) => 
        eni(a, x, m) + eni(b, y, m) + eni(c, z, m);

    public static long Eni3(long n, long exp, long mod)
    {
        var list = new List<long>();
        var s = 1L;
        var score = 0L;
        var seen = new Dictionary<long, long>();
        var skipped = false;
        for (var i = 0L; i < exp; i++)
        {
            s = s * n % mod;
            score += s;
            list.Add(s);
            if (!skipped && seen.TryGetValue(s, out var seenIndex))
            {
                var cycleLength = (int)(i - seenIndex);
                var cycleScore = list.Skip((int)seenIndex + 1).Take(cycleLength).Sum();
                var skipCount = (exp - i) / cycleLength - 5;
                i += skipCount * cycleLength;
                score += skipCount * cycleScore;
                skipped = true;
            }

            seen.TryAdd(s, i);
        }

        return score;
    }
    
    private static long GetResult(IEnumerable<long> list) => long.Parse(string.Join("", list.Reversed().ToList()));
}