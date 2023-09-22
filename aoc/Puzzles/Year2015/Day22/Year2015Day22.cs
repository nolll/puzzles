﻿using Aoc.Platform;
using common.Puzzles;
using common.Strings;

namespace Aoc.Puzzles.Year2015.Day22;

public class Year2015Day22 : AocPuzzle
{
    public override string Name => "Wizard Simulator 20XX";

    protected override PuzzleResult RunPart1()
    {
        var p = GetParams();
        var simulator = new WizardRpgSimulator(WizardRpgGameMode.Easy);
        var leastManaRequiredToWinEasy = simulator.WinWithLowestCost(p.HitPoints, p.Damage);
        return new PuzzleResult(leastManaRequiredToWinEasy, 1824);
    }

    protected override PuzzleResult RunPart2()
    {
        var p = GetParams();
        var simulator = new WizardRpgSimulator(WizardRpgGameMode.Hard);
        var leastManaRequiredToWinHard = simulator.WinWithLowestCost(p.HitPoints, p.Damage);
        return new PuzzleResult(leastManaRequiredToWinHard, 1937);
    }

    private Params GetParams()
    {
        var rows = PuzzleInputReader.ReadLines(FileInput);

        return new Params
        {
            HitPoints = GetIntFromRow(rows[0]),
            Damage = GetIntFromRow(rows[1])
        };
    }

    private static int GetIntFromRow(string s)
    {
        return int.Parse(s.Split(':')[1].Trim());
    }

    private class Params
    {
        public int HitPoints { get; set; }
        public int Damage { get; set; }
    }
}