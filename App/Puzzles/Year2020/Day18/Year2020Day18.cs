using App.Platform;

namespace App.Puzzles.Year2020.Day18
{
    public class Year2020Day18 : Puzzle
    {
        public override PuzzleResult RunPart1()
        {
            var calculator = new HomeworkCalculator();
            var result = calculator.SumOfAll(FileInput, MathPrecedence.Order);
            return new PuzzleResult(result, 4_297_397_455_886);
        }

        public override PuzzleResult RunPart2()
        {
            var calculator = new HomeworkCalculator();
            var result = calculator.SumOfAll(FileInput, MathPrecedence.Addition);
            return new PuzzleResult(result, 93_000_656_194_428);
        }
    }
}