using App.Platform;

namespace App.Puzzles.Year2021.Day10
{
    public class Year2021Day10 : Puzzle
    {
        public override string Title => "Syntax Scoring";

        public override PuzzleResult RunPart1()
        {
            var syntaxChecker = new SyntaxChecker();
            var result = syntaxChecker.GetTotalErrorScore(FileInput);
            return new PuzzleResult(result, 399153);
        }

        public override PuzzleResult RunPart2()
        {
            var syntaxChecker = new SyntaxChecker();
            var result = syntaxChecker.FindMiddleScore(FileInput);
            return new PuzzleResult(result, 2995077699);
        }
    }
}