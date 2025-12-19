using Pzl.Common;
using Pzl.Tools.Lists;
using Pzl.Tools.Numbers;
using Pzl.Tools.Strings;

namespace Pzl.FlipFlop.Puzzles.FlipFlop2025.FlipFlop202507;

[Name("Hyper grids")]
public class FlipFlop202507 : FlipFlopPuzzle
{
    public PuzzleResult Part1(string input)
    {
        var lines = input.Split(LineBreaks.Single);
        var count = 0L;
        foreach (var line in lines)
        {
            var (w, h) = Numbers.IntsFromString(line);
            var n = CountWays(w, h);
            count += n;
        }
        
        return new PuzzleResult(count, "7b616e8fb5d65258e63524b0fc6a38a8");
    }

    public PuzzleResult Part2(string input)
    {
        var lines = input.Split(LineBreaks.Single);
        var count = 0L;
        foreach (var line in lines)
        {
            var (w, h) = Numbers.IntsFromString(line);
            var n = CountWays(w, h, w);
            count += n;
        }
        
        return new PuzzleResult(count, "acc5b7834fbceedcbea8e40329558fe9");
    }

    public PuzzleResult Part3(string input)
    {
        var lines = input.Split(LineBreaks.Single);
        var count = 0L;
        foreach (var line in lines)
        {
            var (dimensionCount, size) = Numbers.IntsFromString(line);
            var dimensions = Enumerable.Range(0, dimensionCount).Select(_ => size).ToArray();
            var n = CountWays(dimensions);
            count += n;
        }
        
        return new PuzzleResult(count, "4b85e2a44300b9cdb015d5b57f717a50");
    }

    public long CountWays(params int[] dimensions)
    {
        var n = Factorial(dimensions.Sum() - dimensions.Length);
        var d = dimensions.Aggregate(1L, (current, dimension) => current * Factorial(dimension - 1));

        return n / d;
    }
    
    public long Factorial(long n)
    {
        var r = 1L;
        for (var i = 1; i <= n; i++) 
            r *= i;

        return r;
    }
}