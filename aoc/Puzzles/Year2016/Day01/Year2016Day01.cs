using Common.Puzzles;

namespace Aoc.Puzzles.Year2016.Day01;

public class Year2016Day01 : AocPuzzle
{
    public override string Name => "No Time for a Taxicab";

    protected override PuzzleResult RunPart1()
    {
        var calc = new EasterbunnyDistanceCalculator();
        calc.Go(FileInput);
        return new PuzzleResult(calc.DistanceToTarget, 262);
    }

    protected override PuzzleResult RunPart2()
    {
        var calc = new EasterbunnyDistanceCalculator();
        calc.Go(FileInput);
        return new PuzzleResult(calc.DistanceToFirstRepeat, 131);
    }
}