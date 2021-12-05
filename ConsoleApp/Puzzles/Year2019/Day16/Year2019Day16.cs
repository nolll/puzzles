using Core.FlawedFrequencyTransmission;

namespace ConsoleApp.Puzzles.Year2019.Day16
{
    public class Year2019Day16 : Year2019Day
    {
        public override int Day => 16;

        public override PuzzleResult RunPart1()
        {
            var algorithm1 = new FrequencyAlgorithmPart1(FileInput);
            var result1 = algorithm1.Run(100);

            return new PuzzleResult(result1, "19944447");
        }

        public override PuzzleResult RunPart2()
        {
            var algorithm2 = new FrequencyAlgorithmPart2(FileInput);
            var result2 = algorithm2.Run(100);

            return new PuzzleResult(result2, "81207421");
        }
    }
}