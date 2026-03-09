using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2018.Aoc201824;

[Name("Immune System Simulator 20XX")]
public class Aoc201824 : AocPuzzle
{
    [Puzzle("84df04e9e9a02e41225db74dadfd8c9d")]
    public int Part1(string input)
    {
        var inputs = input.Split(LineBreaks.Double);
        var system = new ImmuneSystem(inputs.First(), inputs.Last());
        system.Fight();
        return system.WinningArmyUnitCount;
    }

    [Puzzle("bfce9d78a8a72d8fd0d76fd5fc479dc8")]
    public int Part2(string input)
    {
        var inputs = input.Split(LineBreaks.Double);
        var system = new ImmuneSystem(inputs.First(), inputs.Last());
        system.FightUntilImmuneSystemWins();
        return system.WinningArmyUnitCount;
    }
}