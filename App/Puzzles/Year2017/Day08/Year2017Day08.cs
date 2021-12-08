using App.Platform;

namespace App.Puzzles.Year2017.Day08
{
    public class Year2017Day08 : Year2017Day
    {
        public override int Day => 8;

        public override PuzzleResult RunPart1()
        {
            var calculator = new CpuInstructionCalculator(FileInput);
            return new PuzzleResult(calculator.LargestValueAtEnd, 6012);
        }

        public override PuzzleResult RunPart2()
        {
            var calculator = new CpuInstructionCalculator(FileInput);
            return new PuzzleResult(calculator.LargestValueEver, 6369);
        }
    }
}