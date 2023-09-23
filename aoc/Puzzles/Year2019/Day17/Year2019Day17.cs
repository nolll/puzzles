using Common.Puzzles;

namespace Aoc.Puzzles.Year2019.Day17;

public class Year2019Day17 : AocPuzzle
{
    public override string Name => "Set and Forget";

    protected override PuzzleResult RunPart1()
    {
        var sc = new ScaffoldingComputer1(InputFile);
        var input = sc.Run();
        var sif = new ScaffoldIntersectionFinder(input);
        var result1 = sif.GetSumOfAlignmentParameters();

        return new PuzzleResult(result1, 8408);
    }

    protected override PuzzleResult RunPart2()
    {
        var sc2 = new ScaffoldingComputer2(InputFile);
        var result2 = sc2.Run();

        return new PuzzleResult(result2, 1_168_948);
    }
}