using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2021.Aoc202110;

[Name("Syntax Scoring")]
public class Aoc202110 : AocPuzzle
{
    [Puzzle("e9bf166092809cfd161479766d825cb5")]
    public int Part1(string input) => new SyntaxChecker().GetTotalErrorScore(input);

    [Puzzle("064772af126a16832237033503572a30")]
    public long Part2(string input) => new SyntaxChecker().FindMiddleScore(input);
}