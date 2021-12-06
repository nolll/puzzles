using Core.PuzzleClasses;

namespace Core.Puzzles.Year2017.Day01
{
    public class Year2017Day01 : Year2017Day
    {
        public override int Day => 1;

        public override PuzzleResult RunPart1()
        {
            var calc = new CaptchaCalculator(FileInput);
            return new PuzzleResult(calc.Sum1, 1177);
        }

        public override PuzzleResult RunPart2()
        {
            var calc = new CaptchaCalculator(FileInput);
            return new PuzzleResult(calc.Sum2, 1060);
        }
    }
}