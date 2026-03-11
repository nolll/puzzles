using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2019.Aoc201917;

[Name("Set and Forget")]
public class Aoc201917 : AocPuzzle
{
    [Puzzle("8e35e428c486ee717b90ef52086fa0d3")]
    public int Part1(string input)
    {
        var sc = new ScaffoldingComputer1(input);
        return new ScaffoldIntersectionFinder(sc.Run()).GetSumOfAlignmentParameters();
    }

    [Puzzle("8972452161d6f5ef5e3681d5ce31f9b6")]
    public long Part2(string input) => new ScaffoldingComputer2(input).Run();
}