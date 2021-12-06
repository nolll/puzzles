using Core.Platform;

namespace Core.Puzzles.Year2021.Day06
{
    public class Year2021Day06 : Year2021Day
    {
        public override int Day => 6;

        public override PuzzleResult RunPart1()
        {
            var fishCounter = new FishCounter(FileInput);
            var result = fishCounter.FishCountAfter(80);
            return new PuzzleResult(result, 383_160);
        }

        public override PuzzleResult RunPart2()
        {
            var fishCounter = new FishCounter(FileInput);
            var result = fishCounter.FishCountAfter(256);
            return new PuzzleResult(result, 1_721_148_811_504);
        }
    }
}