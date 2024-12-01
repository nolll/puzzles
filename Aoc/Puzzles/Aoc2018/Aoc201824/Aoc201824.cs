using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2018.Aoc201824;

[Name("Immune System Simulator 20XX")]
public class Aoc201824 : AocPuzzle
{
    public PuzzleResult RunPart1(string input)
    {
        var inputs = input.Split(LineBreaks.Double);
        var immuneInput = inputs.First();
        var infectionInput = inputs.Last();

        var system = new ImmuneSystem(immuneInput, infectionInput);
        system.Fight();
        return new PuzzleResult(system.WinningArmyUnitCount, "84df04e9e9a02e41225db74dadfd8c9d");
    }

    public PuzzleResult RunPart2(string input)
    {
        var inputs = input.Split(LineBreaks.Double);
        var immuneInput = inputs.First();
        var infectionInput = inputs.Last();
            
        var system = new ImmuneSystem(immuneInput, infectionInput);
        system.FightUntilImmuneSystemWins();
        return new PuzzleResult(system.WinningArmyUnitCount, "bfce9d78a8a72d8fd0d76fd5fc479dc8");
    }
}