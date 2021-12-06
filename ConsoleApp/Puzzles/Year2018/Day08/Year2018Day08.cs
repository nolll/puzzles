using Core.PuzzleClasses;

namespace ConsoleApp.Puzzles.Year2018.Day08
{
    public class Year2018Day08 : Year2018Day
    {
        public override int Day => 8;

        public override PuzzleResult RunPart1()
        {
            var calculator = new LicenseNumberCalculator(FileInput);
            return new PuzzleResult(calculator.MetadataSum, 48_496);
        }

        public override PuzzleResult RunPart2()
        {
            var calculator = new LicenseNumberCalculator(FileInput);
            return new PuzzleResult(calculator.RootNodeValue, 32_850);
        }
    }
}