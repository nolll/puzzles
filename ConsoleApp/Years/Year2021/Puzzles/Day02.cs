using Core.SeaDepth;

namespace ConsoleApp.Years.Year2021.Puzzles
{
    public class Day02 : Day2021
    {
        public Day02() : base(2)
        {
        }

        public override PuzzleResult RunPart1()
        {
            var calculator = new SubmarineNavigation(false);
            var result = calculator.Move(FileInput);
            
            return new PuzzleResult(result, 1580000);
        }

        public override PuzzleResult RunPart2()
        {
            var calculator = new SubmarineNavigation(true);
            var result = calculator.Move(FileInput);

            return new PuzzleResult(result);
        }
    }
}