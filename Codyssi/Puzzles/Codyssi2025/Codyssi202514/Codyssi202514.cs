using Pzl.Common;
using Pzl.Tools.Numbers;
using Pzl.Tools.Strings;

namespace Pzl.Codyssi.Puzzles.Codyssi2025.Codyssi202514;

[Name("Crucial Crafting")]
public class Codyssi202514 : CodyssiPuzzle
{
    public PuzzleResult Part1(string input)
    {
        var data = input.Split(LineBreaks.Single).Select(Numbers.IntsFromString);
        var data2 = data.Select(o => (quality: o[1], cost: o[2], count: o[3]));
        data2 = data2.OrderByDescending(o => o.quality).ThenByDescending(o => o.cost);
        var top5Sum = data2.Take(5).Select(o => o.count).Sum();
        
        return new PuzzleResult(top5Sum, "43dd1272123cf25f4341c003d0fc6018");
    }

    public PuzzleResult Part2(string input)
    {
        return new PuzzleResult(0);
    }

    public PuzzleResult Part3(string input)
    {
        return new PuzzleResult(0);
    }
}