using Pzl.Common;
using Pzl.Tools.Lists;
using Pzl.Tools.Numbers;

namespace Pzl.Everybody.Puzzles.Ece2025.Ece202502;

[Name("From Complex to Clarity")]
public class Ece202502 : EverybodyEventPuzzle
{
    private const long Part1Divisor = 10;
    private const long Part2And3Divisor = 100_000;
    private const long InitialValue = 0L;
    private const int NumCycles = 100;
    private const long Limit = 1_000_000;

    public PuzzleResult RunPart1(string input)
    {
        var (a, b) = Numbers.LongsFromString(input);

        var result = (InitialValue, InitialValue);
        for (var i = 0; i < 3; i++)
        {
            result = Multiply(result, result);
            result = Divide(result, (Part1Divisor, Part1Divisor));
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
        var (sx, sy) = Numbers.LongsFromString(input);
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

    public static bool ShouldBeEngraved(long x, long y)
    {
        var result = (InitialValue, InitialValue);
                
        for (var i = 0; i < NumCycles; i++)
        {
            result = Multiply(result, result);
            result = Divide(result, (Part2And3Divisor, Part2And3Divisor));
            result = Add(result, (x, y));

            if (Math.Abs(result.Item1) > Limit || Math.Abs(result.Item2) > Limit)
                return false;
        }

        return true;
    }

    private static (long, long) Multiply((long a, long b) a, (long a, long b) b) => (a.a * b.a - a.b * b.b, a.a * b.b + a.b * b.a);
    private static (long, long) Divide((long a, long b) a, (long a, long b) b) => (a.a / b.a, a.b / b.b);
    private static (long, long) Add((long a, long b) a, (long a, long b) b) => (a.a + b.a, a.b + b.b);
}