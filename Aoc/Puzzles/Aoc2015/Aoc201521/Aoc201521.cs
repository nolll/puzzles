using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2015.Aoc201521;

[Name("RPG Simulator 20XX")]
public class Aoc201521 : AocPuzzle
{
    protected override PuzzleResult RunPart1(string input)
    {
        var p = GetParams(input);
        var simulator = new RpgSimulator();
        var leastGoldRequiredToWin = simulator.WinWithLowestCost(p.HitPoints, p.Damage, p.Armor);
        return new PuzzleResult(leastGoldRequiredToWin, "d826748d893fac708069e01d784895e8");
    }

    protected override PuzzleResult RunPart2(string input)
    {
        var p = GetParams(input);
        var simulator = new RpgSimulator();
        var mostGoldThatLoses = simulator.LoseWithHighestCost(p.HitPoints, p.Damage, p.Armor);
        return new PuzzleResult(mostGoldThatLoses, "0eeae3017f640ddc69c8b13ff60c9f0f");
    }

    private Params GetParams(string input)
    {
        var rows = StringReader.ReadLines(input);

        return new Params
        {
            HitPoints = GetIntFromRow(rows[0]),
            Damage = GetIntFromRow(rows[1]),
            Armor = GetIntFromRow(rows[2])
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
        public int Armor { get; set; }
    }
}