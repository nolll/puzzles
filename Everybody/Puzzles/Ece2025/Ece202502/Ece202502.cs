using Pzl.Common;
using Pzl.Tools.Lists;

namespace Pzl.Everybody.Puzzles.Ece2025.Ece202502;

[Name("From Complex to Clarity")]
public class Ece202502 : EverybodyEventPuzzle
{
    public PuzzleResult RunPart1(string input)
    {
        var (a, b) = Parse(input);

        var result = (0L, 0L);
        for (var i = 0; i < 3; i++)
        {
            result = Multiply(result, result);
            result = Divide(result, (10, 10));
            result = Add(result, (a, b));
        }

        var (ra, rb) = result;
        return new PuzzleResult($"[{ra},{rb}]", "c80ae8a8504b69e6b4fa4a851004d919");
    }

    public PuzzleResult RunPart2(string input)
    {
        var count = RunPart2And3(input, 101, 10);
        return new PuzzleResult(count, "814e2b7637e129a0a60b36d921916b8c");
    }

    public PuzzleResult RunPart3(string input)
    {
        var count = RunPart2And3(input, 1001, 1);
        return new PuzzleResult(count, "0265c1e5ddcd8eec040e8ccb3bd0ac11");
    }

    private int RunPart2And3(string input, int gridSize, int increment)
    {
        var (sx, sy) = Parse(input);
        var count = 0;
        
        for (var iy = 0; iy < gridSize; iy++)
        {
            for (var ix = 0; ix < gridSize; ix++)
            {
                var (ox, oy) = (ix * increment, iy * increment);
                var (x, y) = (sx + ox, sy + oy);
                var shouldBeEngraved = ShouldBeEngraved(x, y);
                
                if(shouldBeEngraved)
                    count++;
            }
        }

        return count;
    }
    
    private static long[] Parse(string input) => 
        input.Split('=').Last().Trim('[', ']').Split(',').Select(long.Parse).ToArray();

    public bool ShouldBeEngraved(long x, long y)
    {
        var result = (0L, 0L);
                
        for (var i = 0; i < 100; i++)
        {
            result = Multiply(result, result);
            result = Divide(result, (100_000, 100_000));
            result = Add(result, (x, y));

            if (Math.Abs(result.Item1) > 1_000_000 || Math.Abs(result.Item2) > 1_000_000)
                return false;
        }

        return true;
    }

    private (long, long) Multiply((long, long) a, (long, long) b)
    {
        var (x1, y1) = a;
        var (x2, y2) = b;
        return (x1 * x2 - y1 * y2, x1 * y2 + y1 * x2);
    }
    
    private (long, long) Divide((long, long) a, (long, long) b)
    {
        var (x1, y1) = a;
        var (x2, y2) = b;
        return (x1 / x2, y1 / y2);
    }
    
    private (long, long) Add((long, long) a, (long, long) b)
    {
        var (x1, y1) = a;
        var (x2, y2) = b;
        return (x1 + x2, y1 + y2);
    }
}