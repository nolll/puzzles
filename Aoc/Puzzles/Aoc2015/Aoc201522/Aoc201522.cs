using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2015.Aoc201522;

[Name("Wizard Simulator 20XX")]
public class Aoc201522 : AocPuzzle
{
    [Puzzle("1f020968b40b91444beee0e8a33624d1")]
    public int Part1(string input)
    {
        var p = GetParams(input);
        return new WizardRpgSimulator(WizardRpgGameMode.Easy).WinWithLowestCost(p.HitPoints, p.Damage);
    }

    [Puzzle("d76b3b0ad8b9bce7fab0c1ba0de0d20e")]
    public int Part2(string input)
    {
        var p = GetParams(input);
        return new WizardRpgSimulator(WizardRpgGameMode.Hard).WinWithLowestCost(p.HitPoints, p.Damage);
    }

    private static Params GetParams(string input)
    {
        var rows = input.Split(LineBreaks.Single);
        return new Params(GetIntFromRow(rows[0]), GetIntFromRow(rows[1]));
    }

    private static int GetIntFromRow(string s) => int.Parse(s.Split(':')[1].Trim());

    private record Params(int HitPoints, int Damage);
}