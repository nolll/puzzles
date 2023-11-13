using Puzzles.common.Puzzles;

namespace Puzzles.aoc.Puzzles.Aoc2016.Aoc201601;

public class Aoc201601 : AocPuzzle
{
    public override string Name => "No Time for a Taxicab";

    protected override PuzzleResult RunPart1()
    {
        var calc = new EasterbunnyDistanceCalculator();
        calc.Go(InputFile);
        return new PuzzleResult(calc.DistanceToTarget, "1dd73ae9ac359d399e07fb888b022f7a");
    }

    protected override PuzzleResult RunPart2()
    {
        var calc = new EasterbunnyDistanceCalculator();
        calc.Go(InputFile);
        return new PuzzleResult(calc.DistanceToFirstRepeat, "4648ca473c884f7676991b343c2db8e0");
    }
}