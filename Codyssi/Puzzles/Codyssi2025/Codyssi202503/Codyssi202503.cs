using Pzl.Common;
using Pzl.Tools.Numbers;
using Pzl.Tools.Strings;

namespace Pzl.Codyssi.Puzzles.Codyssi2025.Codyssi202503;

[Name("Supplies in Surplus")]
public class Codyssi202503 : CodyssiPuzzle
{
    public PuzzleResult Part1(string input)
    {
        var lines = input.Split(LineBreaks.Single);
        var boxCount = 0;
        foreach (var line in lines)
        {
            var piles = line.Split(' ');
            foreach (var pile in piles)
            {
                var nums = Numbers.IntsFromString(pile.Replace('-', ' '));
                var count = nums[1] - nums[0] + 1;
                boxCount += count;
            }
        }
        
        return new PuzzleResult(boxCount, "01d1552220dda559a422036ab711923e");
    }

    public PuzzleResult Part2(string input)
    {
        var lines = input.Split(LineBreaks.Single);
        var boxCount = lines.Sum(line => GetLabels(line).Count);

        return new PuzzleResult(boxCount, "1cb7e24878302f60b0ba3be5141cdc32");
    }

    public PuzzleResult Part3(string input)
    {
        var lines = input.Split(LineBreaks.Single);
        var best = 0;
        for (var i = 0; i < lines.Length - 1; i++)
        {
            var set = GetLabels(lines[i]);
            set.UnionWith(GetLabels(lines[i + 1]));
            best = Math.Max(set.Count, best);
        }

        return new PuzzleResult(best, "2cbe9f9e03bce403a08a5395b3be8757");
    }
    
    private static HashSet<int> GetLabels(string line)
    {
        var piles = line.Split(' ');
        var set = new HashSet<int>();
        foreach (var pile in piles)
        {
            var nums = Numbers.IntsFromString(pile.Replace('-', ' '));
            for (var i = nums[0]; i <= nums[1]; i++)
            {
                set.Add(i);
            }
        }

        return set;
    }
}