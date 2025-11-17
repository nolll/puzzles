using Pzl.Common;

namespace Pzl.Everybody.Puzzles.Ece2025.Ece202508;

[Name("The Art of Connection")]
public class Ece202508 : EverybodyEventPuzzle
{
    public PuzzleResult Part1(string input) => new(Part1(input, 32), "13e1a785ec9325ce343a99dda7a6745f");

    public int Part1(string input, int nailCount) => 
        Parse(input).Zip(Parse(input).Skip(1)).Count(o => Math.Abs(o.Second - o.First) == nailCount / 2);

    public PuzzleResult Part2(string input)
    {
        var numbers = Parse(input);
        List<(int, int)> strings = [];
        var knotCount = 0;
        foreach (var (x, y) in numbers.Zip(numbers.Skip(1)))
        {
            var cut = (x, y);
            foreach (var line in strings)
            {
                if (HasCommonNail(cut, line))
                    continue;

                if (IsCrossing(cut, line))
                    knotCount++;
            }
            
            strings.Add((Math.Min(x, y), Math.Max(x, y)));
        }
        
        return new PuzzleResult(knotCount, "b5e871831bb11b7eddb421c81e170748");
    }

    public PuzzleResult Part3(string input) => new(Part3(input, 256), "2681ae91ee4e40ef531ab7d2cdd31f8b");

    public int Part3(string input, int nailCount)
    {
        var numbers = Parse(input);
        List<(int, int)> strings = [];
        foreach (var (x, y) in numbers.Zip(numbers.Skip(1)))
        {
            strings.Add((Math.Min(x, y), Math.Max(x, y)));
        }

        var best = 0;

        for (var x = 1; x <= nailCount; x++)
        {
            for (var y = x + 1; y <= nailCount; y++)
            {
                var intersectionCount = 0;
                var cut = (x, y);
                foreach (var line in strings)
                {
                    if (AreEqual(cut, line))
                        intersectionCount++;

                    if (HasCommonNail(cut, line))
                        continue;

                    if (IsCrossing(cut, line))
                        intersectionCount++;
                }

                best = Math.Max(best, intersectionCount);
            }
        }
        
        return best;
    }

    private static bool IsCrossing((int x, int y) v1, (int a, int b) v2) => 
        (v1.x > v2.a && v1.x < v2.b) != (v1.y > v2.a && v1.y < v2.b);

    private static bool HasCommonNail((int a, int b) v1, (int a, int b) v2) => 
        v1.a == v2.a || v1.a == v2.b || v1.b == v2.a || v1.b == v2.b;

    private static bool AreEqual((int a, int b) v1, (int a, int b) v2) => 
        v1.a == v2.a && v1.b == v2.b || v1.b == v2.a && v1.a == v2.b;

    private static int[] Parse(string input) => input.Split(',').Select(int.Parse).ToArray();
}