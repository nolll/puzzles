using Pzl.Common;
using Pzl.Tools.Numbers;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2024.Aoc202413;

[Name("Claw Contraption")]
public class Aoc202413 : AocPuzzle
{
    public PuzzleResult Part1(string input)
    {
        var cost = Solve(input);
        
        return new PuzzleResult(cost, "56660d12b57edc245008c03e719df0bf");
    }

    public PuzzleResult Part2(string input)
    {
        var cost = Solve(input, 10_000_000_000_000);
        
        return new PuzzleResult(cost, "54b0ade17d9b06307b53d22672608ba6");
    }
    
    public static long Solve(string input, long extension = 0)
    {
        var groups = input.Split(LineBreaks.Double);
        var totalCost = 0L;
        foreach (var s in groups)
        {
            var nums = Numbers.IntsFromString(s);
            var ax = nums[0];
            var ay = nums[1];
            var bx = nums[2];
            var by = nums[3];
            var tx = nums[4] + extension;
            var ty = nums[5] + extension;
            var a = (tx * by - ty * bx) / (ax * by - ay * bx);
            var b = (ty - ay * a) / by;
            if (a * ax + b * bx == tx && a * ay + b * by == ty)
                totalCost += a * 3 + b;
        }
        
        return totalCost;
    }
}