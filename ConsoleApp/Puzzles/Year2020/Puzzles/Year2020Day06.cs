using Core.CustomDeclarations;

namespace ConsoleApp.Puzzles.Year2020.Puzzles
{
    public class Year2020Day06 : Year2020Day
    {
        public override int Day => 6;

        public override PuzzleResult RunPart1()
        {
            var reader = new DeclarationFormReader(FileInput);
            return new PuzzleResult(reader.SumOfAtLeastOneYes, 6778);
        }

        public override PuzzleResult RunPart2()
        {
            var reader = new DeclarationFormReader(FileInput);
            return new PuzzleResult(reader.SumOfAllYes, 3406);
        }
    }
}