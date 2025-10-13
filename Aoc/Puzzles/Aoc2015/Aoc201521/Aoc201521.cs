using Pzl.Common;
using Pzl.Tools.Numbers;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2015.Aoc201521;

[Name("RPG Simulator 20XX")]
public class Aoc201521 : AocPuzzle
{
    public PuzzleResult Part1(string input)
    {
        var (hitPoints, damage, armor) = Numbers.IntsFromString(input);
        var simulator = new RpgSimulator();
        var leastGoldRequiredToWin = simulator.WinWithLowestCost(hitPoints, damage, armor);
        return new PuzzleResult(leastGoldRequiredToWin, "d826748d893fac708069e01d784895e8");
    }

    public PuzzleResult Part2(string input)
    {
        var (hitPoints, damage, armor) = Numbers.IntsFromString(input);
        var simulator = new RpgSimulator();
        var mostGoldThatLoses = simulator.LoseWithHighestCost(hitPoints, damage, armor);
        return new PuzzleResult(mostGoldThatLoses, "0eeae3017f640ddc69c8b13ff60c9f0f");
    }
}