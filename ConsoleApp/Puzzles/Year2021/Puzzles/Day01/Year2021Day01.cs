using Core.SubmarineNavigation;

namespace ConsoleApp.Puzzles.Year2021.Puzzles.Day01
{
    public class Year2021Day01 : Year2021Day
    {
        public override int Day => 1;

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