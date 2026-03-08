using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2016.Aoc201601;

[Name("No Time for a Taxicab")]
public class Aoc201601 : AocPuzzle
{
    [Puzzle("1dd73ae9ac359d399e07fb888b022f7a")]
    public int Part1(string input)
    {
        var calc = new EasterbunnyDistanceCalculator();
        calc.Go(input);
        return calc.DistanceToTarget;
    }

    [Puzzle("4648ca473c884f7676991b343c2db8e0")]
    public int Part2(string input)
    {
        var calc = new EasterbunnyDistanceCalculator();
        calc.Go(input);
        return calc.DistanceToFirstRepeat;
    }
}