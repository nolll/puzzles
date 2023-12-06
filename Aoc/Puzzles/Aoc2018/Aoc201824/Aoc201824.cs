using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2018.Aoc201824;

public class Aoc201824 : AocPuzzle
{
    public override string Name => "Immune System Simulator 20XX";

    protected override PuzzleResult RunPart1()
    {
        var inputs = InputFile.Split("\r\n\r\n");
        var immuneInput = inputs.First();
        var infectionInput = inputs.Last();

        var system = new ImmuneSystem(immuneInput, infectionInput);
        system.Fight();
        return new PuzzleResult(system.WinningArmyUnitCount, "84df04e9e9a02e41225db74dadfd8c9d");
    }

    protected override PuzzleResult RunPart2()
    {
        var inputs = InputFile.Split("\r\n\r\n");
        var immuneInput = inputs.First();
        var infectionInput = inputs.Last();
            
        var system = new ImmuneSystem(immuneInput, infectionInput);
        system.FightUntilImmuneSystemWins();
        return new PuzzleResult(system.WinningArmyUnitCount, "bfce9d78a8a72d8fd0d76fd5fc479dc8");
    }
}