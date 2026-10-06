using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2017;

[Name("Spinlock")]
public class Aoc201717 : AocPuzzle
{
    [Puzzle("ddce3b9888bd1dd2364ae8ba030b674f")]
    public int Part1(string input) => RunPart1(int.Parse(input), 2017);

    [Puzzle("9d9ce3fec64cbea9caf918562df54fe4")]
    public int Part2(string input) => RunPart2(int.Parse(input), 50_000_000);

    public int RunPart1(int steps, int target)
    {
        var list = new LinkedList<int>();
        var current = list.AddLast(0);
        var v = 1;
        while (v <= target)
        {
            for (var i = 0; i < steps; i++)
            {
                current = current.NextOrFirst();
            }

            current = list.AddAfter(current, v);
            v++;
        }
            
        return current.Next?.Value ?? 0;
    }
    
    public int RunPart2(int steps, int target)
    {
        var secondValue = 0;
        var v = 1;
        var pos = 0;
        while (v <= target)
        {
            pos += steps;
            while (pos > v - 1) 
                pos -= v;

            if (pos == 0)
                secondValue = v;
            pos++;
            v++;
        }

        return secondValue;
    }
}