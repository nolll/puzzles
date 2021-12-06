using Core.Platform;

namespace Core.Puzzles.Year2016.Day25
{
    public class Year2016Day25 : Year2016Day
    {
        public override int Day => 25;

        public override PuzzleResult RunPart1()
        {
            var generator = new ClockSignalGenerator();
            return new PuzzleResult(generator.LowestA, 198);
        }

        public override PuzzleResult RunPart2()
        {
            return new EmptyPuzzleResult();
        }
    }
}