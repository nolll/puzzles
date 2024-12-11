using FluentAssertions.Equivalency;
using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2024.Aoc202411;

[Name("Plutonian Pebbles")]
public class Aoc202411 : AocPuzzle
{
    public PuzzleResult Part1(string input) => new(Solve(input, 25), "adf47aa5d6a1f75ef41af973082e5a60");
    public PuzzleResult Part2(string input) => new(Solve(input, 75), "a58ca60460c322a69523c3daf83c423d");

    private long Solve(string input, int blinkCount) => input.Split(' ')
        .Select(long.Parse)
        .Sum(o => CountStones(o, blinkCount, new Dictionary<(long, int), long>()));

    private long CountStones(long n, int depth, Dictionary<(long, int), long> seen)
    {
        if (seen.TryGetValue((n, depth), out var cached))
            return cached;
        
        if (depth == 0)
            return 1;

        var nextDepth = depth - 1;
        
        if (n == 0)
        {
            var p = 1;
            var c = CountStones(1, nextDepth, seen);
            var key = (p, nextDepth);
            seen.TryAdd(key, c);
            return c;
        }

        var s = n.ToString(); 
        if(s.Length % 2 == 0)
        {
            var halfLength = s.Length / 2;
            var p1 = long.Parse(s[..halfLength]);
            var p2 = long.Parse(s[halfLength..]);
            var c1 = CountStones(p1, nextDepth, seen);
            var c2 = CountStones(p2, nextDepth, seen);
            seen.TryAdd((p1, nextDepth), c1);
            seen.TryAdd((p2, nextDepth), c2);
            return c1 + c2;
        }

        var pp = n * 2024;
        var cc = CountStones(pp, nextDepth, seen);
        var kk = (pp, nextDepth);
        seen.TryAdd(kk, cc);
        return cc;
    }
}