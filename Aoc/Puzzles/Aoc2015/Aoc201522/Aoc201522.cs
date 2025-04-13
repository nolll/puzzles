﻿using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2015.Aoc201522;

[Name("Wizard Simulator 20XX")]
public class Aoc201522 : AocPuzzle
{
    public PuzzleResult Part1(string input)
    {
        var p = GetParams(input);
        var simulator = new WizardRpgSimulator(WizardRpgGameMode.Easy);
        var leastManaRequiredToWinEasy = simulator.WinWithLowestCost(p.HitPoints, p.Damage);
        return new PuzzleResult(leastManaRequiredToWinEasy, "1f020968b40b91444beee0e8a33624d1");
    }

    public PuzzleResult Part2(string input)
    {
        var p = GetParams(input);
        var simulator = new WizardRpgSimulator(WizardRpgGameMode.Hard);
        var leastManaRequiredToWinHard = simulator.WinWithLowestCost(p.HitPoints, p.Damage);
        return new PuzzleResult(leastManaRequiredToWinHard, "d76b3b0ad8b9bce7fab0c1ba0de0d20e");
    }

    private static Params GetParams(string input)
    {
        var rows = StringReader.ReadLines(input);

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