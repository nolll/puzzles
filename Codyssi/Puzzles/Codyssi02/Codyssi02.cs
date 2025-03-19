using Pzl.Common;
using Pzl.Tools.Numbers;
using Pzl.Tools.Strings;

namespace Pzl.Codyssi.Puzzles.Codyssi02;

[Name("Absurd Arithmetic")]
public class Codyssi02 : CodyssiPuzzle
{
    public PuzzleResult Part1(string input)
    {
        var parts = input.Split(LineBreaks.Double);
        var opnums = Numbers.IntsFromString(parts.First());
        var items = parts.Last().Split(LineBreaks.Single).Select(long.Parse).Order().ToArray();
        var n = items[items.Length / 2];
        n = (long)Math.Pow(n, opnums[2]);
        n *= opnums[1];
        n += opnums[0];
        
        return new PuzzleResult(n, "08f294141be67fb8ce4f13e39d3f12d0");
    }

    public PuzzleResult Part2(string input)
    {
        var parts = input.Split(LineBreaks.Double);
        var opnums = Numbers.IntsFromString(parts.First());
        var items = parts.Last().Split(LineBreaks.Single).Select(long.Parse).Order().ToArray();
        var n = items.Where(o => o % 2 == 0).Sum();
        n = (long)Math.Pow(n, opnums[2]);
        n *= opnums[1];
        n += opnums[0];
        
        return new PuzzleResult(n, "f53524668fe091cf2cd65be1bf22d73f");
    }

    public PuzzleResult Part3(string input)
    {
        const long max = 15_000_000_000_000;
        
        var parts = input.Split(LineBreaks.Double);
        var opnums = Numbers.IntsFromString(parts.First());
        var items = parts.Last().Split(LineBreaks.Single).Select(long.Parse).Order().ToArray();
        var best = 0L;
        var bestRoom = 0L;
        foreach (var item in items)
        {
            var n = (long)Math.Pow(item, opnums[2]);
            n *= opnums[1];
            n += opnums[0];

            if (n > max || n <= best)
                continue;
            
            best = n;
            bestRoom = item;
        }
        
        
        return new PuzzleResult(bestRoom, "4366f7c950d582ccdb298e25d136b3b9");
    }
}