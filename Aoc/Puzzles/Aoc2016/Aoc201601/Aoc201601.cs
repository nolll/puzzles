using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2016.Aoc201601;

[Name("No Time for a Taxicab")]
public class Aoc201601(string input) : AocPuzzle
{
    protected override PuzzleResult RunPart1()
    {
        var calc = new EasterbunnyDistanceCalculator();
        calc.Go(input);
        return new PuzzleResult(calc.DistanceToTarget, "1dd73ae9ac359d399e07fb888b022f7a");
    }

    protected override PuzzleResult RunPart2()
    {
        var calc = new EasterbunnyDistanceCalculator();
        calc.Go(input);
        return new PuzzleResult(calc.DistanceToFirstRepeat, "4648ca473c884f7676991b343c2db8e0");
    }
}