using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2016.Aoc201601;

public class Aoc201601 : AocPuzzle
{
    public override string Name => "No Time for a Taxicab";

    protected override PuzzleResult RunPart1()
    {
        var calc = new EasterbunnyDistanceCalculator();
        calc.Go(InputFile);
        return new PuzzleResult(calc.DistanceToTarget, 262);
    }

    protected override PuzzleResult RunPart2()
    {
        var calc = new EasterbunnyDistanceCalculator();
        calc.Go(InputFile);
        return new PuzzleResult(calc.DistanceToFirstRepeat, 131);
    }
}