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
            foreach (var (a, b) in strings)
            {
                if (x == a || x == b || y == a || y == b)
                    continue;

                
                if ((x > a && x < b) != (y > a && y < b))
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
                foreach (var (a, b) in strings)
                {
                    if (x == a && y == b || y == a && x == b)
                        intersectionCount++;
                    
                    if (x == a || x == b || y == a || y == b)
                        continue;
                    
                    if ((x > a && x < b) != (y > a && y < b))
                        intersectionCount++;
                }

                best = Math.Max(best, intersectionCount);
            }
        }
        
        return best;
    }
    
    private static int[] Parse(string input) => input.Split(',').Select(int.Parse).ToArray();
}