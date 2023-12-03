using Puzzles.common.Puzzles;
using Puzzles.common.Strings;

namespace Puzzles.aoc.Puzzles.Aoc2015.Aoc201522;

public class Aoc201522 : AocPuzzle
{
    public override string Name => "Wizard Simulator 20XX";

    protected override PuzzleResult RunPart1()
    {
        var p = GetParams();
        var simulator = new WizardRpgSimulator(WizardRpgGameMode.Easy);
        var leastManaRequiredToWinEasy = simulator.WinWithLowestCost(p.HitPoints, p.Damage);
        return new PuzzleResult(leastManaRequiredToWinEasy, "1f020968b40b91444beee0e8a33624d1");
    }

    protected override PuzzleResult RunPart2()
    {
        var p = GetParams();
        var simulator = new WizardRpgSimulator(WizardRpgGameMode.Hard);
        var leastManaRequiredToWinHard = simulator.WinWithLowestCost(p.HitPoints, p.Damage);
        return new PuzzleResult(leastManaRequiredToWinHard, "d76b3b0ad8b9bce7fab0c1ba0de0d20e");
    }

    private Params GetParams()
    {
        var rows = StringReader.ReadLines(InputFile);

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