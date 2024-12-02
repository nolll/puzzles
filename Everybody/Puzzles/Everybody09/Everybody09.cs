using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Everybody.Puzzles.Everybody09;

[Name("Sparkling Bugs")]
public class Everybody09 : EverybodyPuzzle
{
    public PuzzleResult RunPart1(string input)
    {
        int[] stamps = [1, 3, 5, 10];
        var balls = ParseBalls(input);
        var precomputedCounts = PrecomputeCounts(stamps, balls.Max());
        var result = balls.Sum(o => precomputedCounts[o]);
        
        return new PuzzleResult(result, "dffa64bee7ea0c0ad66724de7afe7c08");
    }

    public PuzzleResult RunPart2(string input)
    {
        int[] stamps = [1, 3, 5, 10, 15, 16, 20, 24, 25, 30];
        var balls = ParseBalls(input);
        var precomputedCounts = PrecomputeCounts(stamps, balls.Max());
        var result = balls.Sum(o => precomputedCounts[o]);

        return new PuzzleResult(result, "6032109447891782512325cb9251f9e2");
    }
    
    public PuzzleResult RunPart3(string input)
    {
        const int rangeSize = 100;
        int[] stamps = [1, 3, 5, 10, 15, 16, 20, 24, 25, 30, 37, 38, 49, 50, 74, 75, 100, 101];
        var precomputeMax = ParseBalls(input).Max() / 2 + rangeSize;
        var precomputed = PrecomputeCounts(stamps, precomputeMax);
        
        var combinedSums = input.Split(LineBreaks.Single).Select(int.Parse);
        var total = 0;
        foreach (var sum in combinedSums)
        {
            var mid = sum / 2;
            var min = mid - rangeSize;
            var max = mid + rangeSize;
            var best = int.MaxValue;
            for (var a = min; a <= max; a++)
            {
                var b = sum - a;
                if (Math.Abs(a - b) <= 100)
                {
                    best = Math.Min(best, precomputed[a] + precomputed[b]);
                }
            }

            total += best;
        }

        return new PuzzleResult(total, "fb766ccc85f0b992daa8d54a92c61b5c");
    }

    private static int[] ParseBalls(string input) => 
        input.Split(LineBreaks.Single).Select(int.Parse).ToArray();

    // Thanks, Jonathan Paulson
    private static int[] PrecomputeCounts(int[] stamps, int max)
    {
        var counts = new int[max + 1];
        for (var x = 1; x < max + 1; x++)
        {
            var best = int.MaxValue;
            foreach (var o in stamps)
            {
                if (x - o >= 0)
                    best = Math.Min(best, 1 + counts[x - o]);
            }
            
            counts[x] = best;
        }

        return counts;
    }
}
