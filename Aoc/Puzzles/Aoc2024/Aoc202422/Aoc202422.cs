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
            var ones = buyer.Select(o => (int)(o % 10)).ToArray();
            
            var buyerScores = new Dictionary<(int, int, int, int), long>();
            for (var i = 4; i < ones.Length; i++)
            {
                var v1 = ones[i - 4];
                var v2 = ones[i - 3];
                var v3 = ones[i - 2];
                var v4 = ones[i - 1];
                var v = ones[i];
                buyerScores.TryAdd((v2 - v1, v3 - v2, v4 - v3, v - v4), v);
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
        n = Prune(Mix(n, n * 64));
        n = Prune(Mix(n, n / 32));
        n = Prune(Mix(n, n * 2048));
        
        return n;
    }
    
    private static long Mix(long a, long b) => a ^ b;
    private static long Prune(long n) => n % 16777216;
}