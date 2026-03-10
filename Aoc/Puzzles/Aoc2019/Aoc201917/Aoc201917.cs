using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2019.Aoc201917;

[Name("Set and Forget")]
public class Aoc201917 : AocPuzzle
{
    [Puzzle("8e35e428c486ee717b90ef52086fa0d3")]
    public PuzzleResult Part1(string input)
    {
        var sc = new ScaffoldingComputer1(input);
        var input2 = sc.Run();
        var sif = new ScaffoldIntersectionFinder(input2);
        var result1 = sif.GetSumOfAlignmentParameters();

        return new PuzzleResult(result1);
    }

    [Puzzle("8972452161d6f5ef5e3681d5ce31f9b6")]
    public PuzzleResult Part2(string input)
    {
        var sc2 = new ScaffoldingComputer2(input);
        var result2 = sc2.Run();

        return new PuzzleResult(result2);
    }
}