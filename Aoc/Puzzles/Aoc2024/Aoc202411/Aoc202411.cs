using FluentAssertions.Equivalency;
using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2024.Aoc202411;

[Name("Plutonian Pebbles")]
public class Aoc202411 : AocPuzzle
{
    public PuzzleResult Part1(string input) => new(Solve(input, 25), "adf47aa5d6a1f75ef41af973082e5a60");
    public PuzzleResult Part2(string input) => new(Solve(input, 75), "a58ca60460c322a69523c3daf83c423d");

    private static long Solve(string input, int blinkCount) => input.Split(' ')
        .Select(long.Parse)
        .Sum(o => CountStones(o, blinkCount, new Dictionary<(long, int), long>()));

    private static long CountStones(long n, int depth, Dictionary<(long, int), long> seen)
    {
        if (seen.TryGetValue((n, depth), out var cached))
            return cached;
        
        if (depth == 0)
            return 1;

        var nextDepth = depth - 1;
        long result;
        
        if (n == 0)
            result = CountStones(1, nextDepth, seen);
        else if (n.ToString().Length % 2 == 0)
            result = Cut(n).Sum(o => CountStones(o, nextDepth, seen));
        else
            result = CountStones(n * 2024, nextDepth, seen);

        seen.TryAdd((n, depth), result);
        return result;
    }

    private static long[] Cut(long x)
    {
        var s = x.ToString();
        var halfLength = s.Length / 2;
        var p1 = long.Parse(s[..halfLength]);
        var p2 = long.Parse(s[halfLength..]);
        return [p1, p2];
    }
}