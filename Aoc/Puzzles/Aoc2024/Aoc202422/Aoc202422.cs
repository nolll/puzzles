using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2024.Aoc202422;

[Name("Monkey Market")]
public class Aoc202422 : AocPuzzle
{
    public PuzzleResult Part1(string input)
    {
        var nums = input.Split(LineBreaks.Single).Select(long.Parse);
        var sum = nums.Sum(o => Generate(o, 2000).Last());
        
        return new PuzzleResult(sum, "225cb6b8a716ce111cab52fc1ee82264");
    }

    public PuzzleResult Part2(string input)
    {
        var nums = input.Split(LineBreaks.Single).Select(long.Parse);
        var buyers = nums.Select(o => Generate(o, 2000));
        
        var allBuyerScores = new List<Dictionary<(int, int, int, int), long>>();
        foreach (var buyer in buyers)
        {
            var ones = buyer.Select(o => o.ToString())
                .Select(o => o.Substring(o.Length - 1, 1))
                .Select(int.Parse)
                .ToArray();
            
            var buyerScores = new Dictionary<(int, int, int, int), long>();
            for (var i = 4; i < ones.Length; i++)
            {
                var diff1 = ones[i - 3] - ones[i - 4];
                var diff2 = ones[i - 2] - ones[i - 3];
                var diff3 = ones[i - 1] - ones[i - 2];
                var diff4 = ones[i] - ones[i - 1];
                var diff = (diff1, diff2, diff3, diff4);
                buyerScores.TryAdd(diff, ones[i]);
            }
            
            allBuyerScores.Add(buyerScores);
        }

        var sequenceScores = new Dictionary<(int, int, int, int), long>();
        foreach (var buyerScores in allBuyerScores)
        {
            foreach (var key in buyerScores.Keys)
            {
                if (!sequenceScores.TryAdd(key, buyerScores[key]))
                    sequenceScores[key] += buyerScores[key];
            }
        }
        
        var max = long.MinValue;
        foreach (var key in sequenceScores.Keys)
        {
            max = Math.Max(sequenceScores[key], max);
        }
        
        return new PuzzleResult(max, "30bda12ed882f20608645b8e3425f8f5");
    }

    public static long[] Generate(long n, int iterations)
    {
        var nums = new List<long> { n };
        for (var i = 0; i < iterations; i++)
        {
            n = Generate(n);
            nums.Add(n);
        }

        return nums.ToArray();
    }

    private static long Generate(long n)
    {
        const long mod = 16777216; 
        var n1 = n * 64;
        n = (n1 ^ n) % mod;
        var n2 = (long)Math.Floor((double)n / 32);
        n = (n2 ^ n) % mod;
        var n3 = n * 2048;
        n = (n3 ^ n) % mod;
        
        return n;
    }
}