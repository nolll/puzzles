using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2021.Aoc202110;

[Name("Syntax Scoring")]
public class Aoc202110(string input) : AocPuzzle(input)
{
    protected override PuzzleResult RunPart1()
    {
        var syntaxChecker = new SyntaxChecker();
        var result = syntaxChecker.GetTotalErrorScore(Input);
        return new PuzzleResult(result, "e9bf166092809cfd161479766d825cb5");
    }

    protected override PuzzleResult RunPart2()
    {
        var syntaxChecker = new SyntaxChecker();
        var result = syntaxChecker.FindMiddleScore(Input);
        return new PuzzleResult(result, "064772af126a16832237033503572a30");
    }
}