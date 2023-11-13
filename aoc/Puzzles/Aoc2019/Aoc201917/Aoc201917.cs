using Puzzles.common.Puzzles;

namespace Puzzles.aoc.Puzzles.Aoc2019.Aoc201917;

public class Aoc201917 : AocPuzzle
{
    public override string Name => "Set and Forget";

    protected override PuzzleResult RunPart1()
    {
        var sc = new ScaffoldingComputer1(InputFile);
        var input = sc.Run();
        var sif = new ScaffoldIntersectionFinder(input);
        var result1 = sif.GetSumOfAlignmentParameters();

        return new PuzzleResult(result1, "8e35e428c486ee717b90ef52086fa0d3");
    }

    protected override PuzzleResult RunPart2()
    {
        var sc2 = new ScaffoldingComputer2(InputFile);
        var result2 = sc2.Run();

        return new PuzzleResult(result2, "8972452161d6f5ef5e3681d5ce31f9b6");
    }
}