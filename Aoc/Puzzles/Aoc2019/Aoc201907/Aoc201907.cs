using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2019.Aoc201907;

[Name("Amplification Circuit")]
public class Aoc201907 : AocPuzzle
{
    [Puzzle("2fbd6d244a35bf75a6d51c8962133afe")]
    public long Part1(string input) => new ThrustCalculator(input).GetMaxThrust([0, 1, 2, 3, 4]);

    [Puzzle("af273de2fc8e4b54d4d877645ded2d03")]
    public long Part2(string input) => new ThrustCalculator(input).GetMaxThrust([5, 6, 7, 8, 9]);
}