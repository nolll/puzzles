using Pzl.Common;
using Pzl.Tools.Numbers;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2015.Aoc201521;

[Name("RPG Simulator 20XX")]
public class Aoc201521 : AocPuzzle
{
    [Puzzle("d826748d893fac708069e01d784895e8")]
    public int Part1(string input)
    {
        var (hitPoints, damage, armor) = Numbers.IntsFromString(input);
        return new RpgSimulator().WinWithLowestCost(hitPoints, damage, armor);
    }

    [Puzzle("0eeae3017f640ddc69c8b13ff60c9f0f")]
    public int Part2(string input)
    {
        var (hitPoints, damage, armor) = Numbers.IntsFromString(input);
        return new RpgSimulator().LoseWithHighestCost(hitPoints, damage, armor);
    }
}