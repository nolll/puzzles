using Core.PuzzleClasses;

namespace Core.Puzzles.Year2018.Day01
{
    public class Year2018Day01 : Year2018Day
    {
        public override int Day => 1;

        public override PuzzleResult RunPart1()
        {
            var frequencyPuzzle = new FrequencyPuzzle(FileInput);
            var resultingFrequency = frequencyPuzzle.ResultingFrequency;
            return new PuzzleResult(resultingFrequency, 525);
        }

        public override PuzzleResult RunPart2()
        {
            var frequencyRepeatPuzzle = new FrequencyRepeatPuzzle(FileInput);
            var firstRepeatedFrequency = frequencyRepeatPuzzle.FirstRepeatedFrequency;
            return new PuzzleResult(firstRepeatedFrequency, 75_749);
        }
    }
}