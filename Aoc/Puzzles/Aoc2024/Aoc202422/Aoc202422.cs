using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2024.Aoc202422;

[Name("Monkey Market")]
public class Aoc202422 : AocPuzzle
{
    public PuzzleResult Part1(string input)
    {
        var nums = input.Split(LineBreaks.Single).Select(long.Parse);
        var sum = nums.Sum(o => Generate(o, 2000));
        
        return new PuzzleResult(sum, "225cb6b8a716ce111cab52fc1ee82264");
    }

    public PuzzleResult Part2(string input)
    {
        return new PuzzleResult(0);
    }

    public long Generate(long n, int iterations) => 
        Enumerable.Range(0, iterations).Aggregate(n, (current, _) => Generate(current));

    private long Generate(long n)
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