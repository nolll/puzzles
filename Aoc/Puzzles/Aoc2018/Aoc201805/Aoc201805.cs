using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2018.Aoc201805;

[Name("Alchemical Reduction")]
public class Aoc201805 : AocPuzzle
{
    [Puzzle("b0180e8fdf70d1a6cb40a7e588873a5f")]
    public int Part1(string input) => new PolymerPuzzle().GetReducedPolymer(input).Length;

    [Puzzle("923436b9c396a53a404f30f51617b9d9")]
    public int Part2(string input) => new PolymerPuzzle().GetImprovedPolymer(input).Length;
}