using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2020.Aoc202003;

[Name("Toboggan Trajectory")]
public class Aoc202003 : AocPuzzle
{
    [Puzzle("5523923bd52d76e1c1d68b1cfdff95b5")]
    public long Part1(string input) => new TreeNavigator(input).GetSingleTreeCount();

    [Puzzle("2429f66aeab700cdc54b44c6b498a22b")]
    public long Part2(string input) => new TreeNavigator(input).GetAllTreeCounts().Aggregate((long)1, (a, b) => a * b);
}