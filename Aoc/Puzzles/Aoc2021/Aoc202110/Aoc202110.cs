using Puzzles.Common.Puzzles;

namespace Pzl.Aoc.Puzzles.Aoc2021.Aoc202110;

public class Aoc202110 : AocPuzzle
{
    public override string Name => "Syntax Scoring";

    protected override PuzzleResult RunPart1()
    {
        var syntaxChecker = new SyntaxChecker();
        var result = syntaxChecker.GetTotalErrorScore(InputFile);
        return new PuzzleResult(result, "e9bf166092809cfd161479766d825cb5");
    }

    protected override PuzzleResult RunPart2()
    {
        var syntaxChecker = new SyntaxChecker();
        var result = syntaxChecker.FindMiddleScore(InputFile);
        return new PuzzleResult(result, "064772af126a16832237033503572a30");
    }
}