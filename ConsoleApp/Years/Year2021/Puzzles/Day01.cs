using Core.SubmarineNavigation;

namespace ConsoleApp.Years.Year2021.Puzzles
{
    public class Day01 : Day2021
    {
        public Day01() : base(1)
        {
        }

        public override PuzzleResult RunPart1()
        {
            var calculator = new DepthMeasurement();
            var result = calculator.GetNumberOfIncreasingMeasurements(FileInput, false);
            
            return new PuzzleResult(result, 1477);
        }

        public override PuzzleResult RunPart2()
        {
            var calculator = new DepthMeasurement();
            var result = calculator.GetNumberOfIncreasingMeasurements(FileInput, true);

            return new PuzzleResult(result, 1523);
        }
    }
}