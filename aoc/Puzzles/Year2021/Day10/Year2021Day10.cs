using Aoc.Platform;
using common.Puzzles;

namespace Aoc.Puzzles.Year2021.Day10;

public class Year2021Day10 : AocPuzzle
{
    public override string Name => "Syntax Scoring";

    protected override PuzzleResult RunPart1()
    {
        var syntaxChecker = new SyntaxChecker();
        var result = syntaxChecker.GetTotalErrorScore(FileInput);
        return new PuzzleResult(result, 399153);
    }

    protected override PuzzleResult RunPart2()
    {
        var syntaxChecker = new SyntaxChecker();
        var result = syntaxChecker.FindMiddleScore(FileInput);
        return new PuzzleResult(result, 2995077699);
    }
}